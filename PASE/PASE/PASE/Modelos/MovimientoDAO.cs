using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PASE.Modelos
{
    public class MovimientoDAO
    {
        BD bd = new BD();

        public void InsertarMovimiento(Movimiento mov)
        {
            using (SqlConnection conn = bd.ObtenerConexion())
            {
                SqlTransaction tx = conn.BeginTransaction();

                try
                {
                    string insertMov = @"
                        INSERT INTO movimientos 
                        (folio, tipo_movimiento, fecha_salida, fecha_regreso, numero_paquetes, nombre_solicitante, tipo_persona, nombre_seguridad, ruta_pdf)
                        OUTPUT INSERTED.ID
                        VALUES 
                        (@folio, @tipo_mov, @fecha_salida, @fecha_regreso, @num_paquetes, @nombre, @tipo_persona, @firma_seguridad, @ruta_pdf);";

                    SqlCommand cmd = new SqlCommand(insertMov, conn, tx);
                    cmd.Parameters.AddWithValue("@folio", mov.Folio);
                    cmd.Parameters.AddWithValue("@tipo_mov", mov.TipoMovimiento);
                    cmd.Parameters.AddWithValue("@fecha_salida", mov.FechaSalida);
                    cmd.Parameters.AddWithValue("@fecha_regreso", mov.FechaRegreso);
                    cmd.Parameters.AddWithValue("@num_paquetes", mov.NumeroPaquetes);
                    cmd.Parameters.AddWithValue("@nombre", mov.NombreSolicitante);
                    cmd.Parameters.AddWithValue("@tipo_persona", mov.TipoPersona);
                    cmd.Parameters.AddWithValue("@firma_seguridad", mov.FirmaSeguridadNombre);
                    cmd.Parameters.AddWithValue("@ruta_pdf", mov.RutaPDF ?? "");

                    int idMovimiento = (int)cmd.ExecuteScalar();

                    foreach (var articulo in mov.Articulos)
                    {
                        string insertArt = @"
                            INSERT INTO articulos 
                            (id_movimiento, nombre_articulo, descripcion_articulo)
                            VALUES 
                            (@id_mov, @nombre, @descripcion);";

                        SqlCommand cmdArt = new SqlCommand(insertArt, conn, tx);
                        cmdArt.Parameters.AddWithValue("@id_mov", idMovimiento);
                        cmdArt.Parameters.AddWithValue("@nombre", articulo.NombreArticulo);
                        cmdArt.Parameters.AddWithValue("@descripcion", articulo.DescripcionArticulo);
                        cmdArt.ExecuteNonQuery();
                    }

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception("Error al insertar en la base de datos: " + ex.Message);
                }
            }
        }

        public void ActualizarRutaPDF(string folio, string ruta)
        {
            using (SqlConnection conn = bd.ObtenerConexion())
            {
                string sql = "UPDATE movimientos SET ruta_pdf = @ruta WHERE folio = @folio";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@folio", folio);
                    cmd.Parameters.AddWithValue("@ruta", ruta);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Movimiento> ObtenerMovimientos(DateTime desde, DateTime hasta, string tipoMovimiento = null)
        {
            List<Movimiento> lista = new List<Movimiento>();

            using (SqlConnection conn = bd.ObtenerConexion())
            {
                string query = "SELECT * FROM movimientos WHERE fecha_salida BETWEEN @desde AND @hasta";

                if (!string.IsNullOrEmpty(tipoMovimiento))
                    query += " AND tipo_movimiento = @tipo_mov";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@desde", desde);
                cmd.Parameters.AddWithValue("@hasta", hasta);

                if (!string.IsNullOrEmpty(tipoMovimiento))
                    cmd.Parameters.AddWithValue("@tipo_mov", tipoMovimiento);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Movimiento
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Folio = reader["folio"].ToString(),
                        TipoMovimiento = reader["tipo_movimiento"].ToString(),
                        FechaSalida = Convert.ToDateTime(reader["fecha_salida"]),
                        FechaRegreso = Convert.ToDateTime(reader["fecha_regreso"]),
                        NumeroPaquetes = Convert.ToInt32(reader["numero_paquetes"]),
                        NombreSolicitante = reader["nombre_solicitante"].ToString(),
                        TipoPersona = reader["tipo_persona"].ToString(),
                        FirmaSeguridadNombre = reader["nombre_seguridad"].ToString(),
                        RutaPDF = reader["ruta_pdf"]?.ToString()
                    });
                }
            }

            return lista;
        }

        public bool ExisteFolio(string folio)
        {
            using (SqlConnection conn = bd.ObtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM movimientos WHERE folio = @folio";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@folio", folio);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public List<Movimiento> BuscarPorFolioONombre(string folio, string nombre)
        {
            List<Movimiento> lista = new List<Movimiento>();
            using (SqlConnection conn = bd.ObtenerConexion())
            {
                string query = "SELECT * FROM movimientos WHERE (@folio = '' OR folio = @folio) AND (@nombre = '' OR nombre_solicitante LIKE '%' + @nombre + '%')";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@folio", folio ?? "");
                    cmd.Parameters.AddWithValue("@nombre", nombre ?? "");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Movimiento
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Folio = reader["folio"].ToString(),
                                TipoMovimiento = reader["tipo_movimiento"].ToString(),
                                FechaSalida = Convert.ToDateTime(reader["fecha_salida"]),
                                FechaRegreso = Convert.ToDateTime(reader["fecha_regreso"]),
                                NumeroPaquetes = Convert.ToInt32(reader["numero_paquetes"]),
                                NombreSolicitante = reader["nombre_solicitante"].ToString(),
                                TipoPersona = reader["tipo_persona"].ToString(),
                                FirmaSeguridadNombre = reader["nombre_seguridad"].ToString(),
                                RutaPDF = reader["ruta_pdf"]?.ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public List<Articulo> ObtenerArticulosPorMovimiento(int idMovimiento)
        {
            List<Articulo> lista = new List<Articulo>();
            using (SqlConnection conn = bd.ObtenerConexion())
            {
                string query = "SELECT nombre_articulo, descripcion_articulo FROM articulos WHERE id_movimiento = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idMovimiento);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Articulo
                            {
                                NombreArticulo = reader["nombre_articulo"].ToString(),
                                DescripcionArticulo = reader["descripcion_articulo"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
        public int ObtenerUltimoNumeroFolio()
        {
            int ultimoNumero = 0;

            using (SqlConnection conn = bd.ObtenerConexion()) // Ya viene abierta
            {
                string query = "SELECT MAX(Folio) FROM Movimientos WHERE Folio LIKE 'HTL-%'";
                SqlCommand cmd = new SqlCommand(query, conn);

                // No llamar conn.Open() aquí

                object resultado = cmd.ExecuteScalar();

                if (resultado != DBNull.Value && resultado != null)
                {
                    string folio = resultado.ToString(); // Ejemplo: "HTL-000123"
                    string numeroStr = folio.Split('-')[1];
                    int.TryParse(numeroStr, out ultimoNumero);
                }
            }

            return ultimoNumero;
        }





    }
}
