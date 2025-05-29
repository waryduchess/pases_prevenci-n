namespace PASE.Vistas
{
    partial class frmCarros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textFolio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textPlacas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textMarca = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textModelo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textColor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFirmaSeguridad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textConductor = new System.Windows.Forms.TextBox();
            this.btnGuardarDatos = new System.Windows.Forms.Button();
            this.btnGenerarPDF = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textMotivo = new System.Windows.Forms.TextBox();
            this.Regresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textFolio
            // 
            this.textFolio.Location = new System.Drawing.Point(476, 29);
            this.textFolio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textFolio.Name = "textFolio";
            this.textFolio.Size = new System.Drawing.Size(116, 20);
            this.textFolio.TabIndex = 0;
            this.textFolio.TextChanged += new System.EventHandler(this.textFolio_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(427, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Placas del vehiculo";
            // 
            // textPlacas
            // 
            this.textPlacas.Location = new System.Drawing.Point(175, 134);
            this.textPlacas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textPlacas.Name = "textPlacas";
            this.textPlacas.Size = new System.Drawing.Size(116, 20);
            this.textPlacas.TabIndex = 2;
            this.textPlacas.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 164);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Marca";
            // 
            // textMarca
            // 
            this.textMarca.Location = new System.Drawing.Point(87, 166);
            this.textMarca.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textMarca.Name = "textMarca";
            this.textMarca.Size = new System.Drawing.Size(204, 20);
            this.textMarca.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 198);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Modelo";
            // 
            // textModelo
            // 
            this.textModelo.Location = new System.Drawing.Point(98, 201);
            this.textModelo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textModelo.Name = "textModelo";
            this.textModelo.Size = new System.Drawing.Size(193, 20);
            this.textModelo.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 235);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Color";
            // 
            // textColor
            // 
            this.textColor.Location = new System.Drawing.Point(87, 238);
            this.textColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textColor.Name = "textColor";
            this.textColor.Size = new System.Drawing.Size(204, 20);
            this.textColor.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 264);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(233, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nombre y Firma de seguridad";
            // 
            // txtFirmaSeguridad
            // 
            this.txtFirmaSeguridad.Location = new System.Drawing.Point(31, 293);
            this.txtFirmaSeguridad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFirmaSeguridad.Name = "txtFirmaSeguridad";
            this.txtFirmaSeguridad.Size = new System.Drawing.Size(259, 20);
            this.txtFirmaSeguridad.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 73);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "Nombre Conductor";
            // 
            // textConductor
            // 
            this.textConductor.Location = new System.Drawing.Point(29, 94);
            this.textConductor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textConductor.Name = "textConductor";
            this.textConductor.Size = new System.Drawing.Size(261, 20);
            this.textConductor.TabIndex = 12;
            // 
            // btnGuardarDatos
            // 
            this.btnGuardarDatos.Location = new System.Drawing.Point(366, 244);
            this.btnGuardarDatos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardarDatos.Name = "btnGuardarDatos";
            this.btnGuardarDatos.Size = new System.Drawing.Size(109, 33);
            this.btnGuardarDatos.TabIndex = 14;
            this.btnGuardarDatos.Text = "Guardar Datos";
            this.btnGuardarDatos.UseVisualStyleBackColor = true;
            this.btnGuardarDatos.Click += new System.EventHandler(this.btnGuardarDatos_Click);
            // 
            // btnGenerarPDF
            // 
            this.btnGenerarPDF.Location = new System.Drawing.Point(555, 244);
            this.btnGenerarPDF.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerarPDF.Name = "btnGenerarPDF";
            this.btnGenerarPDF.Size = new System.Drawing.Size(109, 33);
            this.btnGenerarPDF.TabIndex = 15;
            this.btnGenerarPDF.Text = "Generar PDF";
            this.btnGenerarPDF.UseVisualStyleBackColor = true;
            this.btnGenerarPDF.Click += new System.EventHandler(this.btnGenerarPDF_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(361, 73);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "Motivo";
            // 
            // textMotivo
            // 
            this.textMotivo.Location = new System.Drawing.Point(366, 104);
            this.textMotivo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textMotivo.Name = "textMotivo";
            this.textMotivo.Size = new System.Drawing.Size(272, 20);
            this.textMotivo.TabIndex = 18;
            // 
            // Regresar
            // 
            this.Regresar.Location = new System.Drawing.Point(462, 285);
            this.Regresar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Regresar.Name = "Regresar";
            this.Regresar.Size = new System.Drawing.Size(109, 33);
            this.Regresar.TabIndex = 19;
            this.Regresar.Text = "Regresar";
            this.Regresar.UseVisualStyleBackColor = true;
            this.Regresar.Click += new System.EventHandler(this.Regresar_Click);
            // 
            // frmCarros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 337);
            this.Controls.Add(this.Regresar);
            this.Controls.Add(this.textMotivo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnGenerarPDF);
            this.Controls.Add(this.btnGuardarDatos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textConductor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFirmaSeguridad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textModelo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textMarca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textPlacas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textFolio);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmCarros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCarros";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textFolio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPlacas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textMarca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textModelo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFirmaSeguridad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textConductor;
        private System.Windows.Forms.Button btnGuardarDatos;
        private System.Windows.Forms.Button btnGenerarPDF;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textMotivo;
        private System.Windows.Forms.Button Regresar;
    }
}