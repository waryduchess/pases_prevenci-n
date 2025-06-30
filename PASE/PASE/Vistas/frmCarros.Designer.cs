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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarros));
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
            this.label8 = new System.Windows.Forms.Label();
            this.textMotivo = new System.Windows.Forms.TextBox();
            this.Regresar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbxNmbreHotel = new System.Windows.Forms.ComboBox();
            this.labelHotel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textFolio
            // 
            this.textFolio.Enabled = false;
            this.textFolio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFolio.Location = new System.Drawing.Point(733, 11);
            this.textFolio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textFolio.Name = "textFolio";
            this.textFolio.Size = new System.Drawing.Size(191, 32);
            this.textFolio.TabIndex = 1;
            this.textFolio.TextChanged += new System.EventHandler(this.textFolio_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(669, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Placas del vehículo:";
            // 
            // textPlacas
            // 
            this.textPlacas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPlacas.Location = new System.Drawing.Point(259, 154);
            this.textPlacas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textPlacas.Name = "textPlacas";
            this.textPlacas.Size = new System.Drawing.Size(153, 32);
            this.textPlacas.TabIndex = 5;
            this.textPlacas.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(429, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Marca: ";
            // 
            // textMarca
            // 
            this.textMarca.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMarca.Location = new System.Drawing.Point(528, 202);
            this.textMarca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textMarca.Name = "textMarca";
            this.textMarca.Size = new System.Drawing.Size(271, 32);
            this.textMarca.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Modelo:";
            // 
            // textModelo
            // 
            this.textModelo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textModelo.Location = new System.Drawing.Point(140, 202);
            this.textModelo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textModelo.Name = "textModelo";
            this.textModelo.Size = new System.Drawing.Size(256, 32);
            this.textModelo.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Color:";
            // 
            // textColor
            // 
            this.textColor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textColor.Location = new System.Drawing.Point(111, 254);
            this.textColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textColor.Name = "textColor";
            this.textColor.Size = new System.Drawing.Size(271, 32);
            this.textColor.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(301, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Nombre y Firma de seguridad";
            // 
            // txtFirmaSeguridad
            // 
            this.txtFirmaSeguridad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirmaSeguridad.Location = new System.Drawing.Point(24, 390);
            this.txtFirmaSeguridad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFirmaSeguridad.Name = "txtFirmaSeguridad";
            this.txtFirmaSeguridad.Size = new System.Drawing.Size(344, 32);
            this.txtFirmaSeguridad.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(37, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 23);
            this.label7.TabIndex = 2;
            this.label7.Text = "Nombre Conductor: ";
            // 
            // textConductor
            // 
            this.textConductor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textConductor.Location = new System.Drawing.Point(271, 107);
            this.textConductor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textConductor.Name = "textConductor";
            this.textConductor.Size = new System.Drawing.Size(347, 32);
            this.textConductor.TabIndex = 3;
            this.textConductor.TextChanged += new System.EventHandler(this.textConductor_TextChanged);
            // 
            // btnGuardarDatos
            // 
            this.btnGuardarDatos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarDatos.Location = new System.Drawing.Point(528, 390);
            this.btnGuardarDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardarDatos.Name = "btnGuardarDatos";
            this.btnGuardarDatos.Size = new System.Drawing.Size(199, 59);
            this.btnGuardarDatos.TabIndex = 16;
            this.btnGuardarDatos.Text = "Guardar Datos";
            this.btnGuardarDatos.UseVisualStyleBackColor = true;
            this.btnGuardarDatos.Click += new System.EventHandler(this.btnGuardarDatos_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(429, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 23);
            this.label8.TabIndex = 12;
            this.label8.Text = "Motivo:";
            // 
            // textMotivo
            // 
            this.textMotivo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMotivo.Location = new System.Drawing.Point(517, 254);
            this.textMotivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textMotivo.Name = "textMotivo";
            this.textMotivo.Size = new System.Drawing.Size(361, 32);
            this.textMotivo.TabIndex = 13;
            // 
            // Regresar
            // 
            this.Regresar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Regresar.Location = new System.Drawing.Point(747, 390);
            this.Regresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Regresar.Name = "Regresar";
            this.Regresar.Size = new System.Drawing.Size(179, 59);
            this.Regresar.TabIndex = 18;
            this.Regresar.Text = "Regresar";
            this.Regresar.UseVisualStyleBackColor = true;
            this.Regresar.Click += new System.EventHandler(this.Regresar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(936, 465);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // cbxNmbreHotel
            // 
            this.cbxNmbreHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNmbreHotel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNmbreHotel.FormattingEnabled = true;
            this.cbxNmbreHotel.Items.AddRange(new object[] {
            "Excellence PM",
            "Finest PM",
            "Beloved PM"});
            this.cbxNmbreHotel.Location = new System.Drawing.Point(116, 63);
            this.cbxNmbreHotel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxNmbreHotel.Name = "cbxNmbreHotel";
            this.cbxNmbreHotel.Size = new System.Drawing.Size(221, 31);
            this.cbxNmbreHotel.TabIndex = 37;
            // 
            // labelHotel
            // 
            this.labelHotel.AutoSize = true;
            this.labelHotel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHotel.ForeColor = System.Drawing.Color.Black;
            this.labelHotel.Location = new System.Drawing.Point(36, 73);
            this.labelHotel.Name = "labelHotel";
            this.labelHotel.Size = new System.Drawing.Size(67, 23);
            this.labelHotel.TabIndex = 36;
            this.labelHotel.Text = "Hotel:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(169)))), ((int)(((byte)(82)))));
            this.label9.Location = new System.Drawing.Point(35, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(310, 40);
            this.label9.TabIndex = 38;
            this.label9.Text = "Pase De Vehículos";
            // 
            // frmCarros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(936, 465);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxNmbreHotel);
            this.Controls.Add(this.labelHotel);
            this.Controls.Add(this.Regresar);
            this.Controls.Add(this.textMotivo);
            this.Controls.Add(this.label8);
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
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCarros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pase Vehículos";
            this.Load += new System.EventHandler(this.frmCarros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textMotivo;
        private System.Windows.Forms.Button Regresar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbxNmbreHotel;
        private System.Windows.Forms.Label labelHotel;
        private System.Windows.Forms.Label label9;
    }
}