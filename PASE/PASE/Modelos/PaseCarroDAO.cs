using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading;

namespace PASE.Modelos
{
    public class PaseCarroDAO : IDisposable
    {
        private static readonly object _dbLock = new object();
        private static string _connectionString = "Data Source=articulos.db;Version=3;";
        private SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }
        public void InsertarPaseCarro(PaseCarro pase)
        {
            int intentos = 0;
            const int maxIntentos = 5;
            const int delayMs = 100;

            while (intentos < maxIntentos)
            {
                try
                {
                    lock (_dbLock)
                    {
                        using (var conn = DatabaseHelper.GetConnection())
                        using (var transaction = conn.BeginTransaction())
                        {
                            string sql = @"
                                INSERT INTO pases_carro 
                                (nombre_hotel,folio, fecha, nombre_conductor, placas, marca, modelo, color, motivo_visita, nombre_seguridad, ruta_pdf)
                                VALUES 
                                (@nombre_hotel,@folio, @fecha, @nombre_conductor, @placas, @marca, @modelo, @color, @motivo_visita, @nombre_seguridad, @ruta_pdf)";

                            using (var cmd = new SQLiteCommand(sql, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@nombre_hotel", pase.NombreHotel ?? "");
                                cmd.Parameters.AddWithValue("@folio", pase.Folio);
                                cmd.Parameters.AddWithValue("@fecha", pase.Fecha);
                                cmd.Parameters.AddWithValue("@nombre_conductor", pase.NombreConductor ?? "");
                                cmd.Parameters.AddWithValue("@placas", pase.Placas ?? "");
                                cmd.Parameters.AddWithValue("@marca", pase.Marca ?? "");
                                cmd.Parameters.AddWithValue("@modelo", pase.Modelo ?? "");
                                cmd.Parameters.AddWithValue("@color", pase.Color ?? "");
                                cmd.Parameters.AddWithValue("@motivo_visita", pase.MotivoVisita ?? "");
                                cmd.Parameters.AddWithValue("@nombre_seguridad", pase.Nombre_seguridad ?? "");
                                cmd.Parameters.AddWithValue("@ruta_pdf", string.IsNullOrEmpty(pase.RutaPDF) ? (object)DBNull.Value : pase.RutaPDF);

                                cmd.ExecuteNonQuery();
                                transaction.Commit();
                                return;
                            }
                        }
                    }
                }
                catch (SQLiteException ex) when (ex.Message.Contains("locked"))
                {
                    intentos++;
                    if (intentos >= maxIntentos)
                        throw new Exception($"No se pudo insertar después de {maxIntentos} intentos. Error: {ex.Message}");
                    Thread.Sleep(delayMs);
                }
                catch (SQLiteException ex) when (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Ya existe un pase con este folio", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el pase de carro: " + ex.Message);
                }
            }
        }

        public List<PaseCarro> ObtenerPasesCarro(DateTime desde, DateTime hasta)
        {
            var lista = new List<PaseCarro>();

            lock (_dbLock)
                using (var conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT * FROM pases_carro WHERE fecha BETWEEN @desde AND @hasta";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@desde", desde);
                        cmd.Parameters.AddWithValue("@hasta", hasta);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new PaseCarro
                                {
                                    NombreHotel = reader["nombre_hotel"].ToString(),
                                    Folio = reader["folio"].ToString(),
                                    Fecha = Convert.ToDateTime(reader["fecha"]),
                                    NombreConductor = reader["nombre_conductor"].ToString(),
                                    Placas = reader["placas"].ToString(),
                                    Marca = reader["marca"].ToString(),
                                    Modelo = reader["modelo"].ToString(),
                                    Color = reader["color"].ToString(),
                                    MotivoVisita = reader["motivo_visita"].ToString(),
                                    Nombre_seguridad = reader["nombre_seguridad"].ToString(),
                                    RutaPDF = reader["ruta_pdf"] == DBNull.Value ? null : reader["ruta_pdf"].ToString()
                                });
                            }
                        }
                    }
                }

            return lista;
        }

        public List<PaseCarro> BuscarPorFolioONombre(string folio, string nombre)
        {
            var lista = new List<PaseCarro>();

            lock (_dbLock)
                using (var conn = DatabaseHelper.GetConnection())
                {
                    string sql = @"SELECT * FROM pases_carro 
                                   WHERE (@folio = '' OR folio LIKE @folio)
                                     AND (@nombre = '' OR nombre_conductor LIKE @nombre)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@folio", string.IsNullOrEmpty(folio) ? "" : "%" + folio + "%");
                        cmd.Parameters.AddWithValue("@nombre", string.IsNullOrEmpty(nombre) ? "" : "%" + nombre + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new PaseCarro
                                {
                                    NombreHotel = reader["nombre_hotel"].ToString(),
                                    Folio = reader["folio"].ToString(),
                                    Fecha = Convert.ToDateTime(reader["fecha"]),
                                    NombreConductor = reader["nombre_conductor"].ToString(),
                                    Placas = reader["placas"].ToString(),
                                    Marca = reader["marca"].ToString(),
                                    Modelo = reader["modelo"].ToString(),
                                    Color = reader["color"].ToString(),
                                    MotivoVisita = reader["motivo_visita"].ToString(),
                                    Nombre_seguridad = reader["nombre_seguridad"].ToString(),
                                    RutaPDF = reader["ruta_pdf"] == DBNull.Value ? null : reader["ruta_pdf"].ToString()
                                });
                            }
                        }
                    }
                }

            return lista;
        }

        public void ActualizarRutaPDF(string folio, string ruta)
        {
            lock (_dbLock)
                using (var conn = DatabaseHelper.GetConnection())
                {
                    string sql = "UPDATE pases_carro SET ruta_pdf = @ruta WHERE folio = @folio";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@folio", folio);
                        cmd.Parameters.AddWithValue("@ruta", string.IsNullOrEmpty(ruta) ? (object)DBNull.Value : ruta);
                        cmd.ExecuteNonQuery();
                    }
                }
        }

        public bool ExisteFolio(string folio)
        {
            lock (_dbLock)
                using (var conn = DatabaseHelper.GetConnection())
                {
                    string sql = "SELECT COUNT(*) FROM pases_carro WHERE folio = @folio";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@folio", folio);
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
        }

        public int ObtenerUltimoNumeroFolio()
        {
            using (var conn = GetConnection())
            {
                string query = @"
                    SELECT MAX(CAST(SUBSTR(folio, 5) AS INTEGER)) as ultimo_numero
                    FROM pases_carro 
                    WHERE folio LIKE 'TEC-%' 
                    AND LENGTH(folio) >= 10";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    object resultado = cmd.ExecuteScalar();
                    return (resultado != DBNull.Value && resultado != null) ? Convert.ToInt32(resultado) : 0;
                }
            }
        }

        public void Dispose()
        {
            // No se necesita liberar recursos en este DAO en particular.
        }
    }
}
