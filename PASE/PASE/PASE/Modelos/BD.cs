using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASE.Modelos
{

    public class BD
    {
        private readonly string[] cadenasConexion = new string[]
        {
            "Data Source=ALEGRIA;Initial Catalog=ARTICULOS;Integrated Security=True;",
            "Data Source=DESKTOP-F014LE0\\SQLEXPRESS;Initial Catalog=BDHotel;Integrated Security=True;",
            "Data Source=AQUI-VA-LO-TUYO-ISA;Initial Catalog=BDHotelBackup;Integrated Security=True;"//aqui isa
        };
        
        public SqlConnection ObtenerConexion()
        {
            foreach (var cadena in cadenasConexion)
            {
                SqlConnection conexion = new SqlConnection(cadena);
                try
                {
                    conexion.Open();
                    // Conexión exitosa
                    return conexion;
                }
                catch
                {
                    // Intenta con la siguiente cadena
                    continue;
                }
            }

            // Si llegó hasta aquí, fallaron todas
            MessageBox.Show("No se pudo conectar a ninguna base de datos. Verifica tu conexión de red o contacta al administrador.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw new Exception("Fallo al conectar a todas las bases de datos.");
        }
    }


}


