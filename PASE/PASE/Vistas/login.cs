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
    public partial class login : Form
    {
      

        public login()
        {
            InitializeComponent();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*FrmPrincipal frmPrincipal = new FrmPrincipal();//Crea una instancia del formulario Form1
            this.Hide();//Ocultael formulario actual
            frmPrincipal.ShowDialog();//muestra el formulario
            this.Show();*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void lbUsuario_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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



        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmPrincipal frmPrincipal = new FrmPrincipal();//Crea una instancia del formulario Form1
            this.Hide();//Ocultael formulario actual
            frmPrincipal.ShowDialog();//muestra el formulario
            this.Show();//muestra el formulario actual
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
                FrmPrincipal principal = new FrmPrincipal();
                this.Hide();
                principal.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }

        }
    }
}
