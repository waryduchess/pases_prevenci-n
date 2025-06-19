using PASE.Controladores;
using PASE.Modelos;
using PASE.Utils;
using System;
using System.Collections.Generic;
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
            var controller = new MovimientoController();

            // Validación de fechas
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

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(textFolio.Text) || string.IsNullOrWhiteSpace(textNombre.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Movimiento movimiento = new Movimiento
                {
                    NombreHotel = cbxNmbreHotel.Text,
                    Folio = textFolio.Text,
                    TipoMovimiento = GroupEntradaSalidaRadio(), // método que extrae el tipo del RadioButton seleccionado
                    FechaSalida = Salida.Value,
                    FechaRegreso = Regreso.Value,
                    NumeroPaquetes = (int)numeroPaquetes.Value,
                    NombreSolicitante = textNombre.Text,
                    TipoPersona = GetTipoPersonaSeleccionada(), // método que junta los checkboxes seleccionados
                    nombre_seguridad = textNombreSeguridad.Text
                };

                // Cargar los artículos del DataGridView
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

                // Validar que haya al menos un artículo
                if (movimiento.Articulos.Count == 0)
                {
                    MessageBox.Show("Debes agregar al menos un artículo.", "Sin artículos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Guardar
                controller.GuardarMovimiento(movimiento);
                MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

             

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textFolio.Text = FoliogeneradorArticulos.GenerarFolioUnico();
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
            Movimiento movimiento = new Movimiento
            {
                Folio = textFolio.Text,
                TipoMovimiento = GroupEntradaSalidaRadio(),
                FechaSalida = Salida.Value,
                FechaRegreso = Regreso.Value,
                NumeroPaquetes = (int)numeroPaquetes.Value,
                NombreSolicitante = textNombre.Text,
                TipoPersona = GetTipoPersonaSeleccionada(),
                nombre_seguridad = textNombreSeguridad.Text
            };

            // ✅ Agregar artículos
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

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Archivo PDF|*.pdf",
                Title = "Guardar Pase de Vehículo",
                FileName = $"Pase articulos_{movimiento.Folio}.pdf"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                PDFGenerator pdfGen = new PDFGenerator();

                pdfGen.GenerarPDF(movimiento, saveDialog.FileName);
                MessageBox.Show("PDF generado correctamente.");
                System.Diagnostics.Process.Start(saveDialog.FileName);
            }
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            Close(); // Cierra el formulario actual y regresa al anterior
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
