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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dataGridViewForeignKeys = new System.Windows.Forms.DataGridView();
            this.dataGridViewIndexes = new System.Windows.Forms.DataGridView();
            this.dataGridViewFields = new System.Windows.Forms.DataGridView();
            this.btnNuevoCampo = new System.Windows.Forms.Button();
            this.btnNuevoIndice = new System.Windows.Forms.Button();
            this.btnNuevaForanea = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForeignKeys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndexes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFields)).BeginInit();
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
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(98, 390);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 34);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
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
            // dataGridViewForeignKeys
            // 
            this.dataGridViewForeignKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForeignKeys.Location = new System.Drawing.Point(16, 6);
            this.dataGridViewForeignKeys.Name = "dataGridViewForeignKeys";
            this.dataGridViewForeignKeys.Size = new System.Drawing.Size(484, 206);
            this.dataGridViewForeignKeys.TabIndex = 0;
            // 
            // dataGridViewIndexes
            // 
            this.dataGridViewIndexes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIndexes.Location = new System.Drawing.Point(16, 6);
            this.dataGridViewIndexes.Name = "dataGridViewIndexes";
            this.dataGridViewIndexes.Size = new System.Drawing.Size(483, 202);
            this.dataGridViewIndexes.TabIndex = 0;
            // 
            // dataGridViewFields
            // 
            this.dataGridViewFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFields.Location = new System.Drawing.Point(16, 6);
            this.dataGridViewFields.Name = "dataGridViewFields";
            this.dataGridViewFields.Size = new System.Drawing.Size(488, 208);
            this.dataGridViewFields.TabIndex = 0;
            // 
            // btnNuevoCampo
            // 
            this.btnNuevoCampo.Location = new System.Drawing.Point(16, 229);
            this.btnNuevoCampo.Name = "btnNuevoCampo";
            this.btnNuevoCampo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoCampo.TabIndex = 1;
            this.btnNuevoCampo.Text = "Nuevo";
            this.btnNuevoCampo.UseVisualStyleBackColor = true;
            // 
            // btnNuevoIndice
            // 
            this.btnNuevoIndice.Location = new System.Drawing.Point(16, 225);
            this.btnNuevoIndice.Name = "btnNuevoIndice";
            this.btnNuevoIndice.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoIndice.TabIndex = 2;
            this.btnNuevoIndice.Text = "Nuevo";
            this.btnNuevoIndice.UseVisualStyleBackColor = true;
            // 
            // btnNuevaForanea
            // 
            this.btnNuevaForanea.Location = new System.Drawing.Point(16, 222);
            this.btnNuevaForanea.Name = "btnNuevaForanea";
            this.btnNuevaForanea.Size = new System.Drawing.Size(75, 23);
            this.btnNuevaForanea.TabIndex = 2;
            this.btnNuevaForanea.Text = "Nueva";
            this.btnNuevaForanea.UseVisualStyleBackColor = true;
            // 
            // CreateTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 463);
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForeignKeys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndexes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFields)).EndInit();
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
    }
}