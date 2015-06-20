using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FireManager.Controllers;
using FireManager.Models;
using FireManager.Properties;
namespace FireManager.Views
{
    public partial class FireManager : Form
    {
        public FireManager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btConnectionTest_Click(object sender, EventArgs e)
        {
            var userMessage = "";
            var connectionInfo = GetConnectionInformation();
            var dataAccess = new DataAccess(connectionInfo);
            var result = dataAccess.TestDatabaseConnection();


            if (result.Success)
            {

                userMessage = string.Format("Hay conexión = {0}", result.Success);
               
            }
            else
            {
                userMessage = string.Format("Mensaje = {0} Hay conexión = {1}", result.Message, result.Success);
            }

            MessageBox.Show(userMessage);

           
        }
    
        public  ConnectionData GetConnectionInformation()
        {
            var data = new ConnectionData
            {
                ServerName = tbServerName.Text,
                PortNumber = tbPort.Text,
                UserName = tbUserName.Text,
                Password = tbPassword.Text,
                DatabaseName = tbDatabaseName.Text
            };

            return data;
        }

        private void cargarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var connectionData = LoadProfile();

            tbServerName.Text = connectionData.ServerName;
            tbPort.Text = connectionData.PortNumber;
            tbUserName.Text = connectionData.UserName;
            tbPassword.Text = connectionData.Password;
            tbDatabaseName.Text = connectionData.DatabaseName;
        }

        private ConnectionData LoadProfile()
        {
            var profileManager = new ProfileManagement();
            var connectionData = new ConnectionData();

            var dialogResult = new Result();

            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = @"C:\Documents";
            openFileDialog1.Filter = Resources.FireManager_LoadProfile_Firebird_Profile_File____XML____XML;
            var openDialogResult = openFileDialog1.ShowDialog();

            if (openDialogResult == DialogResult.OK)
            {
                var filePath = openFileDialog1.FileName;

                connectionData = profileManager.GetSavedProfile(filePath);

               
            }

            return connectionData;
        }

        private void guardarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = SaveProfile();

            MessageBox.Show(result.Message);
        }

        private Result SaveProfile()
        {
            var result = new Result();

            saveFileDialog1.FileName = "Profile";
            saveFileDialog1.InitialDirectory = @"C:\Documents";
            saveFileDialog1.Filter = Resources.FireManager_LoadProfile_Firebird_Profile_File____XML____XML;

            var saveDialogResult = saveFileDialog1.ShowDialog();

            if (saveDialogResult == DialogResult.OK)
            {
                var filePath = saveFileDialog1.FileName;

                var fileManager = new FileManagement();

                var connectionData = GetConnectionInformation();

                result = fileManager.SaveNewProfile(connectionData, filePath);
            }

            return result;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
