using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace PASE.Modelos
{
    public class MovimientoDAO
    {
        private static string _connectionString = "Data Source=articulos.db;Version=3;";

        public MovimientoDAO()
        {
            // Asegurarse que la base de datos existe al crear el DAO
            if (!File.Exists("articulos.db"))
            {
                InitializeDatabase();
            }
        }

        private SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }

        private void InitializeDatabase()
        {
            SQLiteConnection.CreateFile("articulos.db");

            using (var connection = GetConnection())
            {
                // Script de creación de tablas
                string createTablesScript = @"
                BEGIN TRANSACTION;

                CREATE TABLE IF NOT EXISTS [movimientos] (
                    [id] INTEGER PRIMARY KEY AUTOINCREMENT,
                    [folio] TEXT,
                    [tipo_movimiento] TEXT,
                    [fecha_salida] DATETIME,
                    [fecha_regreso] DATETIME,
                    [numero_paquetes] INTEGER,
                    [nombre_solicitante] TEXT,
                    [tipo_persona] TEXT,
                    [nombre_seguridad] TEXT,
                    [ruta_pdf] TEXT
                );

                CREATE TABLE IF NOT EXISTS [articulos] (
                    [id] INTEGER PRIMARY KEY AUTOINCREMENT,
                    [id_movimiento] INTEGER,
                    [nombre_articulo] TEXT,
                    [descripcion_articulo] TEXT,
                    FOREIGN KEY([id_movimiento]) REFERENCES [movimientos]([id])
                );

                CREATE TABLE IF NOT EXISTS [pases_carro] (
                    [id] INTEGER PRIMARY KEY AUTOINCREMENT,
                    [folio] TEXT,
                    [fecha] DATETIME,
                    [nombre_conductor] TEXT,
                    [placas] TEXT,
                    [marca] TEXT,
                    [modelo] TEXT,
                    [color] TEXT,
                    [motivo_visita] TEXT,
                    [nombre_seguridad] TEXT,
                    [ruta_pdf] TEXT
                );

                COMMIT;";

                using (var command = new SQLiteCommand(createTablesScript, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertarMovimiento(Movimiento mov)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                SQLiteTransaction tx = conn.BeginTransaction();

                try
                {
                    string insertMov = @"
                        INSERT INTO movimientos 
                        (folio, tipo_movimiento, fecha_salida, fecha_regreso, numero_paquetes, 
                         nombre_solicitante, tipo_persona, nombre_seguridad, ruta_pdf)
                        VALUES 
                        (@folio, @tipo_mov, @fecha_salida, @fecha_regreso, @num_paquetes, 
                         @nombre, @tipo_persona, @nombre_seguridad, @ruta_pdf);
                        SELECT last_insert_rowid();";

                    SQLiteCommand cmd = new SQLiteCommand(insertMov, conn, tx);
                    cmd.Parameters.AddWithValue("@folio", mov.Folio);
                    cmd.Parameters.AddWithValue("@tipo_mov", mov.TipoMovimiento);
                    cmd.Parameters.AddWithValue("@fecha_salida", mov.FechaSalida);

                    // Manejo correcto de fecha_regreso que puede ser null
                    if (mov.FechaRegreso == null)
                        cmd.Parameters.AddWithValue("@fecha_regreso", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@fecha_regreso", mov.FechaRegreso);

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
            using (SQLiteConnection conn = GetConnection())
            {
                string sql = "UPDATE movimientos SET ruta_pdf = @ruta WHERE folio = @folio";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
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

            using (SQLiteConnection conn = GetConnection())
            {
                string query = "SELECT * FROM movimientos WHERE fecha_salida BETWEEN @desde AND @hasta";

                if (!string.IsNullOrEmpty(tipoMovimiento))
                    query += " AND tipo_movimiento = @tipo_mov";

                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@desde", desde);
                cmd.Parameters.AddWithValue("@hasta", hasta);

                if (!string.IsNullOrEmpty(tipoMovimiento))
                    cmd.Parameters.AddWithValue("@tipo_mov", tipoMovimiento);

                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime? fechaRegreso = null;
                    if (reader["fecha_regreso"] != DBNull.Value)
                    {
                        fechaRegreso = Convert.ToDateTime(reader["fecha_regreso"]);
                    }

                    lista.Add(new Movimiento
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Folio = reader["folio"].ToString(),
                        TipoMovimiento = reader["tipo_movimiento"].ToString(),
                        FechaSalida = Convert.ToDateTime(reader["fecha_salida"]),
                        FechaRegreso = (DateTime)fechaRegreso,
                        NumeroPaquetes = Convert.ToInt32(reader["numero_paquetes"]),
                        NombreSolicitante = reader["nombre_solicitante"].ToString(),
                        TipoPersona = reader["tipo_persona"].ToString(),
                        nombre_seguridad = reader["nombre_seguridad"].ToString(),
                        RutaPDF = reader["ruta_pdf"]?.ToString()
                    });
                }
            }

            return lista;
        }

        public bool ExisteFolio(string folio)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                string query = "SELECT COUNT(*) FROM movimientos WHERE folio = @folio";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@folio", folio);

                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public List<Movimiento> BuscarPorFolioONombre(string folio, string nombre)
        {
            List<Movimiento> lista = new List<Movimiento>();
            using (SQLiteConnection conn = GetConnection())
            {
                string query = "SELECT * FROM movimientos WHERE (@folio = '' OR folio = @folio) AND (@nombre = '' OR nombre_solicitante LIKE '%' || @nombre || '%')";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@folio", folio ?? "");
                    cmd.Parameters.AddWithValue("@nombre", nombre ?? "");
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime? fechaRegreso = null;
                            if (reader["fecha_regreso"] != DBNull.Value)
                            {
                                fechaRegreso = Convert.ToDateTime(reader["fecha_regreso"]);
                            }

                            lista.Add(new Movimiento
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Folio = reader["folio"].ToString(),
                                TipoMovimiento = reader["tipo_movimiento"].ToString(),
                                FechaSalida = Convert.ToDateTime(reader["fecha_salida"]),
                                FechaRegreso = (DateTime)fechaRegreso,
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
            using (SQLiteConnection conn = GetConnection())
            {
                string query = "SELECT nombre_articulo, descripcion_articulo FROM articulos WHERE id_movimiento = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idMovimiento);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
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

            using (SQLiteConnection conn = GetConnection())
            {
                string query = "SELECT MAX(Folio) FROM movimientos WHERE Folio LIKE 'HTL-%'";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);

                object resultado = cmd.ExecuteScalar();

                if (resultado != DBNull.Value && resultado != null)
                {
                    string folio = resultado.ToString();
                    string numeroStr = folio.Split('-')[1];
                    int.TryParse(numeroStr, out ultimoNumero);
                }
            }

            return ultimoNumero;
        }
    }
}