namespace FireManager.Views
{
    partial class CreateDomain
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtComentario = new System.Windows.Forms.RichTextBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTamano = new System.Windows.Forms.Label();
            this.lblNotNull = new System.Windows.Forms.Label();
            this.chkNotNull = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(225, 319);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 34);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(42, 319);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 34);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(109, 74);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(214, 41);
            this.txtComentario.TabIndex = 11;
            this.txtComentario.Text = "";
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Location = new System.Drawing.Point(39, 77);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(66, 13);
            this.lblComentario.TabIndex = 10;
            this.lblComentario.Text = "Comentario: ";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(109, 28);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(214, 20);
            this.txtNombre.TabIndex = 9;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(39, 31);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 13);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Nombre: ";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(39, 144);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(34, 13);
            this.lblTipo.TabIndex = 12;
            this.lblTipo.Text = "Tipo: ";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(109, 141);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(214, 21);
            this.cmbTipo.TabIndex = 13;
            // 
            // lblTamano
            // 
            this.lblTamano.AutoSize = true;
            this.lblTamano.Location = new System.Drawing.Point(39, 191);
            this.lblTamano.Name = "lblTamano";
            this.lblTamano.Size = new System.Drawing.Size(52, 13);
            this.lblTamano.TabIndex = 14;
            this.lblTamano.Text = "Tamaño: ";
            // 
            // lblNotNull
            // 
            this.lblNotNull.AutoSize = true;
            this.lblNotNull.Location = new System.Drawing.Point(39, 250);
            this.lblNotNull.Name = "lblNotNull";
            this.lblNotNull.Size = new System.Drawing.Size(48, 13);
            this.lblNotNull.TabIndex = 16;
            this.lblNotNull.Text = "Not Null:";
            // 
            // chkNotNull
            // 
            this.chkNotNull.AutoSize = true;
            this.chkNotNull.Location = new System.Drawing.Point(109, 250);
            this.chkNotNull.Name = "chkNotNull";
            this.chkNotNull.Size = new System.Drawing.Size(15, 14);
            this.chkNotNull.TabIndex = 17;
            this.chkNotNull.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(109, 191);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(131, 20);
            this.numericUpDown1.TabIndex = 18;
            // 
            // CreateDomain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 382);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.chkNotNull);
            this.Controls.Add(this.lblNotNull);
            this.Controls.Add(this.lblTamano);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "CreateDomain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Nuevo Dominio";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.RichTextBox txtComentario;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblTamano;
        private System.Windows.Forms.Label lblNotNull;
        public System.Windows.Forms.CheckBox chkNotNull;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}