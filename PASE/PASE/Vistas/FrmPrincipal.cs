using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASE.Vistas
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void EntradaySalida_Click(object sender, EventArgs e)
        {
            frmPases form1 = new frmPases();//Crea una instancia del formulario Form1
            this.Hide();//Ocultael formulario actual
            form1.ShowDialog();//muestra el formulario
            this.Show();//muestra el formulario actual
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCarros Carros = new frmCarros();//Crea una instancia del formulario frmCarros
            this.Hide();//Oculta el formulario actual
            Carros.ShowDialog();//muestra el formulario
            this.Show();//muestra el formulario actual
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmBusquedaReportes reporte = new frmBusquedaReportes();//Crea una instancia del formulario frmCarros
            this.Hide();//Oculta el formulario actual
            reporte.ShowDialog();//muestra el formulario
            this.Show();//muestra el formulario actual
        }
    }
}
