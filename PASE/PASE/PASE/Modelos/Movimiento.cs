using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASE.Modelos
{
    public class Movimiento
    {
        public string Folio { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaRegreso { get; set; }
        public int NumeroPaquetes { get; set; }
        public string NombreSolicitante { get; set; }
        public string TipoPersona { get; set; } // Puede ser lista de roles: "Empleado,Proveedor"
        public string FirmaSeguridadNombre { get; set; }

        public string NombreHotel { get; set; }

        // Relación con artículos
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();
    }



}
