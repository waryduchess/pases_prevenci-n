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
        private ComboBox cbxBuscar;
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
        private ComboBox comboBox1;
        private Label label3;

        public frmBusquedaReportes()
        {
            InitializeComponent();
            cbxBuscar.SelectedIndex = 0; // Por defecto buscar movimientos
            
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


            if (cbxBuscar.SelectedIndex == 0) // Movimientos
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

            if (cbxBuscar.SelectedIndex == 0) // Movimiento
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
            this.cbxBuscar = new System.Windows.Forms.ComboBox();
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxBuscar
            // 
            this.cbxBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBuscar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBuscar.FormattingEnabled = true;
            this.cbxBuscar.Items.AddRange(new object[] {
            "Movimientos",
            "Pases de Carro"});
            this.cbxBuscar.Location = new System.Drawing.Point(287, 176);
            this.cbxBuscar.Name = "cbxBuscar";
            this.cbxBuscar.Size = new System.Drawing.Size(200, 28);
            this.cbxBuscar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de pase:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buscar por: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Folio: ";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(287, 269);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(195, 27);
            this.txtNombre.TabIndex = 5;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtFolio
            // 
            this.txtFolio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolio.Location = new System.Drawing.Point(287, 269);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(195, 27);
            this.txtFolio.TabIndex = 6;
            // 
            // dgvResultados
            // 
            this.dgvResultados.BackgroundColor = System.Drawing.Color.White;
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
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnReimprimir.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnRegresar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.pictureBox1.Location = new System.Drawing.Point(-1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(962, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "",
            "Nombre",
            "Folio"});
            this.comboBox1.Location = new System.Drawing.Point(287, 222);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 28);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // frmBusquedaReportes
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(959, 616);
            this.Controls.Add(this.comboBox1);
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
            this.Controls.Add(this.cbxBuscar);
            this.Name = "frmBusquedaReportes";
            this.Load += new System.EventHandler(this.frmBusquedaReportes_Load);
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

        private void frmBusquedaReportes_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            txtNombre.Visible = false;
            label4.Visible = false;
            txtFolio.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Nombre")
            {
                label3.Visible = true;
                txtNombre.Visible = true;
                label4.Visible = false;
                txtFolio.Visible = false;
            }
            else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Folio")
            {
                label3.Visible = false;
                txtNombre.Visible = false;
                label4.Visible = true;
                txtFolio.Visible = true;
            }
            else
            {
                label3.Visible = false;
                txtNombre.Visible = false;
                label4.Visible = false;
                txtFolio.Visible = false;
            }
           
        }
    }
}