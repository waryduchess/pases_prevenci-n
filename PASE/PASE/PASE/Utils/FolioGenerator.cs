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
            string prefijo = "HTL";
            string folio;
            bool folioExiste;

            do
            {
                string codigo = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
                folio = $"{prefijo}-{codigo}";
                folioExiste = dao.ExisteFolio(folio);
            }
            while (folioExiste);

            return folio;
        }
    }
}
