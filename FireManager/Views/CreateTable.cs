using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireManager.Controllers;
using FireManager.Models;
using FireManager.Objects;
using FireManager.Properties;

namespace FireManager.Views
{
  //  FireManager padre 

    public partial class CreateTable : Form
    {
        public Table Tabla;

        public FireManager Padre;

        readonly BindingList<Field> _camposBindingList = new BindingList<Field>();
        private readonly BindingList<ForeignKey> _foraneasBindingList = new BindingList<ForeignKey>();
        private readonly BindingList<Index> _indicesBindingList = new BindingList<Index>();


        public void RefrescarCampos(Field campo)
        {
            _camposBindingList.Add(campo);
        }

        public void RefrescarForaneas(ForeignKey llave)
        {
            _foraneasBindingList.Add(llave);
        }

        public void RefrescarIndices(Index indice)
        {
            _indicesBindingList.Add(indice);
        }
        
        public CreateTable(FireManager fireManager)
        {
           InitializeComponent();
           Padre = fireManager;
        }

        private void CreateTable_Load(object sender, EventArgs e)
        {
            Tabla = new Table();
            Tabla.Inicializar();

            dataGridViewFields.DataSource = _camposBindingList;

            dataGridViewForeignKeys.DataSource = _foraneasBindingList;

            dataGridViewIndexes.DataSource = _indicesBindingList;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevoCampo_Click(object sender, EventArgs e)
        {
            var nuevoCampo = new TableField(this);

            nuevoCampo.Show();
        }

        private void btnNuevoIndice_Click(object sender, EventArgs e)
        {
            var nuevoIndice = new TableIndex(this);

            nuevoIndice.Show();
        }

        private void btnNuevaForanea_Click(object sender, EventArgs e)
        {
            var nuevaLlaveForanea = new TableForeignKey(this);

            nuevaLlaveForanea.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Refresh();
            if (txtNombre.Text == "")
            {
                MessageBox.Show(Resources.Click_Nombre_vacío);
                return;
            }


            if (Tabla.Campos.Count == (0))
            {
                MessageBox.Show("Campos vacios");
                return;
            }
              

            Tabla.Nombre = txtNombre.Text;
            Tabla.Comentario = txtComentario.Text;


            var resultado = MetadataItemCreateStatement.CrearTabla(Tabla);


            Padre.SetQueryText(resultado.Message);

            Close();

        }

        private void dataGridViewFields_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public ConnectionData GetConnectionInformation()
        {
            return Padre.GetConnectionInformation();
        }
    }
}
