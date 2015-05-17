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
    public partial class ProcedureParameter : Form
    {
        public ProcParameter Parametro;
        public CreateProcedure Padre;

        public ProcedureParameter(CreateProcedure createProcedure)
        {
            InitializeComponent();
            Padre = createProcedure;
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProcedureParameter_Load(object sender, EventArgs e)
        {
            cmbTipo.DataSource = Enum.GetValues(typeof(DataTypes));
            cmbScope.DataSource = Enum.GetValues(typeof(ScopeProcedureParameter));
            Parametro = new ProcParameter();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show(Resources.Click_Nombre_vacío);
                return;
            }

            Parametro.Nombre = txtNombre.Text;
            Parametro.Scope = (ScopeProcedureParameter) cmbScope.SelectedItem;
            Parametro.Tipo = (DataTypes) cmbTipo.SelectedItem;

            Padre.Procedimiento.Parametros.Add(Parametro);

            Padre.RefrescarParametros(Parametro);

            Close();

        }
    }
}
