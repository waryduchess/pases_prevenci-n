using PASE.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASE.Utils
{
       public static class FolioGenerator
    {
        public static string GenerarFolioUnico()
        {
            MovimientoDAO dao = new MovimientoDAO();
            string prefijo = "TEC";

            int ultimoNumero = dao.ObtenerUltimoNumeroFolio(); // Método nuevo que debes crear
            int nuevoNumero = ultimoNumero + 1;

            // Formato con ceros a la izquierda, ejemplo: HTL-000001
            string folio = $"{prefijo}-{nuevoNumero.ToString("D6")}";

            return folio;
        }
      }
}
