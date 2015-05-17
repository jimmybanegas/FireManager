namespace FireManager.Views
{
    partial class CreateTrigger
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblTabla = new System.Windows.Forms.Label();
            this.cmbTabla = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.RichTextBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.cmbEvento = new System.Windows.Forms.ComboBox();
            this.lblEvento = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblPosicion = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtDefinicion = new System.Windows.Forms.RichTextBox();
            this.lblDefinicion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(400, 416);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 34);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(105, 416);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 34);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblTabla
            // 
            this.lblTabla.AutoSize = true;
            this.lblTabla.Location = new System.Drawing.Point(44, 83);
            this.lblTabla.Name = "lblTabla";
            this.lblTabla.Size = new System.Drawing.Size(40, 13);
            this.lblTabla.TabIndex = 14;
            this.lblTabla.Text = "Tabla: ";
            // 
            // cmbTabla
            // 
            this.cmbTabla.FormattingEnabled = true;
            this.cmbTabla.Location = new System.Drawing.Point(105, 80);
            this.cmbTabla.Name = "cmbTabla";
            this.cmbTabla.Size = new System.Drawing.Size(184, 21);
            this.cmbTabla.TabIndex = 13;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(94, 24);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(166, 20);
            this.txtNombre.TabIndex = 12;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(44, 27);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 13);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Nombre: ";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(350, 24);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(214, 41);
            this.txtComentario.TabIndex = 16;
            this.txtComentario.Text = "";
            this.txtComentario.TextChanged += new System.EventHandler(this.txtComentario_TextChanged);
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Location = new System.Drawing.Point(278, 27);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(66, 13);
            this.lblComentario.TabIndex = 15;
            this.lblComentario.Text = "Comentario: ";
            this.lblComentario.Click += new System.EventHandler(this.lblComentario_Click);
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(508, 128);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 17;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // cmbEvento
            // 
            this.cmbEvento.FormattingEnabled = true;
            this.cmbEvento.Location = new System.Drawing.Point(443, 80);
            this.cmbEvento.Name = "cmbEvento";
            this.cmbEvento.Size = new System.Drawing.Size(121, 21);
            this.cmbEvento.TabIndex = 18;
            // 
            // lblEvento
            // 
            this.lblEvento.AutoSize = true;
            this.lblEvento.Location = new System.Drawing.Point(369, 83);
            this.lblEvento.Name = "lblEvento";
            this.lblEvento.Size = new System.Drawing.Size(47, 13);
            this.lblEvento.TabIndex = 19;
            this.lblEvento.Text = "Evento: ";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(44, 127);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(34, 13);
            this.lblTipo.TabIndex = 21;
            this.lblTipo.Text = "Tipo: ";
            this.lblTipo.Click += new System.EventHandler(this.lblTipo_Click);
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(105, 124);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 20;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // lblPosicion
            // 
            this.lblPosicion.AutoSize = true;
            this.lblPosicion.Location = new System.Drawing.Point(272, 127);
            this.lblPosicion.Name = "lblPosicion";
            this.lblPosicion.Size = new System.Drawing.Size(53, 13);
            this.lblPosicion.TabIndex = 23;
            this.lblPosicion.Text = "Posicion: ";
            this.lblPosicion.Click += new System.EventHandler(this.lblPosicion_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(334, 124);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 24;
            // 
            // txtDefinicion
            // 
            this.txtDefinicion.Location = new System.Drawing.Point(47, 194);
            this.txtDefinicion.Name = "txtDefinicion";
            this.txtDefinicion.Size = new System.Drawing.Size(517, 199);
            this.txtDefinicion.TabIndex = 25;
            this.txtDefinicion.Text = "";
            // 
            // lblDefinicion
            // 
            this.lblDefinicion.AutoSize = true;
            this.lblDefinicion.Location = new System.Drawing.Point(44, 166);
            this.lblDefinicion.Name = "lblDefinicion";
            this.lblDefinicion.Size = new System.Drawing.Size(60, 13);
            this.lblDefinicion.TabIndex = 26;
            this.lblDefinicion.Text = "Definición: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(37, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 151);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // CreateTrigger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 462);
            this.Controls.Add(this.lblDefinicion);
            this.Controls.Add(this.txtDefinicion);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblPosicion);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblEvento);
            this.Controls.Add(this.cmbEvento);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.lblTabla);
            this.Controls.Add(this.cmbTabla);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Name = "CreateTrigger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Nuevo Trigger";
            this.Load += new System.EventHandler(this.CreateTrigger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblTabla;
        private System.Windows.Forms.ComboBox cmbTabla;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.RichTextBox txtComentario;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.ComboBox cmbEvento;
        private System.Windows.Forms.Label lblEvento;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblPosicion;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RichTextBox txtDefinicion;
        private System.Windows.Forms.Label lblDefinicion;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}