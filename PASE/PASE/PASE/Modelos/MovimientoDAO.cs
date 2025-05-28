using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASE.Modelos
{
    public class MovimientoDAO
    {
        private readonly string connectionString =BD.ConnectionString;

        public void InsertarMovimiento(Movimiento mov)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tx = conn.BeginTransaction();

                try
                {
                    string insertMov = @"
                        INSERT INTO movimientos 
                        (folio, tipo_movimiento, fecha_salida, fecha_regreso, numero_paquetes, nombre_solicitante, tipo_persona, nombre_seguridad)
                        OUTPUT INSERTED.ID
                        VALUES 
                        (@folio, @tipo_mov, @fecha_salida, @fecha_regreso, @num_paquetes, @nombre, @tipo_persona, @firma_seguridad);";

                    SqlCommand cmd = new SqlCommand(insertMov, conn, tx);
                    cmd.Parameters.AddWithValue("@folio", mov.Folio);
                    cmd.Parameters.AddWithValue("@tipo_mov", mov.TipoMovimiento);
                    cmd.Parameters.AddWithValue("@fecha_salida", mov.FechaSalida);
                    cmd.Parameters.AddWithValue("@fecha_regreso", mov.FechaRegreso);
                    cmd.Parameters.AddWithValue("@num_paquetes", mov.NumeroPaquetes);
                    cmd.Parameters.AddWithValue("@nombre", mov.NombreSolicitante);
                    cmd.Parameters.AddWithValue("@tipo_persona", mov.TipoPersona);
                    cmd.Parameters.AddWithValue("@firma_seguridad", mov.FirmaSeguridadNombre);

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


        public List<Movimiento> ObtenerMovimientos(DateTime desde, DateTime hasta, string tipoMovimiento = null)
        {
            List<Movimiento> lista = new List<Movimiento>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
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
                        FirmaSeguridadNombre = reader["nombre_seguridad"].ToString()
                    });
                }
            }

            return lista;
        }

        public bool ExisteFolio(string folio)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM movimientos WHERE folio = @folio";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@folio", folio);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }


    }
}
