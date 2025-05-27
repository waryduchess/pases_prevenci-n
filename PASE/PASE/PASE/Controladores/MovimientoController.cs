using PASE.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASE.Controladores
{
    public class MovimientoController
    {
        private readonly MovimientoDAO dao = new MovimientoDAO();

        /// <summary>
        /// Guarda el movimiento en la base de datos.
        /// </summary>
        /// <param name="movimiento">Objeto con todos los datos del pase.</param>
        public void GuardarMovimiento(Movimiento movimiento)
        {
            dao.InsertarMovimiento(movimiento);
        }

        /// <summary>
        /// Obtiene una lista de movimientos filtrados por fecha y tipo.
        /// </summary>
        /// <param name="desde">Fecha de inicio</param>
        /// <param name="hasta">Fecha de fin</param>
        /// <param name="tipoMovimiento">Tipo de movimiento o null para todos</param>
        /// <returns>Lista de movimientos</returns>
        public List<Movimiento> ObtenerMovimientos(DateTime desde, DateTime hasta, string tipoMovimiento = null)
        {
            return dao.ObtenerMovimientos(desde, hasta, tipoMovimiento);
        }
    }
}
