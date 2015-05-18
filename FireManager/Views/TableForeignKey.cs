using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireManager.Controllers;
using FireManager.Objects;
using FireManager.Properties;

namespace FireManager.Views
{
    public partial class TableForeignKey : Form
    {
        public ForeignKey Llave;
        public CreateTable Tabla;
        
        public TableForeignKey(CreateTable createTable)
        {
            InitializeComponent();

            Tabla = createTable;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TableForeignKey_Load(object sender, EventArgs e)
        {
            Llave = new ForeignKey();
            foreach (var campo in Tabla.Tabla.Campos)
            {
              //  cmbField

                cmbField.Items.Add(campo.Nombre);
            }

//            cmbField.DataSource = Tabla.Tabla.Campos;

            var connectionData = Tabla.GetConnectionInformation();

            var tablas = FbObjetos.GetTables(connectionData);

            var misTablas = tablas.Select("TABLE_NAME <> ''");

            var arrayTablas = misTablas.Select(row => ((string)row["TABLE_NAME"])).ToArray(); //

            cmbForeignTable.DataSource = arrayTablas;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
          //  Tabla.RefrescarCampos(Campo);
            if (txtNombre.Text == "")
            {
                MessageBox.Show(Resources.Click_Nombre_vacío);
                return;
            }

            Llave.Nombre = txtNombre.Text;

          //  Llave.Campo = (Tabla.Tabla.Campos.Find(x => x.Nombre == cmbField.Text));
            Llave.Campo = cmbField.Text;

            Llave.CampoReferico = cmbForeignColumn.Text;

            Llave.TablaReferida = cmbForeignTable.Text;

            Tabla.Tabla.Foraneas.Add(Llave);

            Tabla.RefrescarForaneas(Llave);

            Close();
        }

        private void cmbForeignTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            var columnas = FbObjetos.GetColumns(Tabla.GetConnectionInformation(),cmbForeignTable.Text);

            var misColumnas = columnas.Select("COLUMN_NAME <> ''");

            var misc = misColumnas.Select(row => ((string)row["COLUMN_NAME"])).ToArray(); //

            cmbForeignColumn.DataSource = misc;
        }
    }
}
