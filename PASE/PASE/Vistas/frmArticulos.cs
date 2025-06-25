using PASE.Controladores;
using PASE.Modelos;
using PASE.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PASE
{
    public partial class frmArticulos : Form
    {
        private readonly MovimientoDAO _movimientoDAO;

        public frmArticulos()
        {
            InitializeComponent();
            textFolio.Text = FoliogeneradorArticulos.GenerarFolioUnico();
        }

        private void buttonGenerar_Click(object sender, EventArgs e)
        {
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Movimiento movimiento = new Movimiento
            {
                NombreHotel = cbxNmbreHotel.Text,
                Folio = textFolio.Text,
                TipoMovimiento = GroupEntradaSalidaRadio(),
                FechaSalida = Salida.Value,
                FechaRegreso = Regreso.Value,
                NumeroPaquetes = (int)numeroPaquetes.Value,
                NombreSolicitante = textNombre.Text,
                TipoPersona = GetTipoPersonaSeleccionada(),
                nombre_seguridad = textNombreSeguridad.Text
            };

            foreach (DataGridViewRow row in MostrarArticulos.Rows)
            {
                if (row.IsNewRow) continue;

                string nombre = row.Cells["colNombreArticulo"].Value?.ToString();
                string descripcion = row.Cells["colDescripcionArticulo"].Value?.ToString();

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    movimiento.Articulos.Add(new Articulo
                    {
                        NombreArticulo = nombre,
                        DescripcionArticulo = descripcion
                    });
                }
            }

            var controller = new MovimientoController();

            if (Salida.Value.Date < DateTime.Today)
            {
                MessageBox.Show("La fecha de salida no puede ser anterior a la fecha actual.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Regreso.Value <= Salida.Value)
            {
                MessageBox.Show("La fecha de regreso no puede ser anterior a la fecha de salida.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textFolio.Text) || string.IsNullOrWhiteSpace(textNombre.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (movimiento.Articulos.Count == 0)
            {
                MessageBox.Show("Debes agregar al menos un artículo.", "Sin artículos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                // Carpeta principal
                string carpetaPrincipal = Path.Combine(documentos, "PASE");
                Directory.CreateDirectory(carpetaPrincipal);

                // Subcarpeta Articulos
                string carpetaArticulos = Path.Combine(carpetaPrincipal, "Articulos");
                Directory.CreateDirectory(carpetaArticulos);

                string archivoPDF = Path.Combine(carpetaArticulos, $"Pase_Articulos_{movimiento.Folio}.pdf");

                // Asignar la ruta al objeto
                movimiento.RutaPDF = archivoPDF;

                // Guardar en base de datos
                controller.GuardarMovimiento(movimiento);

                // Generar PDF
                PDFGenerator pdfGen = new PDFGenerator();
                pdfGen.GenerarPDF(movimiento, archivoPDF);

                MessageBox.Show("Datos guardados, PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(archivoPDF);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Limpiar campos
            Regreso.Value = DateTime.Today;
            limpiarFormulario();
            numeroPaquetes.Value = 0;
            textFolio.Text = FoliogeneradorArticulos.GenerarFolioUnico();
        }

        private void limpiarFormulario()
        {
            cbxNmbreHotel.SelectedIndex = -1;
            textNombre.Clear();
            textDepartamento.Clear();
            textNombreSeguridad.Clear();
            MostrarArticulos.Rows.Clear();
            foreach (RadioButton radioButton in GroupEntradaSalida.Controls)
            {
                if (radioButton is RadioButton)
                {
                    radioButton.Checked = false;
                }
            }
            foreach (RadioButton radioButton in GroupTipo.Controls)
            {
                if (radioButton is RadioButton)
                {
                    radioButton.Checked = false;
                }
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textArticulo.Text.Trim();
            string descripcion = textDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre del artículo es obligatorio.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MostrarArticulos.Rows.Add(nombre, descripcion);
            numeroPaquetes.Value = numeroPaquetes.Value + 1;
            MostrarArticulos.Visible = true;
            btnContinuar.Visible = true;
            GroupTipo.Visible = false;
            label8.Visible = false;
            textDepartamento.Visible = false;
            label10.Visible = false;
            textNombreSeguridad.Visible = false;
            Regresar.Visible = false;
            buttonGuardar.Visible = false;

            // Limpiar campos
            textArticulo.Clear();
            textDescripcion.Clear();
            textArticulo.Focus();
        }

        // Método para obtener el tipo de movimiento (RadioButton seleccionado)
        private string GroupEntradaSalidaRadio()
        {
            foreach (Control control in GroupEntradaSalida.Controls) // Cambia groupBoxTipo por el nombre real de tu GroupBox
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    return radioButton.Text;
                }
            }
            return string.Empty;
        }

        // Método para obtener los tipos de persona seleccionados (CheckBox)
        private string GetTipoPersonaSeleccionada()
        {
            var seleccionados = new List<string>();
            foreach (Control control in GroupTipo.Controls) // Cambia groupBoxTipoPersona por el nombre real de tu GroupBo
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    return radioButton.Text;
                }
            }
            return string.Empty;
        }

        private void buttonReporte_Click(object sender, EventArgs e)
        {
        }

        private void textHotel_TextChanged(object sender, EventArgs e)
        {
        }

        private void textFolio_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            Close(); // Cierra el formulario actual y regresa al anterior
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarArticulos.Visible = false;
            btnContinuar.Visible = false;
        }

        private void Huespedes_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void textNombreSeguridad_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            MostrarArticulos.Visible = false;
            btnContinuar.Visible = false;
            GroupTipo.Visible = true;
            label8.Visible = true;
            textDepartamento.Visible = true;
            label10.Visible = true;
            textNombreSeguridad.Visible = true;
            Regresar.Visible = true;
            buttonGuardar.Visible = true;
        }

        private void textDepartamento_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void GroupTipo_Enter(object sender, EventArgs e)
        {
        }
    }
}
