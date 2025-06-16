using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
using System.IO;

namespace PASE.Modelos
{


    public static class DatabaseHelper
    {
        private static string _connectionString = "Data Source=articulos.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        public static void InitializeDatabase()
        {
            if (!File.Exists("articulos.db"))
            {
                SQLiteConnection.CreateFile("articulos.db");

                using (var connection = GetConnection())
                {
                    connection.Open();

                    // Ejecutar el script de creación de tablas
                    string createTablesScript = @"..."; // Aquí pegarías el script SQLite de arriba

                    using (var command = new SQLiteCommand(createTablesScript, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }


}


