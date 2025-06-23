using PASE.Controladores;
using PASE.Modelos;
using PASE.Utils;
using System;
using System.IO;
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

            try
            {
                string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Carpeta principal
                string carpetaPrincipal = Path.Combine(documentos, "PASE");
                Directory.CreateDirectory(carpetaPrincipal);

                // Subcarpeta Vehiculos
                string carpetaVehiculos = Path.Combine(carpetaPrincipal, "Vehiculos");
                Directory.CreateDirectory(carpetaVehiculos);

                // Ruta completa del archivo PDF
                string archivoPDF = Path.Combine(carpetaVehiculos, $"Pase_Vehiculo_{pase.Folio}.pdf");

                // Generar PDF
                ReporteCarroPDF.ExportarPaseCarro(pase, archivoPDF);
                pase.RutaPDF = archivoPDF;

                // Guardar en base de datos
                PaseCarroController controlador = new PaseCarroController();
                controlador.GuardarPase(pase);

                MessageBox.Show("Pase de vehículo guardado correctamente y PDF generado.");
                System.Diagnostics.Process.Start(archivoPDF);

                // Limpiar formulario
                textFolio.Text = FolioGeneratorCarros.GenerarFolioUnico();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el pase: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LimpiarCampos()
        {
            cbxNmbreHotel.SelectedIndex = -1;
            textConductor.Clear();
            textPlacas.Clear();
            textMarca.Clear();
            textModelo.Clear();
            textColor.Clear();
            textMotivo.Clear();
            txtFirmaSeguridad.Clear();
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

