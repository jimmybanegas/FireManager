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
    public partial class CreateGenerator : Form
    {
        private Generator Generador;

        public CreateGenerator(FireManager fireManager)
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblTamano_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show(Resources.Click_Nombre_vacío);
                return;
            }

            Generador.Nombre = txtNombre.Text;
            Generador.Tamano = (int) numericUpDown1.Value;

            var resultado = MetadataItemCreateStatement.CrearGenerador(Generador);

        }

        private void CreateGenerator_Load(object sender, EventArgs e)
        {
            Generador = new Generator();
        }
    }
}
