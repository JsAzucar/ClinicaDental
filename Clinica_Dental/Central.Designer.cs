namespace Clinica_Dental
{
    partial class Central
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_tiempo = new System.Windows.Forms.Label();
            this.lbl_fecha = new System.Windows.Forms.Label();
            this.TiempoFecha = new System.Windows.Forms.Timer(this.components);
            this.DataClient = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teléfono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Consulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inicia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Finaliza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Justificación = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataClient)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_tiempo
            // 
            this.lbl_tiempo.AutoSize = true;
            this.lbl_tiempo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_tiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tiempo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbl_tiempo.Location = new System.Drawing.Point(910, 48);
            this.lbl_tiempo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_tiempo.Name = "lbl_tiempo";
            this.lbl_tiempo.Size = new System.Drawing.Size(153, 46);
            this.lbl_tiempo.TabIndex = 0;
            this.lbl_tiempo.Text = "Tiempo";
            // 
            // lbl_fecha
            // 
            this.lbl_fecha.AutoSize = true;
            this.lbl_fecha.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_fecha.Location = new System.Drawing.Point(283, 48);
            this.lbl_fecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_fecha.Name = "lbl_fecha";
            this.lbl_fecha.Size = new System.Drawing.Size(131, 46);
            this.lbl_fecha.TabIndex = 1;
            this.lbl_fecha.Text = "Fecha";
            // 
            // TiempoFecha
            // 
            this.TiempoFecha.Enabled = true;
            this.TiempoFecha.Tick += new System.EventHandler(this.TiempoFecha_Tick);
            // 
            // DataClient
            // 
            this.DataClient.AllowUserToAddRows = false;
            this.DataClient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataClient.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataClient.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.DataClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataClient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataClient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Teléfono,
            this.Consulta,
            this.Doctor,
            this.Inicia,
            this.Finaliza,
            this.Justificación});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataClient.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataClient.EnableHeadersVisualStyles = false;
            this.DataClient.Location = new System.Drawing.Point(108, 149);
            this.DataClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataClient.Name = "DataClient";
            this.DataClient.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataClient.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DataClient.Size = new System.Drawing.Size(1280, 602);
            this.DataClient.TabIndex = 50;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Teléfono
            // 
            this.Teléfono.HeaderText = "Teléfono";
            this.Teléfono.Name = "Teléfono";
            this.Teléfono.ReadOnly = true;
            this.Teléfono.Width = 109;
            // 
            // Consulta
            // 
            this.Consulta.HeaderText = "Consulta";
            this.Consulta.Name = "Consulta";
            this.Consulta.ReadOnly = true;
            this.Consulta.Width = 113;
            // 
            // Doctor
            // 
            this.Doctor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Doctor.HeaderText = "Doctor";
            this.Doctor.Name = "Doctor";
            this.Doctor.ReadOnly = true;
            // 
            // Inicia
            // 
            this.Inicia.HeaderText = "Inicia";
            this.Inicia.Name = "Inicia";
            this.Inicia.ReadOnly = true;
            this.Inicia.Width = 83;
            // 
            // Finaliza
            // 
            this.Finaliza.HeaderText = "Finaliza";
            this.Finaliza.Name = "Finaliza";
            this.Finaliza.ReadOnly = true;
            this.Finaliza.Width = 97;
            // 
            // Justificación
            // 
            this.Justificación.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Justificación.HeaderText = "Justificación";
            this.Justificación.Name = "Justificación";
            this.Justificación.ReadOnly = true;
            // 
            // Central
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = global::Clinica_Dental.Properties.Resources.degradados_wallpapers_6;
            this.ClientSize = new System.Drawing.Size(1480, 855);
            this.Controls.Add(this.DataClient);
            this.Controls.Add(this.lbl_fecha);
            this.Controls.Add(this.lbl_tiempo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Central";
            this.Text = "Central";
            this.Load += new System.EventHandler(this.Central_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_tiempo;
        private System.Windows.Forms.Label lbl_fecha;
        private System.Windows.Forms.Timer TiempoFecha;
        private System.Windows.Forms.DataGridView DataClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teléfono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Consulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inicia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Finaliza;
        private System.Windows.Forms.DataGridViewTextBoxColumn Justificación;
    }
}