using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PASE.Modelos;

namespace PASE.Controladores
{
    public class LoginController
    {
        private readonly UsuarioDAO dao = new UsuarioDAO();

        public Usuario IniciarSesion(string usuario, string contrasena)
        {
            return dao.ValidarLogin(usuario, contrasena);
        }
    }
}

