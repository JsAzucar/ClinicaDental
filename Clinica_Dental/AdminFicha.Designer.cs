namespace Clinica_Dental
{
    partial class AdminFicha
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.btn_buscarNombre = new System.Windows.Forms.Button();
            this.btn_mostrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mask_fecha = new System.Windows.Forms.MaskedTextBox();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.lbpass1 = new System.Windows.Forms.Label();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvFichas = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_ingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lugar_trabajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Informacion_adicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEncargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefonoEncargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EdadEncargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DuiEncargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirecciónEncargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LugarTrEncargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.Contrato1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Contrato2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Contrato3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Contrato4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Radiografia1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Radiografia2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Radiografia3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Radiografia4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Tipo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFichas)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_nombre
            // 
            this.txt_nombre.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.txt_nombre.Location = new System.Drawing.Point(6, 46);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(179, 22);
            this.txt_nombre.TabIndex = 2;
            this.txt_nombre.TextChanged += new System.EventHandler(this.txt_nombre_TextChanged);
            this.txt_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nombre_KeyPress);
            // 
            // btn_buscarNombre
            // 
            this.btn_buscarNombre.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_buscarNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscarNombre.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscarNombre.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_buscarNombre.Location = new System.Drawing.Point(240, 38);
            this.btn_buscarNombre.Name = "btn_buscarNombre";
            this.btn_buscarNombre.Size = new System.Drawing.Size(116, 30);
            this.btn_buscarNombre.TabIndex = 4;
            this.btn_buscarNombre.Text = "Nombre";
            this.btn_buscarNombre.UseVisualStyleBackColor = false;
            this.btn_buscarNombre.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_mostrar
            // 
            this.btn_mostrar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_mostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mostrar.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mostrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_mostrar.Location = new System.Drawing.Point(379, 58);
            this.btn_mostrar.Name = "btn_mostrar";
            this.btn_mostrar.Size = new System.Drawing.Size(116, 30);
            this.btn_mostrar.TabIndex = 5;
            this.btn_mostrar.Text = "Mostrar todo";
            this.btn_mostrar.UseVisualStyleBackColor = false;
            this.btn_mostrar.Click += new System.EventHandler(this.btn_mostrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.mask_fecha);
            this.groupBox1.Controls.Add(this.btn_mostrar);
            this.groupBox1.Controls.Add(this.btn_buscarNombre);
            this.groupBox1.Controls.Add(this.txt_nombre);
            this.groupBox1.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 146);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda de fichas";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(240, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 30);
            this.button1.TabIndex = 58;
            this.button1.Text = "Fecha";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mask_fecha
            // 
            this.mask_fecha.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.mask_fecha.Location = new System.Drawing.Point(6, 88);
            this.mask_fecha.Mask = "00/00/0000";
            this.mask_fecha.Name = "mask_fecha";
            this.mask_fecha.Size = new System.Drawing.Size(179, 22);
            this.mask_fecha.TabIndex = 57;
            this.mask_fecha.Validating += new System.ComponentModel.CancelEventHandler(this.mask_fecha_Validating);
            // 
            // btn_Editar
            // 
            this.btn_Editar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Editar.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Editar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Editar.Location = new System.Drawing.Point(181, 577);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(116, 30);
            this.btn_Editar.TabIndex = 8;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.UseVisualStyleBackColor = false;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_eliminar.Location = new System.Drawing.Point(319, 577);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(116, 30);
            this.btn_eliminar.TabIndex = 9;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // lbpass1
            // 
            this.lbpass1.AutoSize = true;
            this.lbpass1.BackColor = System.Drawing.Color.Transparent;
            this.lbpass1.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpass1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbpass1.Location = new System.Drawing.Point(211, 554);
            this.lbpass1.Name = "lbpass1";
            this.lbpass1.Size = new System.Drawing.Size(64, 20);
            this.lbpass1.TabIndex = 11;
            this.lbpass1.Text = "lbpass1";
            this.lbpass1.Visible = false;
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_actualizar.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_actualizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_actualizar.Location = new System.Drawing.Point(29, 577);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(116, 30);
            this.btn_actualizar.TabIndex = 13;
            this.btn_actualizar.Text = "Cargar";
            this.btn_actualizar.UseVisualStyleBackColor = false;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dgvFichas
            // 
            this.dgvFichas.AllowUserToAddRows = false;
            this.dgvFichas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvFichas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvFichas.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvFichas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFichas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFichas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFichas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nombre,
            this.Telefono,
            this.Telefono2,
            this.Fecha_ingreso,
            this.Direccion,
            this.Edad,
            this.Dui,
            this.Email,
            this.Lugar_trabajo,
            this.Informacion_adicional,
            this.Monto,
            this.NombreEncargado,
            this.TelefonoEncargado,
            this.EdadEncargado,
            this.DuiEncargado,
            this.DirecciónEncargado,
            this.LugarTrEncargado,
            this.Imagen,
            this.Contrato1,
            this.Contrato2,
            this.Contrato3,
            this.Contrato4,
            this.Radiografia1,
            this.Radiografia2,
            this.Radiografia3,
            this.Radiografia4});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFichas.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFichas.EnableHeadersVisualStyles = false;
            this.dgvFichas.Location = new System.Drawing.Point(23, 196);
            this.dgvFichas.Name = "dgvFichas";
            this.dgvFichas.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFichas.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFichas.Size = new System.Drawing.Size(963, 337);
            this.dgvFichas.TabIndex = 49;
            this.dgvFichas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFichas_CellContentClick_1);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 46;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 86;
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "Telefono";
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 87;
            // 
            // Telefono2
            // 
            this.Telefono2.DataPropertyName = "Telefono2";
            this.Telefono2.HeaderText = "Telefono2";
            this.Telefono2.Name = "Telefono2";
            this.Telefono2.ReadOnly = true;
            this.Telefono2.Width = 94;
            // 
            // Fecha_ingreso
            // 
            this.Fecha_ingreso.DataPropertyName = "Fecha_ingreso";
            this.Fecha_ingreso.HeaderText = "Fecha_ingreso";
            this.Fecha_ingreso.Name = "Fecha_ingreso";
            this.Fecha_ingreso.ReadOnly = true;
            this.Fecha_ingreso.Width = 125;
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "Direccion";
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 94;
            // 
            // Edad
            // 
            this.Edad.DataPropertyName = "Edad";
            this.Edad.HeaderText = "Edad";
            this.Edad.Name = "Edad";
            this.Edad.ReadOnly = true;
            this.Edad.Width = 67;
            // 
            // Dui
            // 
            this.Dui.DataPropertyName = "Dui";
            this.Dui.HeaderText = "Dui";
            this.Dui.Name = "Dui";
            this.Dui.ReadOnly = true;
            this.Dui.Width = 54;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 68;
            // 
            // Lugar_trabajo
            // 
            this.Lugar_trabajo.DataPropertyName = "Lugar_trabajo";
            this.Lugar_trabajo.HeaderText = "Lugar_trabajo";
            this.Lugar_trabajo.Name = "Lugar_trabajo";
            this.Lugar_trabajo.ReadOnly = true;
            this.Lugar_trabajo.Width = 124;
            // 
            // Informacion_adicional
            // 
            this.Informacion_adicional.DataPropertyName = "Informacion_adicional";
            this.Informacion_adicional.HeaderText = "Informacion_adicional";
            this.Informacion_adicional.Name = "Informacion_adicional";
            this.Informacion_adicional.ReadOnly = true;
            this.Informacion_adicional.Width = 179;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 75;
            // 
            // NombreEncargado
            // 
            this.NombreEncargado.DataPropertyName = "NombreEncargado";
            this.NombreEncargado.HeaderText = "NombreEncargado";
            this.NombreEncargado.Name = "NombreEncargado";
            this.NombreEncargado.ReadOnly = true;
            this.NombreEncargado.Width = 158;
            // 
            // TelefonoEncargado
            // 
            this.TelefonoEncargado.DataPropertyName = "TelefonoEncargado";
            this.TelefonoEncargado.HeaderText = "TelefonoEncargado";
            this.TelefonoEncargado.Name = "TelefonoEncargado";
            this.TelefonoEncargado.ReadOnly = true;
            this.TelefonoEncargado.Width = 159;
            // 
            // EdadEncargado
            // 
            this.EdadEncargado.DataPropertyName = "EdadEncargado";
            this.EdadEncargado.HeaderText = "EdadEncargado";
            this.EdadEncargado.Name = "EdadEncargado";
            this.EdadEncargado.ReadOnly = true;
            this.EdadEncargado.Width = 139;
            // 
            // DuiEncargado
            // 
            this.DuiEncargado.DataPropertyName = "DuiEncargado";
            this.DuiEncargado.HeaderText = "DuiEncargado";
            this.DuiEncargado.Name = "DuiEncargado";
            this.DuiEncargado.ReadOnly = true;
            this.DuiEncargado.Width = 126;
            // 
            // DirecciónEncargado
            // 
            this.DirecciónEncargado.DataPropertyName = "DirecciónEncargado";
            this.DirecciónEncargado.HeaderText = "DirecciónEncargado";
            this.DirecciónEncargado.Name = "DirecciónEncargado";
            this.DirecciónEncargado.ReadOnly = true;
            this.DirecciónEncargado.Width = 166;
            // 
            // LugarTrEncargado
            // 
            this.LugarTrEncargado.DataPropertyName = "LugarTrEncargado";
            this.LugarTrEncargado.HeaderText = "LugarTrEncargado";
            this.LugarTrEncargado.Name = "LugarTrEncargado";
            this.LugarTrEncargado.ReadOnly = true;
            this.LugarTrEncargado.Width = 150;
            // 
            // Imagen
            // 
            this.Imagen.DataPropertyName = "Imagen";
            this.Imagen.HeaderText = "Imagen";
            this.Imagen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Imagen.Name = "Imagen";
            this.Imagen.ReadOnly = true;
            this.Imagen.Width = 64;
            // 
            // Contrato1
            // 
            this.Contrato1.DataPropertyName = "Contrato1";
            this.Contrato1.HeaderText = "Contrato1";
            this.Contrato1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Contrato1.Name = "Contrato1";
            this.Contrato1.ReadOnly = true;
            this.Contrato1.Width = 81;
            // 
            // Contrato2
            // 
            this.Contrato2.DataPropertyName = "Contrato2";
            this.Contrato2.HeaderText = "Contrato2";
            this.Contrato2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Contrato2.Name = "Contrato2";
            this.Contrato2.ReadOnly = true;
            this.Contrato2.Width = 81;
            // 
            // Contrato3
            // 
            this.Contrato3.DataPropertyName = "Contrato3";
            this.Contrato3.HeaderText = "Contrato3";
            this.Contrato3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Contrato3.Name = "Contrato3";
            this.Contrato3.ReadOnly = true;
            this.Contrato3.Width = 81;
            // 
            // Contrato4
            // 
            this.Contrato4.DataPropertyName = "Contrato4";
            this.Contrato4.HeaderText = "Contrato4";
            this.Contrato4.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Contrato4.Name = "Contrato4";
            this.Contrato4.ReadOnly = true;
            this.Contrato4.Width = 81;
            // 
            // Radiografia1
            // 
            this.Radiografia1.DataPropertyName = "Radiografia1";
            this.Radiografia1.HeaderText = "Radiografia1";
            this.Radiografia1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Radiografia1.Name = "Radiografia1";
            this.Radiografia1.ReadOnly = true;
            this.Radiografia1.Width = 97;
            // 
            // Radiografia2
            // 
            this.Radiografia2.DataPropertyName = "Radiografia2";
            this.Radiografia2.HeaderText = "Radiografia2";
            this.Radiografia2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Radiografia2.Name = "Radiografia2";
            this.Radiografia2.ReadOnly = true;
            this.Radiografia2.Width = 97;
            // 
            // Radiografia3
            // 
            this.Radiografia3.DataPropertyName = "Radiografia3";
            this.Radiografia3.HeaderText = "Radiografia3";
            this.Radiografia3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Radiografia3.Name = "Radiografia3";
            this.Radiografia3.ReadOnly = true;
            this.Radiografia3.Width = 97;
            // 
            // Radiografia4
            // 
            this.Radiografia4.DataPropertyName = "Radiografia4";
            this.Radiografia4.HeaderText = "Radiografia4";
            this.Radiografia4.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Radiografia4.Name = "Radiografia4";
            this.Radiografia4.ReadOnly = true;
            this.Radiografia4.Width = 97;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(850, 653);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 30);
            this.button2.TabIndex = 50;
            this.button2.Text = "Eliminar Todo";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Tipo
            // 
            this.Tipo.AutoSize = true;
            this.Tipo.Location = new System.Drawing.Point(773, 670);
            this.Tipo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(35, 13);
            this.Tipo.TabIndex = 51;
            this.Tipo.Text = "label1";
            this.Tipo.Visible = false;
            // 
            // AdminFicha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = global::Clinica_Dental.Properties.Resources.degradados_wallpapers_6;
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.Tipo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvFichas);
            this.Controls.Add(this.btn_actualizar);
            this.Controls.Add(this.lbpass1);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminFicha";
            this.Text = "AdminFicha";
            this.Load += new System.EventHandler(this.AdminFicha_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFichas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Button btn_buscarNombre;
        private System.Windows.Forms.Button btn_mostrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_eliminar;
        public System.Windows.Forms.Label lbpass1;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.MaskedTextBox mask_fecha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvFichas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_ingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dui;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lugar_trabajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Informacion_adicional;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEncargado;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelefonoEncargado;
        private System.Windows.Forms.DataGridViewTextBoxColumn EdadEncargado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuiEncargado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirecciónEncargado;
        private System.Windows.Forms.DataGridViewTextBoxColumn LugarTrEncargado;
        private System.Windows.Forms.DataGridViewImageColumn Imagen;
        private System.Windows.Forms.DataGridViewImageColumn Contrato1;
        private System.Windows.Forms.DataGridViewImageColumn Contrato2;
        private System.Windows.Forms.DataGridViewImageColumn Contrato3;
        private System.Windows.Forms.DataGridViewImageColumn Contrato4;
        private System.Windows.Forms.DataGridViewImageColumn Radiografia1;
        private System.Windows.Forms.DataGridViewImageColumn Radiografia2;
        private System.Windows.Forms.DataGridViewImageColumn Radiografia3;
        private System.Windows.Forms.DataGridViewImageColumn Radiografia4;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label Tipo;
    }
}