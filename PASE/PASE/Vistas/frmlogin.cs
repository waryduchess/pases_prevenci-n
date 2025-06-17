using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PASE.Controladores;
using PASE.Modelos;

namespace PASE.Vistas
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        
        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Navy;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if(txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor= Color.Silver;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Contraseña")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Navy;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Contraseña";
                txtPassword.ForeColor = Color.Silver;
                txtPassword.UseSystemPasswordChar = false;

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUser.Text.Trim();
            string contrasena = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingresa usuario y contraseña.");
                return;
            }

            var controlador =new LoginController();
            var usuarioLogeado = controlador.IniciarSesion(usuario, contrasena);

            if (usuarioLogeado != null)
            {
                MessageBox.Show($"Bienvenido, {usuarioLogeado.UsuarioLogin}");
                // Aquí puedes abrir el formulario principal, por ejemplo:
                frmPrincipal principal = new frmPrincipal();
                this.Hide();
                principal.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private void lbUsuario_Click_1(object sender, EventArgs e)
        {

        }
    }
}
