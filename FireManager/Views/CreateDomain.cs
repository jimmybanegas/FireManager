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
using FireManager.EnumTypes;
using FireManager.Objects;
using FireManager.Properties;

namespace FireManager.Views
{
    public partial class CreateDomain : Form
    {
        public Domain Dominio;
        public FireManager Padre;
        
        public CreateDomain(FireManager fireManager)
        {
            InitializeComponent();

            Padre = fireManager;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void CreateDomain_Load(object sender, EventArgs e)
        {
            cmbTipo.DataSource = Enum.GetValues(typeof(DataTypes));
            
          
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show(Resources.Click_Nombre_vacío);
                return;
            }

            Dominio.Nombre = txtNombre.Text;
            Dominio.Comentario = txtComentario.Text;
            Dominio.NoNulos = chkNotNull.Checked;
            Dominio.Tamano = (int)numericUpDown1.Value;
            Dominio.Tipo = (DataTypes)cmbTipo.SelectedItem;

            var resultado = MetadataItemCreateStatement.CrearDominio(Dominio);

        }
    
    }
}
