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
    public partial class frmReporte : Form
    {
        private MovimientoController controlador = new MovimientoController();
        private List<Movimiento> resultados = new List<Movimiento>();
        public frmReporte()
        {
            InitializeComponent(); // Se agregó esta línea para inicializar los componentes del formulario.
            cmbTipoMovimiento.Items.Clear();
            cmbTipoMovimiento.Items.Add("Todos");
            cmbTipoMovimiento.Items.AddRange(new string[] {
                "Entrada", "Salida definitiva", "Salida con devolución"
            });
            cmbTipoMovimiento.SelectedIndex = 0;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string tipoSeleccionado = cmbTipoMovimiento.SelectedItem.ToString();    
            if (tipoSeleccionado == "Todos")
                tipoSeleccionado = null;

            var lista = controlador.ObtenerMovimientos(dtpDesde.Value, dtpHasta.Value, tipoSeleccionado);
            dgvResultados.DataSource = lista;
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            if (resultados == null || resultados.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Archivo PDF|*.pdf";
            saveDialog.Title = "Guardar Reporte";
            saveDialog.FileName = $"ReportePases_{DateTime.Now:yyyyMMdd}.pdf";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ReportePDF.ExportarResumen(resultados, saveDialog.FileName);
                MessageBox.Show("Reporte PDF generado correctamente.");
            }
        }

        private void dgvResultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cmbTipoMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
