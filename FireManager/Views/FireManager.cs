using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FireManager.Controllers;
using FireManager.Models;
using FireManager.Properties;

namespace FireManager.Views
{
    public partial class FireManager : Form
    {

        public const int MaxBinaryDisplayString = 8000;
        public FireManager()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                LlenarTablas();
            }
            else
            {
                userMessage = string.Format("Mensaje = {0} Hay conexión = {1}", result.Message, result.Success);
            }

            MessageBox.Show(userMessage);
        }

        private void LlenarTablas()
        {
            var queryProcessing = new QueryProcessing();
            var connData = GetConnectionInformation();

            const string tablas = "SELECT NAME FROM sys.Tables";
          
            var dataTable = queryProcessing.ExecuteQuery(connData, tablas );

            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "NAME";
            comboBox1.ValueMember = "NAME";
        }

        public  ConnectionData GetConnectionInformation()
        {
            var data = new ConnectionData
            {
                ServerName = tbServerName.Text,
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
            tbUserName.Text = connectionData.UserName;
            tbPassword.Text = connectionData.Password;
            tbDatabaseName.Text = connectionData.DatabaseName;
        }

        private ConnectionData LoadProfile()
        {
            var profileManager = new ProfileManagement();
            var connectionData = new ConnectionData();

            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = @"C:\Documents";
            openFileDialog1.Filter = Resources.FireManager_LoadProfile_Firebird_Profile_File____XML____XML;
            var openDialogResult = openFileDialog1.ShowDialog();

            if (openDialogResult != DialogResult.OK) return connectionData;
            var filePath = openFileDialog1.FileName;

            connectionData = profileManager.GetSavedProfile(filePath);

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

            if (saveDialogResult != DialogResult.OK) return result;
            var filePath = saveFileDialog1.FileName;

            var fileManager = new FileManagement();

            var connectionData = GetConnectionInformation();

            result = fileManager.SaveNewProfile(connectionData, filePath);

            return result;
        }
      

        private void CargarBorrados()
        {
            var queryProcessing = new QueryProcessing();
            var connData = GetConnectionInformation();

            var borrados = "SELECT  [Operation],[Transaction ID],[AllocUnitName],[RowLog Contents 0] FROM ::fn_dblog(NULL, NULL) " +
                            "where operation='LOP_DELETE_ROWS' and " +
                            "[RowLog Contents 0] <> 0x and " +
                            "[AllocUnitName]='dbo." + comboBox1.Text + ".PK_" + comboBox1.Text + "'";

            var dataTable = queryProcessing.ExecuteQuery(connData, borrados);

            dataTable.Columns.Add("Fecha").SetOrdinal(0);

            foreach (DataRow row in dataTable.Rows)
            {
                var fecha =
                    "select [Begin Time] from fn_dblog(null,null) where [Transaction ID] = '"+row["Transaction ID"]+"'AND Operation = 'LOP_BEGIN_XACT'";

                var f = queryProcessing.ExecuteQuery(connData, fecha);

                row["Fecha"] = f.Rows[0]["Begin Time"];
            }

            dataGridView1.DataSource =  DisplayBinaries(dataTable);
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private static DataTable DisplayBinaries(DataTable t)
        {
            var binaryColumnNames = t.Columns.Cast<DataColumn>().Where(col => col.DataType == typeof(byte[])).
                Select(col => col.ColumnName).ToList();

            foreach (var binaryColumnName in binaryColumnNames)
            {
                var tempColumnName = "C" + Guid.NewGuid();
                t.Columns.Add(new DataColumn(tempColumnName, typeof(string)));
                t.Columns[tempColumnName].SetOrdinal(t.Columns[binaryColumnName].Ordinal);

                var hexBuilder = new StringBuilder(MaxBinaryDisplayString * 2 + 2);
                foreach (DataRow r in t.Rows)
                {
                    r[tempColumnName] = BitUtil.BinaryToString(hexBuilder, r[binaryColumnName]);
                }

                t.Columns.Remove(binaryColumnName);
                t.Columns[tempColumnName].ColumnName = binaryColumnName;
            }
            return t;
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
           var camposSetList = (from DataGridViewRow row in dataGridView1.Rows 
                                where !row.IsNewRow select row.Cells["RowLog Contents 0"].Value.ToString() 
                                into rowlogContents0 let bytes = BitUtil.ConvertToBinary(rowlogContents0) 
                                let campos = GetCampos() let camposVariables = GetCamposVariables() 
                                select (Utilities.LoopRowLog(rowlogContents0, campos, camposVariables))).ToList();

            MostrarValoresEnTabla(camposSetList);
        }

        private void MostrarValoresEnTabla(IReadOnlyCollection<List<Field>> campos)
        {
            if (campos == null) throw new ArgumentNullException("campos");
            var dt = new DataTable();

            dt.Clear();

            if (campos.Count <= 0) return;
            for (var i = 0; i < campos.First().Count; i++)
            {
                dt.Columns.Add(campos.First().ElementAt(i).Name);
            }

            foreach (var campo in campos)
            {
                var row = dt.NewRow();

                for (var i = 0; i < campo.Count; i++)
                {
                    row[campo.ElementAt(i).Name] = campo.ElementAt(i).Value;
                }

                dt.Rows.Add(row);
            }

            dataGridView1.DataSource = dt;

            button1.Enabled = false;
        }

        private List<string> GetCamposVariables()
        {
            var queryProcessing = new QueryProcessing();
            var connData = GetConnectionInformation();

            var selectCampo = "Select column_name as Name,data_type as Tipo from information_schema.columns " +
                              "where TABLE_NAME = '" + comboBox1.Text + "'";

            var dataTable = queryProcessing.ExecuteQuery(connData, selectCampo);

            return (from DataRow row in dataTable.Rows
                    where row["Tipo"].ToString().Equals("varchar") || row["Tipo"].ToString().Equals("nchar")
                    select row["Name"].ToString()).ToList();
        }

        private List<Field> GetCampos()
        {
            var queryProcessing = new QueryProcessing();
            var connData = GetConnectionInformation();

            var selectCampo = "select colorder, syscolumns.name, systypes.name as NameType ,systypes.length as Size " +
                                 "from syscolumns inner join systypes on syscolumns.xusertype = systypes.xusertype " +
                                 "where id =object_id('dbo." + comboBox1.Text + "') and variable = 0 order by colorder";

            var dataTable = queryProcessing.ExecuteQuery(connData, selectCampo);


            return (from DataRow row in dataTable.Rows
                select new Field()
                {
                    Name = row["name"].ToString(), Type = row["NameType"].ToString(), Length = int.Parse(row["Size"].ToString())*2
                }).ToList();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarBorrados();
            button1.Enabled = true;
        }
    }
}
