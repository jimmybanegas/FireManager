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

namespace FireManager.Views
{
    public partial class CreateUser : Form
    {
        private User Usuario;
        private FireManager Padre;

        public CreateUser(FireManager fireManager)
        {
            InitializeComponent();
            Padre = fireManager;
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            Usuario = new User();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "" || txtConfirmar.Text=="")
            {
                MessageBox.Show("Campos vacíos");
                return;
            }

            if (txtConfirmar.Text != txtPassword.Text)
            {

                MessageBox.Show("Contraseñas no coinciden");
                return;
            }

            Usuario = new User()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Usuario = txtUserName.Text,
                Contraseña = txtPassword.Text
            };

            var resultado = MetadataItemCreateStatement.CrearUsuario(Usuario);

            Padre.SetQueryText(resultado.Message);

            Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
