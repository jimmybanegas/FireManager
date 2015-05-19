namespace FireManager.Views
{
    partial class FireManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.perfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarPerfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarPerfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearNuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarDropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoObejtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dominioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procedimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.QueryTextBox = new System.Windows.Forms.TextBox();
            this.btSaveQuery = new System.Windows.Forms.Button();
            this.btLoadQuery = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.ClearAllButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btConnectionTest = new System.Windows.Forms.Button();
            this.tbDatabaseName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perfilesToolStripMenuItem,
            this.baseDeDatosToolStripMenuItem,
            this.nuevoObejtoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(865, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // perfilesToolStripMenuItem
            // 
            this.perfilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarPerfilToolStripMenuItem,
            this.guardarPerfilToolStripMenuItem});
            this.perfilesToolStripMenuItem.Name = "perfilesToolStripMenuItem";
            this.perfilesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.perfilesToolStripMenuItem.Text = "Perfiles";
            // 
            // cargarPerfilToolStripMenuItem
            // 
            this.cargarPerfilToolStripMenuItem.Name = "cargarPerfilToolStripMenuItem";
            this.cargarPerfilToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.cargarPerfilToolStripMenuItem.Text = "Cargar Perfil";
            this.cargarPerfilToolStripMenuItem.Click += new System.EventHandler(this.cargarPerfilToolStripMenuItem_Click);
            // 
            // guardarPerfilToolStripMenuItem
            // 
            this.guardarPerfilToolStripMenuItem.Name = "guardarPerfilToolStripMenuItem";
            this.guardarPerfilToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.guardarPerfilToolStripMenuItem.Text = "Guardar Perfil";
            this.guardarPerfilToolStripMenuItem.Click += new System.EventHandler(this.guardarPerfilToolStripMenuItem_Click);
            // 
            // baseDeDatosToolStripMenuItem
            // 
            this.baseDeDatosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearNuevaToolStripMenuItem,
            this.borrarDropToolStripMenuItem});
            this.baseDeDatosToolStripMenuItem.Name = "baseDeDatosToolStripMenuItem";
            this.baseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.baseDeDatosToolStripMenuItem.Text = "Base de Datos";
            // 
            // crearNuevaToolStripMenuItem
            // 
            this.crearNuevaToolStripMenuItem.Name = "crearNuevaToolStripMenuItem";
            this.crearNuevaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.crearNuevaToolStripMenuItem.Text = "Crear Nueva";
            this.crearNuevaToolStripMenuItem.Click += new System.EventHandler(this.crearNuevaToolStripMenuItem_Click);
            // 
            // borrarDropToolStripMenuItem
            // 
            this.borrarDropToolStripMenuItem.Name = "borrarDropToolStripMenuItem";
            this.borrarDropToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.borrarDropToolStripMenuItem.Text = "Borrar (Drop)";
            this.borrarDropToolStripMenuItem.Click += new System.EventHandler(this.borrarDropToolStripMenuItem_Click);
            // 
            // nuevoObejtoToolStripMenuItem
            // 
            this.nuevoObejtoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dominioToolStripMenuItem,
            this.funciónToolStripMenuItem,
            this.generadorToolStripMenuItem,
            this.procedimientoToolStripMenuItem,
            this.tablaToolStripMenuItem,
            this.triggerToolStripMenuItem,
            this.vistaToolStripMenuItem,
            this.usuarioToolStripMenuItem});
            this.nuevoObejtoToolStripMenuItem.Enabled = false;
            this.nuevoObejtoToolStripMenuItem.Name = "nuevoObejtoToolStripMenuItem";
            this.nuevoObejtoToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.nuevoObejtoToolStripMenuItem.Text = "Nuevo Objeto";
            // 
            // dominioToolStripMenuItem
            // 
            this.dominioToolStripMenuItem.Name = "dominioToolStripMenuItem";
            this.dominioToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dominioToolStripMenuItem.Text = "Dominio";
            this.dominioToolStripMenuItem.Click += new System.EventHandler(this.dominioToolStripMenuItem_Click);
            // 
            // funciónToolStripMenuItem
            // 
            this.funciónToolStripMenuItem.Name = "funciónToolStripMenuItem";
            this.funciónToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.funciónToolStripMenuItem.Text = "Función";
            this.funciónToolStripMenuItem.Click += new System.EventHandler(this.funciónToolStripMenuItem_Click);
            // 
            // generadorToolStripMenuItem
            // 
            this.generadorToolStripMenuItem.Name = "generadorToolStripMenuItem";
            this.generadorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.generadorToolStripMenuItem.Text = "Generador";
            this.generadorToolStripMenuItem.Click += new System.EventHandler(this.generadorToolStripMenuItem_Click);
            // 
            // procedimientoToolStripMenuItem
            // 
            this.procedimientoToolStripMenuItem.Name = "procedimientoToolStripMenuItem";
            this.procedimientoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.procedimientoToolStripMenuItem.Text = "Procedimiento";
            this.procedimientoToolStripMenuItem.Click += new System.EventHandler(this.procedimientoToolStripMenuItem_Click);
            // 
            // tablaToolStripMenuItem
            // 
            this.tablaToolStripMenuItem.Name = "tablaToolStripMenuItem";
            this.tablaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tablaToolStripMenuItem.Text = "Tabla";
            this.tablaToolStripMenuItem.Click += new System.EventHandler(this.tablaToolStripMenuItem_Click);
            // 
            // triggerToolStripMenuItem
            // 
            this.triggerToolStripMenuItem.Name = "triggerToolStripMenuItem";
            this.triggerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.triggerToolStripMenuItem.Text = "Trigger";
            this.triggerToolStripMenuItem.Click += new System.EventHandler(this.triggerToolStripMenuItem_Click);
            // 
            // vistaToolStripMenuItem
            // 
            this.vistaToolStripMenuItem.Name = "vistaToolStripMenuItem";
            this.vistaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.vistaToolStripMenuItem.Text = "Vista";
            this.vistaToolStripMenuItem.Click += new System.EventHandler(this.vistaToolStripMenuItem_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            this.usuarioToolStripMenuItem.Click += new System.EventHandler(this.usuarioToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 36);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(196, 316);
            this.treeView1.TabIndex = 1;
            // 
            // QueryTextBox
            // 
            this.QueryTextBox.Location = new System.Drawing.Point(224, 178);
            this.QueryTextBox.Multiline = true;
            this.QueryTextBox.Name = "QueryTextBox";
            this.QueryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.QueryTextBox.Size = new System.Drawing.Size(629, 174);
            this.QueryTextBox.TabIndex = 3;
            // 
            // btSaveQuery
            // 
            this.btSaveQuery.Location = new System.Drawing.Point(324, 132);
            this.btSaveQuery.Name = "btSaveQuery";
            this.btSaveQuery.Size = new System.Drawing.Size(75, 23);
            this.btSaveQuery.TabIndex = 20;
            this.btSaveQuery.Text = "Guardar Query";
            this.btSaveQuery.UseVisualStyleBackColor = true;
            this.btSaveQuery.Click += new System.EventHandler(this.btSaveQuery_Click);
            // 
            // btLoadQuery
            // 
            this.btLoadQuery.Location = new System.Drawing.Point(224, 132);
            this.btLoadQuery.Name = "btLoadQuery";
            this.btLoadQuery.Size = new System.Drawing.Size(75, 23);
            this.btLoadQuery.TabIndex = 19;
            this.btLoadQuery.Text = "Cargar Query";
            this.btLoadQuery.UseVisualStyleBackColor = true;
            this.btLoadQuery.Click += new System.EventHandler(this.btLoadQuery_Click);
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(444, 132);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 18;
            this.RunButton.Text = "Correr Query";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // ClearAllButton
            // 
            this.ClearAllButton.Location = new System.Drawing.Point(778, 132);
            this.ClearAllButton.Name = "ClearAllButton";
            this.ClearAllButton.Size = new System.Drawing.Size(75, 23);
            this.ClearAllButton.TabIndex = 17;
            this.ClearAllButton.Text = "Limpiar";
            this.ClearAllButton.UseVisualStyleBackColor = true;
            this.ClearAllButton.Click += new System.EventHandler(this.ClearAllButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 368);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(841, 259);
            this.dataGridView1.TabIndex = 21;
            // 
            // btConnectionTest
            // 
            this.btConnectionTest.Location = new System.Drawing.Point(608, 72);
            this.btConnectionTest.Name = "btConnectionTest";
            this.btConnectionTest.Size = new System.Drawing.Size(108, 23);
            this.btConnectionTest.TabIndex = 32;
            this.btConnectionTest.Text = "Probar Conexión";
            this.btConnectionTest.UseVisualStyleBackColor = true;
            this.btConnectionTest.Click += new System.EventHandler(this.btConnectionTest_Click);
            // 
            // tbDatabaseName
            // 
            this.tbDatabaseName.Location = new System.Drawing.Point(336, 75);
            this.tbDatabaseName.Name = "tbDatabaseName";
            this.tbDatabaseName.Size = new System.Drawing.Size(78, 20);
            this.tbDatabaseName.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Base Datos";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(722, 36);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(655, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Contraseña";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(498, 36);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(122, 20);
            this.tbUserName.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Usuario";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(498, 74);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(61, 20);
            this.tbPort.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Puerto";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbServerName
            // 
            this.tbServerName.Location = new System.Drawing.Point(336, 36);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.Size = new System.Drawing.Size(92, 20);
            this.tbServerName.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Servidor";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCrear);
            this.groupBox1.Location = new System.Drawing.Point(224, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 99);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(523, 50);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 0;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(612, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Correr Script";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FireManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 638);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btConnectionTest);
            this.Controls.Add(this.tbDatabaseName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbServerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btSaveQuery);
            this.Controls.Add(this.btLoadQuery);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.ClearAllButton);
            this.Controls.Add(this.QueryTextBox);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FireManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FireManager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearNuevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarDropToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox QueryTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btSaveQuery;
        private System.Windows.Forms.Button btLoadQuery;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button ClearAllButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btConnectionTest;
        private System.Windows.Forms.TextBox tbDatabaseName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem perfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarPerfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarPerfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoObejtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dominioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procedimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vistaToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

