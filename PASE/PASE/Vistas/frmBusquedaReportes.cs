using System;
using System.Windows.Forms;
using PASE.Modelos;
using PASE.Utils;
using PASE.Modelos;
using PASE.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PASE.Vistas
{
    public partial class frmBusquedaReportes : Form
    {
        private ComboBox comboTipo;
        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox txtNombre;
        private TextBox txtFolio;
        private DataGridView dgvResultados;
        private Button btnBuscar;
        private Button btnReimprimir;
        private Button btnRegresar;
        private PictureBox pictureBox1;
        private Label label3;

        public frmBusquedaReportes()
        {
            InitializeComponent();
            comboTipo.SelectedIndex = 0; // Por defecto buscar movimientos
            
        }


        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string folio = txtFolio.Text.Trim();
            string nombre = txtNombre.Text.Trim();

            if (string.IsNullOrWhiteSpace(folio) && string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingresa al menos un folio o un nombre para realizar la búsqueda.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (comboTipo.SelectedIndex == 0) // Movimientos
            {
                MovimientoDAO dao = new MovimientoDAO();
                var resultados = dao.BuscarPorFolioONombre(folio, nombre);
                dgvResultados.DataSource = resultados;
            }
            else // Pases de carro
            {
                PaseCarroDAO dao = new PaseCarroDAO();
                var resultados = dao.BuscarPorFolioONombre(folio, nombre);
                dgvResultados.DataSource = null;
                dgvResultados.DataSource = null;
                dgvResultados.DataSource = resultados;
            }
        }

        private void btnReimprimir_Click_1(object sender, EventArgs e)
        {
            if (dgvResultados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un registro para reimprimir.");
                return;
            }

            if (comboTipo.SelectedIndex == 0) // Movimiento
            {
                Movimiento mov = (Movimiento)dgvResultados.SelectedRows[0].DataBoundItem;

                // 🔻 Cargar artículos del movimiento antes de generar PDF
                mov.Articulos = new MovimientoDAO().ObtenerArticulosPorMovimiento(mov.Id);

                if (!string.IsNullOrWhiteSpace(mov.RutaPDF) && System.IO.File.Exists(mov.RutaPDF))
                {
                    System.Diagnostics.Process.Start(mov.RutaPDF);
                }
                else
                {
                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "Archivo PDF|*.pdf",
                        Title = "Guardar Pase",
                        FileName = $"Pase_{mov.Folio}.pdf"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string rutaFinal = saveDialog.FileName;

                        PDFGenerator pdfGen = new PDFGenerator();
                        pdfGen.GenerarPDF(mov, rutaFinal);
                        MessageBox.Show("PDF generado correctamente.");
                        System.Diagnostics.Process.Start(rutaFinal);

                        mov.RutaPDF = rutaFinal;
                        new MovimientoDAO().ActualizarRutaPDF(mov.Folio, rutaFinal);
                    }
                }
            }
            else // Pase de carro
            {
                PaseCarro pase = (PaseCarro)dgvResultados.SelectedRows[0].DataBoundItem;

                if (!string.IsNullOrWhiteSpace(pase.RutaPDF) && System.IO.File.Exists(pase.RutaPDF))
                {
                    System.Diagnostics.Process.Start(pase.RutaPDF);
                }
                else
                {
                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "Archivo PDF|*.pdf",
                        Title = "Guardar Pase de Vehículo",
                        FileName = $"PaseCarro_{pase.Folio}.pdf"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string rutaFinal = saveDialog.FileName;

                        ReporteCarroPDF.ExportarPaseCarro(pase, rutaFinal);
                        MessageBox.Show("PDF generado correctamente.");
                        System.Diagnostics.Process.Start(rutaFinal);

                        pase.RutaPDF = rutaFinal;
                        new PaseCarroDAO().ActualizarRutaPDF(pase.Folio, rutaFinal);
                    }
                }
            }







        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaReportes));
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnReimprimir = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Items.AddRange(new object[] {
            "Movimientos",
            "Pases de Carro"});
            this.comboTipo.Location = new System.Drawing.Point(146, 218);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(213, 21);
            this.comboTipo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "TIPO DE PASE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "BUSCAR POR  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(354, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Folio: ";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(106, 280);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(195, 20);
            this.txtNombre.TabIndex = 5;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtFolio
            // 
            this.txtFolio.Location = new System.Drawing.Point(411, 278);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(195, 20);
            this.txtFolio.TabIndex = 6;
            // 
            // dgvResultados
            // 
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(1, 329);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.RowHeadersWidth = 62;
            this.dgvResultados.RowTemplate.Height = 28;
            this.dgvResultados.Size = new System.Drawing.Size(960, 284);
            this.dgvResultados.TabIndex = 7;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(813, 164);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(134, 48);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReimprimir.Location = new System.Drawing.Point(813, 218);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(134, 48);
            this.btnReimprimir.TabIndex = 9;
            this.btnReimprimir.Text = "Reimprimir";
            this.btnReimprimir.UseVisualStyleBackColor = true;
            this.btnReimprimir.Click += new System.EventHandler(this.btnReimprimir_Click_1);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(813, 272);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(134, 48);
            this.btnRegresar.TabIndex = 10;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(960, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // frmBusquedaReportes
            // 
            this.ClientSize = new System.Drawing.Size(959, 616);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnReimprimir);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboTipo);
            this.Name = "frmBusquedaReportes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close(); // Cierra el formulario actual y regresa al anterior
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}