using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASE.Modelos
{
    public class PaseCarroDAO
    {
        private readonly string connectionString = BD.ConnectionString;

        public void InsertarPaseCarro(PaseCarro pase)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                INSERT INTO pases_carro 
                (folio, fecha, nombre_conductor, placas, marca, modelo, color, motivo_visita, firma_seguridad_nombre)
                VALUES 
                (@folio, @fecha, @conductor, @placas, @marca, @modelo, @color, @motivo, @firma_seguridad);";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@folio", pase.Folio);
                cmd.Parameters.AddWithValue("@fecha", pase.Fecha);
                cmd.Parameters.AddWithValue("@conductor", pase.NombreConductor);
                cmd.Parameters.AddWithValue("@placas", pase.Placas);
                cmd.Parameters.AddWithValue("@marca", pase.Marca);
                cmd.Parameters.AddWithValue("@modelo", pase.Modelo);
                cmd.Parameters.AddWithValue("@color", pase.Color);
                cmd.Parameters.AddWithValue("@motivo", pase.MotivoVisita);
                cmd.Parameters.AddWithValue("@firma_seguridad", pase.FirmaSeguridadNombre);

                cmd.ExecuteNonQuery();
            }
        }
    }

}
