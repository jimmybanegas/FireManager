using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireManager.Properties;

namespace FireManager
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

        private void btLoadQuery_Click(object sender, EventArgs e)
        {
            QueryTextBox.Text = "";
            var queryText = GetSavedQuery();
            QueryTextBox.Text = queryText;
        }

        private string GetSavedQuery()
        {
            var fileManager = new FileManagement();
            var dialogResult = new Result();

            var queryText = "";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = Resources.FireManager_GetSavedQuery_SQL_Script_Files____sql____sql;
            var openDialogResult = openFileDialog1.ShowDialog();

            if (openDialogResult == DialogResult.OK)
            {
                var file = openFileDialog1.FileName;

                queryText = fileManager.OpenQueryFile(file);
            }

            return queryText;
        }

        private void btSaveQuery_Click(object sender, EventArgs e)
        {
            var queryText = QueryTextBox.Text;

            if (!string.IsNullOrWhiteSpace(queryText))
            {
                SaveQuery(queryText);
            }
            else
            {
                MessageBox.Show(Resources.FireManager_btSaveQuery_Click_No_hay_nada_que_guardar);
            }
        }

        private void SaveQuery(string queryText)
        {
            var fileManager = new FileManagement();
            var result = new Result();

            saveFileDialog1.FileName = "Query";
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Filter = Resources.FireManager_GetSavedQuery_SQL_Script_Files____sql____sql;

            var saveDialogResult = saveFileDialog1.ShowDialog();

            if (saveDialogResult == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;

                if (!string.IsNullOrWhiteSpace(queryText))
                {
                    result = fileManager.SaveQueryFile(file, queryText);
                }

            }

            MessageBox.Show(result.Message);
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            QueryTextBox.Clear();
            dataGridView1.DataSource = "";
            dataGridView1.Refresh();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            var typeId = GetQueryType();
            DataTable dataTable;
            var queryProcessing = new QueryProcessing();
            var connData = GetConnectionInformation();

            if (typeId == 1)
            {
                dataTable = queryProcessing.ExecuteQuery(connData, QueryTextBox.Text);
            }
            else
            {
                dataTable = queryProcessing.ExecuteStoredProcedure(connData, QueryTextBox.Text);
            }

            dataGridView1.DataSource = dataTable;
        }

        private static int GetQueryType()
        {
           // int typeID = (int)cbQueryType.SelectedValue;
            //return typeID;
            return 1;
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
                userMessage = string.Format("Can Connect = {0}", result.Success);
            }
            else
            {
                userMessage = string.Format("Message Returned = {0} Can Connect = {1}", result.Message, result.Success);
            }

            MessageBox.Show(userMessage);
        }

        private ConnectionData GetConnectionInformation()
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
            var connectionData = new ConnectionData();

            connectionData = LoadProfile();

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
            openFileDialog1.InitialDirectory = @"C:\";
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
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Filter = Resources.FireManager_LoadProfile_Firebird_Profile_File____XML____XML;

            var saveDialogResult = saveFileDialog1.ShowDialog();

            if (saveDialogResult == DialogResult.OK)
            {
                var filePath = saveFileDialog1.FileName;

                var fileName = Path.GetFileNameWithoutExtension(filePath);

                var fileManager = new FileManagement();
                var connectionData = new ConnectionData();
                connectionData = GetConnectionInformation();

                result = fileManager.SaveNewProfile(connectionData, filePath);
            }

            return result;
        }

        private void excepcionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void crearNuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
