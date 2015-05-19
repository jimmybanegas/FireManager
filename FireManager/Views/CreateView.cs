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
    public partial class CreateView : Form
    {
        private MyView Vista;
        private FireManager Padre;

        public CreateView(FireManager fireManager)
        {
            InitializeComponent();
            Padre = fireManager;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var columnas = FbObjetos.GetColumns(Padre.GetConnectionInformation(), comboBox1.Text);

            var misColumnas = columnas.Select("COLUMN_NAME <> ''");

            var misc = misColumnas.Select(row => ((string)row["TABLE_NAME"]+"."+row["COLUMN_NAME"])).ToArray(); //

            checkedListBox1.DataSource = misc;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreateView_Load(object sender, EventArgs e)
        {
            Vista = new MyView();
            Vista.Inicializar();

            var connectionData = Padre.GetConnectionInformation();

            var tablas = FbObjetos.GetTables(connectionData);

            var misTablas = tablas.Select("TABLE_NAME <> ''");

            var arrayTablas = misTablas.Select(row => ((string)row["TABLE_NAME"])).ToArray(); //

            comboBox1.DataSource = arrayTablas;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show(Resources.Click_Nombre_vacío);
                return;
            }

            if (checkedListBox2.Items.Count == 0)
            {
                MessageBox.Show(Resources.Click_Parámetros_vacíos);
                return; 
            }

         //   Vista.Tabla = comboBox1.Text;

            Vista.Nombre = txtNombre.Text;

            foreach (var item in checkedListBox2.Items)
            {
                Vista.Campos.Add(checkedListBox2.GetItemText(item));
            }

            var resultado = MetadataItemCreateStatement.CrearVista(Vista);

            Padre.SetQueryText(resultado.Message);

            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.CheckedItems.Cast<object>()
                .Where(item => !checkedListBox2.Items.Contains(item)))
            {
                checkedListBox2.Items.Add(item);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox2.CheckedItems.OfType<string>().ToList())
            {
                checkedListBox2.Items.Remove(item);
            }
        }
    }
}
