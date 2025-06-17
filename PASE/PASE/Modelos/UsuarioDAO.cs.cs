using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace PASE.Modelos
{
    public class UsuarioDAO
    {
        private string connectionString = "Data Source=articulos.db";

        public Usuario ValidarLogin(string usuario, string contrasena)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT * FROM usuarios WHERE nombre_usuario = @usuario AND contrasena = @contrasena";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id = Convert.ToInt32(reader["id"]),
                               
                                UsuarioLogin = reader["usuario"].ToString(),
                                Contrasena = reader["contrasena"].ToString(),
                              
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}

