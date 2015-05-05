using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireManager.Views
{
    public partial class CreateTable : Form
    {
        public CreateTable()
        {
            InitializeComponent();
        }

        private void CreateTable_Load(object sender, EventArgs e)
        {

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
            var nuevoCampo = new TableField();

            nuevoCampo.Show();
        }

        private void btnNuevoIndice_Click(object sender, EventArgs e)
        {
            var nuevoIndice = new TableIndex();

            nuevoIndice.Show();
        }

        private void btnNuevaForanea_Click(object sender, EventArgs e)
        {
            var nuevaLlaveForanea = new TableForeignKey();

            nuevaLlaveForanea.Show();
        }
    }
}
