using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace PASE.Modelos
{
    public class MovimientoDAO
    {
        private static string _connectionString = "Data Source=articulos.db;Version=3;";

        private SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public void InsertarMovimiento(Movimiento mov)
        {
            using (SQLiteConnection conn = GetConnection())
            using (SQLiteTransaction tx = conn.BeginTransaction())
            {
                try
                {
                    string insertMov = @"
                        INSERT INTO movimientos 
                        (nombre_hotel,folio, tipo_movimiento, fecha_salida, fecha_regreso, numero_paquetes, 
                         nombre_solicitante, tipo_persona, nombre_seguridad, ruta_pdf)
                        VALUES 
                        (@nombre_hotel,@folio, @tipo_mov, @fecha_salida, @fecha_regreso, @num_paquetes, 
                         @nombre, @tipo_persona, @nombre_seguridad, @ruta_pdf);
                        SELECT last_insert_rowid();";

                    SQLiteCommand cmd = new SQLiteCommand(insertMov, conn, tx);
                    cmd.Parameters.AddWithValue("@nombre_hotel", mov.NombreHotel);
                    cmd.Parameters.AddWithValue("@folio", mov.Folio);
                    cmd.Parameters.AddWithValue("@tipo_mov", mov.TipoMovimiento);
                    cmd.Parameters.AddWithValue("@fecha_salida", mov.FechaSalida);
                    cmd.Parameters.AddWithValue("@fecha_regreso", mov.FechaRegreso.HasValue ? mov.FechaRegreso.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@num_paquetes", mov.NumeroPaquetes);
                    cmd.Parameters.AddWithValue("@nombre", mov.NombreSolicitante);
                    cmd.Parameters.AddWithValue("@tipo_persona", mov.TipoPersona);
                    cmd.Parameters.AddWithValue("@nombre_seguridad", mov.nombre_seguridad);
                    cmd.Parameters.AddWithValue("@ruta_pdf", mov.RutaPDF ?? "");

                    int idMovimiento = Convert.ToInt32(cmd.ExecuteScalar());

                    foreach (var articulo in mov.Articulos)
                    {
                        string insertArt = @"
                            INSERT INTO articulos 
                            (id_movimiento, nombre_articulo, descripcion_articulo)
                            VALUES 
                            (@id_mov, @nombre, @descripcion);";

                        SQLiteCommand cmdArt = new SQLiteCommand(insertArt, conn, tx);
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
            using (var conn = GetConnection())
            {
                string sql = "UPDATE movimientos SET ruta_pdf = @ruta WHERE folio = @folio";
                using (var cmd = new SQLiteCommand(sql, conn))
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
            using (var conn = GetConnection())
            {
                string query = "SELECT * FROM movimientos WHERE fecha_salida BETWEEN @desde AND @hasta";
                if (!string.IsNullOrEmpty(tipoMovimiento))
                    query += " AND tipo_movimiento = @tipo_mov";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    if (!string.IsNullOrEmpty(tipoMovimiento))
                        cmd.Parameters.AddWithValue("@tipo_mov", tipoMovimiento);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Movimiento
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Folio = reader["folio"].ToString(),
                                TipoMovimiento = reader["tipo_movimiento"].ToString(),
                                FechaSalida = Convert.ToDateTime(reader["fecha_salida"]),
                                FechaRegreso = reader["fecha_regreso"] != DBNull.Value ? Convert.ToDateTime(reader["fecha_regreso"]) : (DateTime?)null,
                                NumeroPaquetes = Convert.ToInt32(reader["numero_paquetes"]),
                                NombreSolicitante = reader["nombre_solicitante"].ToString(),
                                TipoPersona = reader["tipo_persona"].ToString(),
                                nombre_seguridad = reader["nombre_seguridad"].ToString(),
                                RutaPDF = reader["ruta_pdf"]?.ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public bool ExisteFolio(string folio)
        {
            using (var conn = GetConnection())
            {
                string query = "SELECT COUNT(*) FROM movimientos WHERE folio = @folio";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@folio", folio);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public List<Movimiento> BuscarPorFolioONombre(string folio, string nombre)
        {
            List<Movimiento> lista = new List<Movimiento>();
            using (var conn = GetConnection())
            {
                string query = "SELECT * FROM movimientos WHERE (@folio = '' OR folio = @folio) AND (@nombre = '' OR nombre_solicitante LIKE '%' || @nombre || '%')";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@folio", folio ?? "");
                    cmd.Parameters.AddWithValue("@nombre", nombre ?? "");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Movimiento
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Folio = reader["folio"].ToString(),
                                TipoMovimiento = reader["tipo_movimiento"].ToString(),
                                FechaSalida = Convert.ToDateTime(reader["fecha_salida"]),
                                FechaRegreso = reader["fecha_regreso"] != DBNull.Value ? Convert.ToDateTime(reader["fecha_regreso"]) : (DateTime?)null,
                                NumeroPaquetes = Convert.ToInt32(reader["numero_paquetes"]),
                                NombreSolicitante = reader["nombre_solicitante"].ToString(),
                                TipoPersona = reader["tipo_persona"].ToString(),
                                nombre_seguridad = reader["nombre_seguridad"].ToString(),
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
            using (var conn = GetConnection())
            {
                string query = "SELECT nombre_articulo, descripcion_articulo FROM articulos WHERE id_movimiento = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idMovimiento);
                    using (var reader = cmd.ExecuteReader())
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
            using (var conn = GetConnection())
            {
                string query = @"
                    SELECT MAX(CAST(SUBSTR(folio, 5) AS INTEGER)) as ultimo_numero
                    FROM movimientos 
                    WHERE folio LIKE 'TEC-%' 
                    AND LENGTH(folio) >= 10";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    object resultado = cmd.ExecuteScalar();
                    return (resultado != DBNull.Value && resultado != null) ? Convert.ToInt32(resultado) : 0;
                }
            }
        }
    }
}
