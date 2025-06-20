using System;
using System.Data.SQLite;
using System.IO;

namespace PASE.Modelos
{
    public static class DatabaseHelper
    {
        private static string _connectionString = "Data Source=articulos.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(_connectionString);
            conn.Open();
            return conn;
        }

        public static void InitializeDatabase()
        {
            if (!File.Exists("articulos.db"))
            {
                SQLiteConnection.CreateFile("articulos.db");

                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string createTablesScript = @"
                        CREATE TABLE IF NOT EXISTS movimientos (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            nombre_hotel TEXT,
                            folio TEXT,
                            tipo_movimiento TEXT,
                            fecha_salida TEXT,
                            fecha_regreso TEXT,
                            numero_paquetes INTEGER,
                            nombre_solicitante TEXT,
                            tipo_persona TEXT,
                            nombre_seguridad TEXT,
                            ruta_pdf TEXT
                        );

                        CREATE TABLE IF NOT EXISTS articulos (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            id_movimiento INTEGER,
                            nombre_articulo TEXT,
                            descripcion_articulo TEXT,
                            FOREIGN KEY (id_movimiento) REFERENCES movimientos(id)
                        );

                        CREATE TABLE IF NOT EXISTS usuarios (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            nombre_usuario TEXT NOT NULL UNIQUE,
                            contrasena TEXT NOT NULL
                        );

                        CREATE TABLE IF NOT EXISTS pases_carro (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            nombre_hotel TEXT NOT NULL,
                            folio TEXT NOT NULL UNIQUE,
                            fecha DATETIME NOT NULL,
                            nombre_conductor TEXT NOT NULL,
                            placas TEXT NOT NULL,
                            marca TEXT NOT NULL,
                            modelo TEXT NOT NULL,
                            color TEXT NOT NULL,
                            motivo_visita TEXT NOT NULL,
                            nombre_seguridad TEXT NOT NULL,
                            ruta_pdf TEXT
                        );
                    ";

                    using (var command = new SQLiteCommand(createTablesScript, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // ✅ Insertar usuario por defecto
                    string insertAdmin = @"
                        INSERT INTO usuarios (nombre_usuario, contrasena)
                        VALUES ('admi', 'admin123');";

                    using (var insertCmd = new SQLiteCommand(insertAdmin, connection))
                    {
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
