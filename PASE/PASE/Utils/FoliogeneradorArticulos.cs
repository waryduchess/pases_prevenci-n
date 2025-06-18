using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PASE.Modelos;

namespace PASE.Utils
{
    internal class FoliogeneradorArticulos
    {
        public static string GenerarFolioUnico()
        {
            try
            {
                var movimientoDAO = new MovimientoDAO();
                int ultimoNumero = movimientoDAO.ObtenerUltimoNumeroFolio();
                string nuevoFolio = $"TEC-{(ultimoNumero + 1):D6}"; // Formato con 6 ceros

                Console.WriteLine($"Nuevo folio generado: {nuevoFolio}");
                return nuevoFolio;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el folio: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "TEC-000001"; // Valor por defecto si hay error
            }
        }
    }
}
