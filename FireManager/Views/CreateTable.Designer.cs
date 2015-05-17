namespace FireManager.Views
{
    partial class CreateTable
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnNuevoCampo = new System.Windows.Forms.Button();
            this.dataGridViewFields = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnNuevoIndice = new System.Windows.Forms.Button();
            this.dataGridViewIndexes = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnNuevaForanea = new System.Windows.Forms.Button();
            this.dataGridViewForeignKeys = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblComentario = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.txtComentario = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFields)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndexes)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForeignKeys)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(42, 36);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre: ";
            this.lblNombre.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(98, 33);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(166, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(45, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(531, 289);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNuevoCampo);
            this.tabPage1.Controls.Add(this.dataGridViewFields);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(523, 263);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Campos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnNuevoCampo
            // 
            this.btnNuevoCampo.Location = new System.Drawing.Point(16, 231);
            this.btnNuevoCampo.Name = "btnNuevoCampo";
            this.btnNuevoCampo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoCampo.TabIndex = 1;
            this.btnNuevoCampo.Text = "Nuevo";
            this.btnNuevoCampo.UseVisualStyleBackColor = true;
            this.btnNuevoCampo.Click += new System.EventHandler(this.btnNuevoCampo_Click);
            // 
            // dataGridViewFields
            // 
            this.dataGridViewFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFields.Location = new System.Drawing.Point(16, 15);
            this.dataGridViewFields.Name = "dataGridViewFields";
            this.dataGridViewFields.Size = new System.Drawing.Size(490, 210);
            this.dataGridViewFields.TabIndex = 0;
            this.dataGridViewFields.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFields_CellContentClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnNuevoIndice);
            this.tabPage2.Controls.Add(this.dataGridViewIndexes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(523, 263);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Índices";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnNuevoIndice
            // 
            this.btnNuevoIndice.Location = new System.Drawing.Point(16, 231);
            this.btnNuevoIndice.Name = "btnNuevoIndice";
            this.btnNuevoIndice.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoIndice.TabIndex = 2;
            this.btnNuevoIndice.Text = "Nuevo";
            this.btnNuevoIndice.UseVisualStyleBackColor = true;
            this.btnNuevoIndice.Click += new System.EventHandler(this.btnNuevoIndice_Click);
            // 
            // dataGridViewIndexes
            // 
            this.dataGridViewIndexes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIndexes.Location = new System.Drawing.Point(16, 15);
            this.dataGridViewIndexes.Name = "dataGridViewIndexes";
            this.dataGridViewIndexes.Size = new System.Drawing.Size(490, 210);
            this.dataGridViewIndexes.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnNuevaForanea);
            this.tabPage3.Controls.Add(this.dataGridViewForeignKeys);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(523, 263);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Llaves foráneas";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnNuevaForanea
            // 
            this.btnNuevaForanea.Location = new System.Drawing.Point(16, 231);
            this.btnNuevaForanea.Name = "btnNuevaForanea";
            this.btnNuevaForanea.Size = new System.Drawing.Size(75, 23);
            this.btnNuevaForanea.TabIndex = 2;
            this.btnNuevaForanea.Text = "Nueva";
            this.btnNuevaForanea.UseVisualStyleBackColor = true;
            this.btnNuevaForanea.Click += new System.EventHandler(this.btnNuevaForanea_Click);
            // 
            // dataGridViewForeignKeys
            // 
            this.dataGridViewForeignKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForeignKeys.Location = new System.Drawing.Point(16, 15);
            this.dataGridViewForeignKeys.Name = "dataGridViewForeignKeys";
            this.dataGridViewForeignKeys.Size = new System.Drawing.Size(490, 210);
            this.dataGridViewForeignKeys.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(98, 390);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 34);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(383, 390);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 34);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Location = new System.Drawing.Point(290, 36);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(66, 13);
            this.lblComentario.TabIndex = 5;
            this.lblComentario.Text = "Comentario: ";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(362, 33);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(214, 41);
            this.txtComentario.TabIndex = 7;
            this.txtComentario.Text = "";
            // 
            // CreateTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 462);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Name = "CreateTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Nueva Tabla";
            this.Load += new System.EventHandler(this.CreateTable_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFields)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndexes)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForeignKeys)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridViewForeignKeys;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNuevoCampo;
        private System.Windows.Forms.DataGridView dataGridViewFields;
        private System.Windows.Forms.Button btnNuevoIndice;
        private System.Windows.Forms.DataGridView dataGridViewIndexes;
        private System.Windows.Forms.Button btnNuevaForanea;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.RichTextBox txtComentario;
    }
}