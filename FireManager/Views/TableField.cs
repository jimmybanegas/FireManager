using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireManager.EnumTypes;
using FireManager.Objects;
using FireManager.Properties;

namespace FireManager.Views
{
    public partial class TableField : Form
    {
        public Field Campo;
        public CreateTable Tabla;

        public TableField(CreateTable createTable)
        {
            InitializeComponent();
            Tabla = createTable;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show(Resources.Click_Nombre_vacío); 
                return;
            } 
               
            Campo.EsLlavePrimaria = chkPrimaryKey.Checked;

            Campo.NoNulos = chkNotNull.Checked;

            Campo.Nombre = txtNombre.Text;

            Campo.Tipo = (DataTypes) cmbTipo.SelectedItem;

            Campo.Tamano = (int) numericUpDown1.Value;
            
            Tabla.Tabla.Campos.Add(Campo);

            Tabla.RefrescarCampos(Campo);

            Close();

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem == (object)DataTypes.Char || cmbTipo.SelectedItem == (object)DataTypes.VarChar
                 || cmbTipo.SelectedItem == (object)DataTypes.Numeric)
            {
              //  numericUpDown1.;
            }
        }

        private void TableField_Load(object sender, EventArgs e)
        {
            Campo = new Field();

            cmbTipo.DataSource = Enum.GetValues(typeof(DataTypes));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
