using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using FireManager.Controllers;
using FireManager.EnumTypes;
using FireManager.Models;
using FireManager.Objects;
using FireManager.Properties;

namespace FireManager.Views
{
    public partial class CreateTrigger : Form
    {
        public Trigger Trigger;
        public FireManager Padre;

        public CreateTrigger(FireManager fireManager)
        {
            InitializeComponent();
            Padre = fireManager;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblComentario_Click(object sender, EventArgs e)
        {

        }

        private void txtComentario_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTipo_Click(object sender, EventArgs e)
        {

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblPosicion_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show(Resources.Click_Nombre_vacío);
                return;
            }

            Trigger.Nombre = txtNombre.Text;
            Trigger.Comentario = txtComentario.Text;
            Trigger.Activo = chkActivo.Checked;
            Trigger.Tabla = cmbTabla.SelectedText;
            Trigger.Definicion = txtDefinicion.Text;
            Trigger.Evento = (TriggerEvent)cmbEvento.SelectedItem;
            Trigger.Tipo = (TriggerType)cmbTipo.SelectedItem;
            Trigger.Posicion = (int)numericUpDown1.Value;

            var resultado = MetadataItemCreateStatement.CrearTrigger(Trigger);

            

        }

        private void CreateTrigger_Load(object sender, EventArgs e)
        {
            Trigger = new Trigger(); 
            cmbTipo.DataSource = Enum.GetValues((typeof(TriggerType)));
            cmbEvento.DataSource = Enum.GetValues((typeof(TriggerEvent)));

            var connectionData = Padre.GetConnectionInformation();

            var tablas = FbObjetos.GetTables(connectionData);

            var misTablas = tablas.Select("TABLE_NAME <> ''");

            var arrayTablas = misTablas.Select(row => ((string)row["TABLE_NAME"])).ToArray(); //

            cmbTabla.DataSource = arrayTablas;
        }
    }
}
