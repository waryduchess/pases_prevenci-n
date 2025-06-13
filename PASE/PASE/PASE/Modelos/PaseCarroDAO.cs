using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Threading;

namespace PASE.Modelos
{
    public class PaseCarroDAO : IDisposable
    {
        private const string DatabaseFile = "articulos.db";
        private readonly string _connectionString = $"Data Source={DatabaseFile};Version=3;Journal Mode=WAL;";
        private static readonly object _dbLock = new object();

        public PaseCarroDAO()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            lock (_dbLock)
            {
                if (!File.Exists(DatabaseFile))
                {
                    SQLiteConnection.CreateFile(DatabaseFile);
                }

                using (var conn = new SQLiteConnection(_connectionString))
                {
                    conn.Open();

                    string createTableSql = @"
                    CREATE TABLE IF NOT EXISTS pases_carro (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        folio TEXT NOT NULL UNIQUE,
                        fecha DATETIME NOT NULL,
                        nombre_conductor TEXT NOT NULL,
                        placas TEXT NOT NULL,
                        marca TEXT NOT NULL,
                        modelo TEXT NOT NULL,
                        color TEXT NOT NULL,
                        motivo_visita TEXT NOT NULL,
                        firma_seguridad_nombre TEXT NOT NULL,
                        ruta_pdf TEXT,
                        CONSTRAINT folio_unique UNIQUE (folio)
                    )";

                    using (var cmd = new SQLiteCommand(createTableSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
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
                        using (var conn = new SQLiteConnection(_connectionString))
                        {
                            conn.Open();
                            using (var transaction = conn.BeginTransaction())
                            {
                                try
                                {
                                    string sql = @"
                                    INSERT INTO pases_carro 
                                    (folio, fecha, nombre_conductor, placas, marca, modelo, color, motivo_visita, firma_seguridad_nombre, ruta_pdf)
                                    VALUES 
                                    (@folio, @fecha, @nombre_conductor, @placas, @marca, @modelo, @color, @motivo_visita, @firma_seguridad_nombre, @ruta_pdf)";

                                    using (var cmd = new SQLiteCommand(sql, conn, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@folio", pase.Folio);
                                        cmd.Parameters.AddWithValue("@fecha", pase.Fecha);
                                        cmd.Parameters.AddWithValue("@nombre_conductor", pase.NombreConductor ?? "");
                                        cmd.Parameters.AddWithValue("@placas", pase.Placas ?? "");
                                        cmd.Parameters.AddWithValue("@marca", pase.Marca ?? "");
                                        cmd.Parameters.AddWithValue("@modelo", pase.Modelo ?? "");
                                        cmd.Parameters.AddWithValue("@color", pase.Color ?? "");
                                        cmd.Parameters.AddWithValue("@motivo_visita", pase.MotivoVisita ?? "");
                                        cmd.Parameters.AddWithValue("@firma_seguridad_nombre", pase.Nombre_seguridad ?? "");
                                        cmd.Parameters.AddWithValue("@ruta_pdf", string.IsNullOrEmpty(pase.RutaPDF) ? (object)DBNull.Value : pase.RutaPDF);

                                        cmd.ExecuteNonQuery();
                                        transaction.Commit();
                                        return;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    throw new Exception("Error en transacción: " + ex.Message);
                                }
                            }
                        }
                    }
                }
                catch (SQLiteException ex) when (ex.Message.Contains("locked"))
                {
                    intentos++;
                    if (intentos >= maxIntentos)
                    {
                        throw new Exception($"No se pudo insertar después de {maxIntentos} intentos. Error: {ex.Message}");
                    }
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
            {
                using (var conn = new SQLiteConnection(_connectionString))
                {
                    conn.Open();

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
                                   
                                    Folio = reader["folio"].ToString(),
                                    Fecha = Convert.ToDateTime(reader["fecha"]),
                                    NombreConductor = reader["nombre_conductor"].ToString(),
                                    Placas = reader["placas"].ToString(),
                                    Marca = reader["marca"].ToString(),
                                    Modelo = reader["modelo"].ToString(),
                                    Color = reader["color"].ToString(),
                                    MotivoVisita = reader["motivo_visita"].ToString(),
                                    Nombre_seguridad = reader["firma_seguridad_nombre"].ToString(),
                                    RutaPDF = reader["ruta_pdf"] == DBNull.Value ? null : reader["ruta_pdf"].ToString()
                                });
                            }
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
            {
                using (var conn = new SQLiteConnection(_connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT * FROM pases_carro 
                           WHERE folio LIKE @folio OR nombre_conductor LIKE @nombre";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@folio", "%" + folio + "%");
                        cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new PaseCarro
                                {
                                  
                                    Folio = reader["folio"].ToString(),
                                    Fecha = Convert.ToDateTime(reader["fecha"]),
                                    NombreConductor = reader["nombre_conductor"].ToString(),
                                    Placas = reader["placas"].ToString(),
                                    Marca = reader["marca"].ToString(),
                                    Modelo = reader["modelo"].ToString(),
                                    Color = reader["color"].ToString(),
                                    MotivoVisita = reader["motivo_visita"].ToString(),
                                    Nombre_seguridad = reader["firma_seguridad_nombre"].ToString(),
                                    RutaPDF = reader["ruta_pdf"] == DBNull.Value ? null : reader["ruta_pdf"].ToString()
                                });
                            }
                        }
                    }
                }
            }

            return lista;
        }

        public void ActualizarRutaPDF(string folio, string ruta)
        {
            lock (_dbLock)
            {
                using (var conn = new SQLiteConnection(_connectionString))
                {
                    conn.Open();

                    string sql = "UPDATE pases_carro SET ruta_pdf = @ruta WHERE folio = @folio";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@folio", folio);
                        cmd.Parameters.AddWithValue("@ruta", string.IsNullOrEmpty(ruta) ? (object)DBNull.Value : ruta);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public bool ExisteFolio(string folio)
        {
            lock (_dbLock)
            {
                using (var conn = new SQLiteConnection(_connectionString))
                {
                    conn.Open();

                    string sql = "SELECT COUNT(*) FROM pases_carro WHERE folio = @folio";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@folio", folio);
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
        }

        public void Dispose()
        {
            // Limpieza de recursos si es necesario
        }
    }
}