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
    public partial class CreateFunction : Form
    {
        public Function Funcion;
        public readonly BindingList<FuncParameter> _parametrosBindingList = new BindingList<FuncParameter>();

        public CreateFunction(FireManager fireManager)
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevoParametro_Click(object sender, EventArgs e)
        {
            var nuevoParametro = new FunctionParameter(this);

            nuevoParametro.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show(Resources.Click_Nombre_vacío);
                return;
            }

            if (Funcion.Parametros.Count == 0)
            {
                MessageBox.Show(Resources.Click_Parámetros_vacíos);
                return;
            }

            Funcion.Nombre = txtNombre.Text;
            Funcion.Comentario = txtComentario.Text;


            var resultado = MetadataItemCreateStatement.CrearFuncion(Funcion);

        }

        private void CreateFunction_Load(object sender, EventArgs e)
        {
            Funcion = new Function();
            Funcion.Inicializar();
            dataGridViewParameters.DataSource = _parametrosBindingList;
        }

        public void RefrescarParametros(FuncParameter parametro)
        {
            _parametrosBindingList.Add(parametro);
        }
    }
}
