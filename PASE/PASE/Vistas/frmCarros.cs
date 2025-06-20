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

            textFolio.Text = FolioGeneratorCarros.GenerarFolioUnico();

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
                NombreHotel = cbxNmbreHotel.Text,
                Folio = textFolio.Text,
                Fecha = DateTime.Now,
                NombreConductor = textConductor.Text,
                Placas = textPlacas.Text,
                Marca = textMarca.Text,
                Modelo = textModelo.Text,
                Color = textColor.Text,
                MotivoVisita = textMotivo.Text,
                Nombre_seguridad = txtFirmaSeguridad.Text
            };

            PaseCarroController controlador = new PaseCarroController();
            controlador.GuardarPase(pase);

            MessageBox.Show("Pase de vehículo guardado correctamente en la base de datos.");

            // Generar PDF después de guardar
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Archivo PDF|*.pdf",
                Title = "Guardar Pase de Vehículo",
                FileName = $"Pase vehiculo_{pase.Folio}.pdf"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ReporteCarroPDF.ExportarPaseCarro(pase, saveDialog.FileName);
                MessageBox.Show("PDF generado correctamente.");
                System.Diagnostics.Process.Start(saveDialog.FileName);
            }

            textFolio.Text = FolioGeneratorCarros.GenerarFolioUnico();
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            /*
            if (!ValidarCampos())
                return;

            PaseCarro pase = new PaseCarro
            {
                NombreHotel = cbxNmbreHotel.Text, // Nombre del hotel por defecto
                Folio = textFolio.Text,
                Fecha = DateTime.Now,
                NombreConductor = textConductor.Text,
                Placas = textPlacas.Text,
                Marca = textMarca.Text,
                Modelo = textModelo.Text,
                Color = textColor.Text,
                MotivoVisita = textMotivo.Text,
                Nombre_seguridad = txtFirmaSeguridad.Text
            };

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Archivo PDF|*.pdf",
                Title = "Guardar Pase de Vehículo",
                FileName = $"Pase vehiculo_{pase.Folio}.pdf"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ReporteCarroPDF.ExportarPaseCarro(pase, saveDialog.FileName);
                MessageBox.Show("PDF generado correctamente.");
                System.Diagnostics.Process.Start(saveDialog.FileName);
            }
            */
        }

        private bool ValidarCampos()
        {
            if (cbxNmbreHotel.Text == "")
            {
                MessageBox.Show("Seleccione el nombre del hotel.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textConductor.Focus();
                return false;
            }
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

        private void Regresar_Click(object sender, EventArgs e)
        {
            Close(); // Cierra el formulario actual y regresa al anterior
        }

        private void frmCarros_Load(object sender, EventArgs e)
        {

        }

        private void textConductor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}