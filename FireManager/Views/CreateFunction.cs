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
    public partial class CreateFunction : Form
    {
        public CreateFunction()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevoParametro_Click(object sender, EventArgs e)
        {
            var nuevoParametro = new FunctionParameter();

            nuevoParametro.Show();
        }
    }
}
