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

namespace FireManager.Views
{
    public partial class FunctionParameter : Form
    {
        public FuncParameter Parametro;
        public CreateFunction Padre;
        
        public FunctionParameter(CreateFunction createFunction)
        {
            InitializeComponent();
            Padre = createFunction;
        }

        private void cmbScope_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FunctionParameter_Load(object sender, EventArgs e)
        {
            cmbTipo.DataSource = Enum.GetValues(typeof(DataTypes));
            cmbMecanism.DataSource = Enum.GetValues(typeof(MechanismFunctionParameter));
            Parametro = new FuncParameter();
            cmbMecanism.Enabled = false;
            numericUpDown1.Enabled = false;

            if (Padre.Funcion.Parametros.Find(x => x.IsReturn) == null)
            {
                chkIsReturn.Enabled = true;
            }
            else
            {
                chkIsReturn.Enabled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Parametro.IsReturn = chkIsReturn.Checked;
            Parametro.Mecanismo = (MechanismFunctionParameter)cmbMecanism.SelectedItem;
            Parametro.Tipo = (DataTypes) cmbTipo.SelectedItem;
            Parametro.Tamano = (int) numericUpDown1.Value;

            Padre.Funcion.Parametros.Add(Parametro);

            Padre.RefrescarParametros(Parametro);

            Close();
        }

        private void chkIsReturn_CheckedChanged(object sender, EventArgs e)
        {
            cmbMecanism.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DataTypes)cmbTipo.SelectedItem == DataTypes.Char || (DataTypes)cmbTipo.SelectedItem == DataTypes.VarChar
               || (DataTypes)cmbTipo.SelectedItem == DataTypes.Text)
            {
                numericUpDown1.Enabled = true;
            }
            else
            {
                numericUpDown1.Enabled = false;
            }
        }
    }
}
