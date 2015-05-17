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
using FireManager.Models;
using FireManager.Objects;
using FireManager.Properties;

namespace FireManager.Views
{
    public partial class CreateProcedure : Form
    {
        public Procedure Procedimiento;
        public readonly BindingList<ProcParameter> _parametrosBindingList = new BindingList<ProcParameter>();

        public CreateProcedure()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridViewForeignKeys_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNuevoParametro_Click(object sender, EventArgs e)
        {
            var nnuevoParametro = new ProcedureParameter(this);

            nnuevoParametro.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show(Resources.Click_Nombre_vacío);
                return;
            }

            if (Procedimiento.Parametros.Count == 0)
            {
                MessageBox.Show(Resources.Click_Parámetros_vacíos);
                return;
            }

            Procedimiento.Nombre = txtNombre.Text;
            Procedimiento.Comentario = txtComentario.Text;
            Procedimiento.Definicion = richTextBox1.Text;

            var resultado = MetadataItemCreateStatement.CrearProcedimiento(Procedimiento);

        }

        private void CreateProcedure_Load(object sender, EventArgs e)
        {
            Procedimiento = new Procedure();
            Procedimiento.Inicializar();
            dataGridViewParameters.DataSource = _parametrosBindingList;
        }

        public void RefrescarParametros(ProcParameter parametro)
        {
            _parametrosBindingList.Add(parametro);
        }
    }
}
