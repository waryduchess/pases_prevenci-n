namespace PASE
{
    partial class frmArticulos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArticulos));
            this.label1 = new System.Windows.Forms.Label();
            this.labelHotel = new System.Windows.Forms.Label();
            this.labeFolio = new System.Windows.Forms.Label();
            this.textFolio = new System.Windows.Forms.TextBox();
            this.GroupEntradaSalida = new System.Windows.Forms.GroupBox();
            this.SalidaconDevolucion = new System.Windows.Forms.RadioButton();
            this.Entrada = new System.Windows.Forms.RadioButton();
            this.SalidaDefinitiva = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Salida = new System.Windows.Forms.DateTimePicker();
            this.Regreso = new System.Windows.Forms.DateTimePicker();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numeroPaquetes = new System.Windows.Forms.NumericUpDown();
            this.textArticulo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.GroupTipo = new System.Windows.Forms.GroupBox();
            this.Huespedes = new System.Windows.Forms.RadioButton();
            this.Proveedores = new System.Windows.Forms.RadioButton();
            this.Empleado = new System.Windows.Forms.RadioButton();
            this.Contratista = new System.Windows.Forms.RadioButton();
            this.textDepartamento = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textNombreSeguridad = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.MostrarArticulos = new System.Windows.Forms.DataGridView();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.Regresar = new System.Windows.Forms.Button();
            this.cbxNmbreHotel = new System.Windows.Forms.ComboBox();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colNombreArticulo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDescripcionArticulo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GroupEntradaSalida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeroPaquetes)).BeginInit();
            this.GroupTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MostrarArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(169)))), ((int)(((byte)(82)))));
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pase De Artículos";
            // 
            // labelHotel
            // 
            this.labelHotel.AutoSize = true;
            this.labelHotel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHotel.ForeColor = System.Drawing.Color.Black;
            this.labelHotel.Location = new System.Drawing.Point(44, 84);
            this.labelHotel.Name = "labelHotel";
            this.labelHotel.Size = new System.Drawing.Size(67, 23);
            this.labelHotel.TabIndex = 3;
            this.labelHotel.Text = "Hotel:";
            // 
            // labeFolio
            // 
            this.labeFolio.AutoSize = true;
            this.labeFolio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeFolio.ForeColor = System.Drawing.Color.Black;
            this.labeFolio.Location = new System.Drawing.Point(928, 33);
            this.labeFolio.Name = "labeFolio";
            this.labeFolio.Size = new System.Drawing.Size(59, 23);
            this.labeFolio.TabIndex = 1;
            this.labeFolio.Text = "Folio:";
            // 
            // textFolio
            // 
            this.textFolio.Enabled = false;
            this.textFolio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFolio.Location = new System.Drawing.Point(996, 25);
            this.textFolio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textFolio.Multiline = true;
            this.textFolio.Name = "textFolio";
            this.textFolio.Size = new System.Drawing.Size(191, 32);
            this.textFolio.TabIndex = 2;
            this.textFolio.TextChanged += new System.EventHandler(this.textFolio_TextChanged);
            // 
            // GroupEntradaSalida
            // 
            this.GroupEntradaSalida.Controls.Add(this.SalidaconDevolucion);
            this.GroupEntradaSalida.Controls.Add(this.Entrada);
            this.GroupEntradaSalida.Controls.Add(this.SalidaDefinitiva);
            this.GroupEntradaSalida.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupEntradaSalida.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GroupEntradaSalida.Location = new System.Drawing.Point(47, 130);
            this.GroupEntradaSalida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupEntradaSalida.Name = "GroupEntradaSalida";
            this.GroupEntradaSalida.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupEntradaSalida.Size = new System.Drawing.Size(516, 57);
            this.GroupEntradaSalida.TabIndex = 5;
            this.GroupEntradaSalida.TabStop = false;
            // 
            // SalidaconDevolucion
            // 
            this.SalidaconDevolucion.AutoSize = true;
            this.SalidaconDevolucion.Location = new System.Drawing.Point(305, 21);
            this.SalidaconDevolucion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SalidaconDevolucion.Name = "SalidaconDevolucion";
            this.SalidaconDevolucion.Size = new System.Drawing.Size(175, 21);
            this.SalidaconDevolucion.TabIndex = 2;
            this.SalidaconDevolucion.TabStop = true;
            this.SalidaconDevolucion.Text = "Salida con Devolución";
            this.SalidaconDevolucion.UseVisualStyleBackColor = true;
            // 
            // Entrada
            // 
            this.Entrada.AutoSize = true;
            this.Entrada.Location = new System.Drawing.Point(187, 21);
            this.Entrada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Entrada.Name = "Entrada";
            this.Entrada.Size = new System.Drawing.Size(80, 21);
            this.Entrada.TabIndex = 1;
            this.Entrada.TabStop = true;
            this.Entrada.Text = "Entrada";
            this.Entrada.UseVisualStyleBackColor = true;
            // 
            // SalidaDefinitiva
            // 
            this.SalidaDefinitiva.AutoSize = true;
            this.SalidaDefinitiva.Location = new System.Drawing.Point(20, 21);
            this.SalidaDefinitiva.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SalidaDefinitiva.Name = "SalidaDefinitiva";
            this.SalidaDefinitiva.Size = new System.Drawing.Size(133, 21);
            this.SalidaDefinitiva.TabIndex = 0;
            this.SalidaDefinitiva.TabStop = true;
            this.SalidaDefinitiva.Text = "Salida Definitiva";
            this.SalidaDefinitiva.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(37, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha de Salida:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(557, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha de Regreso:";
            // 
            // Salida
            // 
            this.Salida.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salida.Location = new System.Drawing.Point(227, 208);
            this.Salida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Salida.Name = "Salida";
            this.Salida.Size = new System.Drawing.Size(289, 32);
            this.Salida.TabIndex = 7;
            // 
            // Regreso
            // 
            this.Regreso.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Regreso.Location = new System.Drawing.Point(767, 208);
            this.Regreso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Regreso.Name = "Regreso";
            this.Regreso.Size = new System.Drawing.Size(287, 32);
            this.Regreso.TabIndex = 9;
            // 
            // textNombre
            // 
            this.textNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombre.Location = new System.Drawing.Point(141, 272);
            this.textNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textNombre.Multiline = true;
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(321, 32);
            this.textNombre.TabIndex = 11;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.ForeColor = System.Drawing.Color.Black;
            this.labelNombre.Location = new System.Drawing.Point(35, 281);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(95, 23);
            this.labelNombre.TabIndex = 10;
            this.labelNombre.Text = "Nombre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(477, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "No.de Paquetes:";
            // 
            // numeroPaquetes
            // 
            this.numeroPaquetes.Enabled = false;
            this.numeroPaquetes.Location = new System.Drawing.Point(664, 284);
            this.numeroPaquetes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numeroPaquetes.Name = "numeroPaquetes";
            this.numeroPaquetes.Size = new System.Drawing.Size(107, 22);
            this.numeroPaquetes.TabIndex = 13;
            // 
            // textArticulo
            // 
            this.textArticulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textArticulo.Location = new System.Drawing.Point(133, 335);
            this.textArticulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textArticulo.Multiline = true;
            this.textArticulo.Name = "textArticulo";
            this.textArticulo.Size = new System.Drawing.Size(255, 32);
            this.textArticulo.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(29, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Artículo:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textDescripcion
            // 
            this.textDescripcion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDescripcion.Location = new System.Drawing.Point(547, 336);
            this.textDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textDescripcion.Multiline = true;
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(255, 32);
            this.textDescripcion.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(404, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "Descripción:";
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.BackColor = System.Drawing.Color.White;
            this.buttonAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAgregar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregar.Location = new System.Drawing.Point(839, 310);
            this.buttonAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(199, 59);
            this.buttonAgregar.TabIndex = 18;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = false;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // GroupTipo
            // 
            this.GroupTipo.Controls.Add(this.Huespedes);
            this.GroupTipo.Controls.Add(this.Proveedores);
            this.GroupTipo.Controls.Add(this.Empleado);
            this.GroupTipo.Controls.Add(this.Contratista);
            this.GroupTipo.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupTipo.Location = new System.Drawing.Point(47, 402);
            this.GroupTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupTipo.Name = "GroupTipo";
            this.GroupTipo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupTipo.Size = new System.Drawing.Size(647, 42);
            this.GroupTipo.TabIndex = 20;
            this.GroupTipo.TabStop = false;
            this.GroupTipo.Enter += new System.EventHandler(this.GroupTipo_Enter);
            // 
            // Huespedes
            // 
            this.Huespedes.AutoSize = true;
            this.Huespedes.Location = new System.Drawing.Point(497, 10);
            this.Huespedes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Huespedes.Name = "Huespedes";
            this.Huespedes.Size = new System.Drawing.Size(120, 21);
            this.Huespedes.TabIndex = 22;
            this.Huespedes.TabStop = true;
            this.Huespedes.Text = "De Huéspedes";
            this.Huespedes.UseVisualStyleBackColor = true;
            this.Huespedes.CheckedChanged += new System.EventHandler(this.Huespedes_CheckedChanged);
            // 
            // Proveedores
            // 
            this.Proveedores.AutoSize = true;
            this.Proveedores.Location = new System.Drawing.Point(324, 10);
            this.Proveedores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Proveedores.Name = "Proveedores";
            this.Proveedores.Size = new System.Drawing.Size(131, 21);
            this.Proveedores.TabIndex = 2;
            this.Proveedores.TabStop = true;
            this.Proveedores.Text = "De Proveedores";
            this.Proveedores.UseVisualStyleBackColor = true;
            // 
            // Empleado
            // 
            this.Empleado.AutoSize = true;
            this.Empleado.Location = new System.Drawing.Point(167, 10);
            this.Empleado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Empleado.Name = "Empleado";
            this.Empleado.Size = new System.Drawing.Size(118, 21);
            this.Empleado.TabIndex = 1;
            this.Empleado.TabStop = true;
            this.Empleado.Text = "De Empleado";
            this.Empleado.UseVisualStyleBackColor = true;
            // 
            // Contratista
            // 
            this.Contratista.AutoSize = true;
            this.Contratista.Location = new System.Drawing.Point(13, 10);
            this.Contratista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Contratista.Name = "Contratista";
            this.Contratista.Size = new System.Drawing.Size(124, 21);
            this.Contratista.TabIndex = 0;
            this.Contratista.TabStop = true;
            this.Contratista.Text = "De Contratista";
            this.Contratista.UseVisualStyleBackColor = true;
            // 
            // textDepartamento
            // 
            this.textDepartamento.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDepartamento.Location = new System.Drawing.Point(208, 465);
            this.textDepartamento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textDepartamento.Multiline = true;
            this.textDepartamento.Name = "textDepartamento";
            this.textDepartamento.Size = new System.Drawing.Size(353, 32);
            this.textDepartamento.TabIndex = 22;
            this.textDepartamento.TextChanged += new System.EventHandler(this.textDepartamento_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(27, 474);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 23);
            this.label8.TabIndex = 21;
            this.label8.Text = "Departamento:";
            // 
            // textNombreSeguridad
            // 
            this.textNombreSeguridad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombreSeguridad.Location = new System.Drawing.Point(133, 587);
            this.textNombreSeguridad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textNombreSeguridad.Multiline = true;
            this.textNombreSeguridad.Name = "textNombreSeguridad";
            this.textNombreSeguridad.Size = new System.Drawing.Size(371, 32);
            this.textNombreSeguridad.TabIndex = 24;
            this.textNombreSeguridad.TextChanged += new System.EventHandler(this.textNombreSeguridad_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(180, 535);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(275, 23);
            this.label10.TabIndex = 23;
            this.label10.Text = "Nombre y Firma Seguridad:";
            // 
            // MostrarArticulos
            // 
            this.MostrarArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MostrarArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MostrarArticulos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.MostrarArticulos.BackgroundColor = System.Drawing.Color.White;
            this.MostrarArticulos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.MostrarArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MostrarArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombreArticulo,
            this.colDescripcionArticulo});
            this.MostrarArticulos.Location = new System.Drawing.Point(47, 378);
            this.MostrarArticulos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MostrarArticulos.Name = "MostrarArticulos";
            this.MostrarArticulos.RowHeadersWidth = 62;
            this.MostrarArticulos.RowTemplate.Height = 28;
            this.MostrarArticulos.Size = new System.Drawing.Size(1185, 283);
            this.MostrarArticulos.TabIndex = 27;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.AutoSize = true;
            this.buttonGuardar.BackColor = System.Drawing.Color.White;
            this.buttonGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonGuardar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardar.Location = new System.Drawing.Point(729, 587);
            this.buttonGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(199, 59);
            this.buttonGuardar.TabIndex = 25;
            this.buttonGuardar.Text = "Guardar Datos";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // Regresar
            // 
            this.Regresar.AutoSize = true;
            this.Regresar.BackColor = System.Drawing.Color.White;
            this.Regresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Regresar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Regresar.Location = new System.Drawing.Point(996, 587);
            this.Regresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Regresar.Name = "Regresar";
            this.Regresar.Size = new System.Drawing.Size(179, 59);
            this.Regresar.TabIndex = 26;
            this.Regresar.Text = "Regresar";
            this.Regresar.UseVisualStyleBackColor = false;
            this.Regresar.Click += new System.EventHandler(this.Regresar_Click);
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
            this.cbxNmbreHotel.Location = new System.Drawing.Point(123, 74);
            this.cbxNmbreHotel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxNmbreHotel.Name = "cbxNmbreHotel";
            this.cbxNmbreHotel.Size = new System.Drawing.Size(221, 31);
            this.cbxNmbreHotel.TabIndex = 4;
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.White;
            this.btnContinuar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnContinuar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.Location = new System.Drawing.Point(1053, 310);
            this.btnContinuar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(199, 59);
            this.btnContinuar.TabIndex = 19;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1277, 661);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // colNombreArticulo
            // 
            this.colNombreArticulo.FillWeight = 39.57219F;
            this.colNombreArticulo.HeaderText = "Artículo";
            this.colNombreArticulo.MinimumWidth = 8;
            this.colNombreArticulo.Name = "colNombreArticulo";
            // 
            // colDescripcionArticulo
            // 
            this.colDescripcionArticulo.FillWeight = 160.4278F;
            this.colDescripcionArticulo.HeaderText = "Descripción";
            this.colDescripcionArticulo.MinimumWidth = 8;
            this.colDescripcionArticulo.Name = "colDescripcionArticulo";
            // 
            // frmArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1277, 661);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.cbxNmbreHotel);
            this.Controls.Add(this.Regresar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.textNombreSeguridad);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textDepartamento);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.GroupTipo);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.textDescripcion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textArticulo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numeroPaquetes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.Regreso);
            this.Controls.Add(this.Salida);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GroupEntradaSalida);
            this.Controls.Add(this.textFolio);
            this.Controls.Add(this.labeFolio);
            this.Controls.Add(this.labelHotel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MostrarArticulos);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pase Artículos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupEntradaSalida.ResumeLayout(false);
            this.GroupEntradaSalida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeroPaquetes)).EndInit();
            this.GroupTipo.ResumeLayout(false);
            this.GroupTipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MostrarArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelHotel;
        private System.Windows.Forms.Label labeFolio;
        private System.Windows.Forms.TextBox textFolio;
        private System.Windows.Forms.GroupBox GroupEntradaSalida;
        private System.Windows.Forms.RadioButton SalidaDefinitiva;
        private System.Windows.Forms.RadioButton SalidaconDevolucion;
        private System.Windows.Forms.RadioButton Entrada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker Salida;
        private System.Windows.Forms.DateTimePicker Regreso;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numeroPaquetes;
        private System.Windows.Forms.TextBox textArticulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.GroupBox GroupTipo;
        private System.Windows.Forms.RadioButton Huespedes;
        private System.Windows.Forms.RadioButton Proveedores;
        private System.Windows.Forms.RadioButton Empleado;
        private System.Windows.Forms.RadioButton Contratista;
        private System.Windows.Forms.TextBox textDepartamento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textNombreSeguridad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView MostrarArticulos;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button Regresar;
        private System.Windows.Forms.ComboBox cbxNmbreHotel;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewButtonColumn colNombreArticulo;
        private System.Windows.Forms.DataGridViewButtonColumn colDescripcionArticulo;
    }
}

