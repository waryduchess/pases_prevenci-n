using PASE.Controladores;
using PASE.Modelos;
using PASE.Utils;
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
    public partial class frmCarros : Form
    {
        public frmCarros()
        {
            InitializeComponent();
            string prefijo = "HTL"; // Puedes cambiarlo por el nombre del hotel
            string codigo = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(); // 8 caracteres únicos
            string folio = $"{prefijo}-{codigo}";

            textFolio.Text = folio;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            PaseCarro pase = new PaseCarro
            {
                Folio = textFolio.Text,
                Fecha = DateTime.Now,
                NombreConductor = textConductor.Text,
                Placas = textPlacas.Text,
                Marca = textMarca.Text,
                Modelo = textModelo.Text,
                Color = textColor.Text,
                MotivoVisita = textMotivo.Text,
                FirmaSeguridadNombre = txtFirmaSeguridad.Text
            };

            PaseCarroController controlador = new PaseCarroController();
            controlador.GuardarPase(pase);

            MessageBox.Show("Pase de vehículo guardado correctamente en la base de datos.");
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            PaseCarro pase = new PaseCarro
            {
                Folio = textFolio.Text,
                Fecha = DateTime.Now,
                NombreConductor = textConductor.Text,
                Placas = textPlacas.Text,
                Marca = textMarca.Text,
                Modelo = textModelo.Text,
                Color = textColor.Text,
                MotivoVisita = textMotivo.Text,
                FirmaSeguridadNombre = txtFirmaSeguridad.Text
            };

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Archivo PDF|*.pdf",
                Title = "Guardar Pase de Vehículo",
                FileName = $"PaseCarro_{pase.Folio}.pdf"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ReporteCarroPDF.ExportarPaseCarro(pase, saveDialog.FileName);
                MessageBox.Show("PDF generado correctamente.");
                System.Diagnostics.Process.Start(saveDialog.FileName);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textConductor.Text))
            {
                MessageBox.Show("Ingrese el nombre del conductor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textConductor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textPlacas.Text))
            {
                MessageBox.Show("Ingrese las placas del vehículo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPlacas.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textMarca.Text))
            {
                MessageBox.Show("Ingrese la marca del vehículo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textMarca.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textModelo.Text))
            {
                MessageBox.Show("Ingrese el modelo del vehículo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textModelo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textColor.Text))
            {
                MessageBox.Show("Ingrese el color del vehículo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textColor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textMotivo.Text))
            {
                MessageBox.Show("Ingrese el motivo de la visita.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textMotivo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirmaSeguridad.Text))
            {
                MessageBox.Show("Ingrese el nombre de quien autoriza en seguridad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirmaSeguridad.Focus();
                return false;
            }

            return true; // Todo correcto
        }

        private void textFolio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
