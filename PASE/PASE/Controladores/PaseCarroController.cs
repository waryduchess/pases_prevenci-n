using PASE.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASE.Controladores
{
    public class PaseCarroController
    {
        private readonly PaseCarroDAO dao = new PaseCarroDAO();

        public void GuardarPase(PaseCarro pase)
        {
            dao.InsertarPaseCarro(pase);
        }
    }

}
