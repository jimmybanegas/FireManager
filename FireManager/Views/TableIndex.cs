using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireManager.Objects;
using FireManager.Properties;

namespace FireManager.Views
{
    public partial class TableIndex : Form
    {
        public Index Indice;
        public CreateTable Tabla;

        public TableIndex(CreateTable createTable)
        {
            InitializeComponent();
            Tabla = createTable;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void TableIndex_Load(object sender, EventArgs e)
        {
            //checkedListBox1.DataSource = Tabla.Tabla.Campos;

            Indice = new Index();
            Indice.Inicializar();

            foreach (var campo in Tabla.Tabla.Campos)
            {
                checkedListBox1.Items.Add(campo.Nombre);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show(Resources.Click_Nombre_vacío);
                return;
            }

            Indice.Nombre = txtNombre.Text;
            Indice.Comentario = txtComentario.Text;
            
            foreach (var item in checkedListBox1.CheckedItems)
            {
              Indice.Campos.Add(Tabla.Tabla.Campos.Find(x=>x.Nombre==checkedListBox1.GetItemText(item)));  
            }

            Tabla.Tabla.Indices.Add(Indice);

            Tabla.RefrescarIndices(Indice);

            Close();
          
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}
