using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PASE.Modelos
{
    public class PaseCarroDAO
    {
        BD bd = new BD();

        public void InsertarPaseCarro(PaseCarro pase)
        {
            try
            {
                using (SqlConnection conn = bd.ObtenerConexion())
                {
                    string sql = @"
                        INSERT INTO pases_carro 
                        (folio, fecha, nombre_conductor, placas, marca, modelo, color, motivo_visita, firma_seguridad_nombre)
                        VALUES 
                        (@folio, @fecha, @conductor, @placas, @marca, @modelo, @color, @motivo, @firma_seguridad);";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@folio", pase.Folio);
                        cmd.Parameters.AddWithValue("@fecha", pase.Fecha);
                        cmd.Parameters.AddWithValue("@conductor", pase.NombreConductor ?? "");
                        cmd.Parameters.AddWithValue("@placas", pase.Placas ?? "");
                        cmd.Parameters.AddWithValue("@marca", pase.Marca ?? "");
                        cmd.Parameters.AddWithValue("@modelo", pase.Modelo ?? "");
                        cmd.Parameters.AddWithValue("@color", pase.Color ?? "");
                        cmd.Parameters.AddWithValue("@motivo", pase.MotivoVisita ?? "");
                        cmd.Parameters.AddWithValue("@firma_seguridad", pase.FirmaSeguridadNombre ?? "");

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el pase de carro: " + ex.Message);
            }
        }

        public List<PaseCarro> ObtenerPasesCarro(DateTime desde, DateTime hasta)
        {
            List<PaseCarro> lista = new List<PaseCarro>();

            using (SqlConnection conn = bd.ObtenerConexion())
            {
                string query = "SELECT * FROM pases_carro WHERE fecha BETWEEN @desde AND @hasta";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);

                    using (SqlDataReader reader = cmd.ExecuteReader())
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
                                FirmaSeguridadNombre = reader["firma_seguridad_nombre"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}
