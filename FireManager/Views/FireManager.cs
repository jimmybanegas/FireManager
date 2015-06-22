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


        const int MaxBinaryDisplayString = 8000;

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

            if (saveDialogResult != DialogResult.OK) return result;
            var filePath = saveFileDialog1.FileName;

            var fileManager = new FileManagement();

            var connectionData = GetConnectionInformation();

            result = fileManager.SaveNewProfile(connectionData, filePath);

            return result;
        }

        private void bt_Cargar_Click(object sender, EventArgs e)
        {
            CargarBorrados();
        }

        private void CargarBorrados()
        {
            var queryProcessing = new QueryProcessing();
            var connData = GetConnectionInformation();

            var borrados = "SELECT [Transaction ID],[AllocUnitName],[RowLog Contents 0] FROM ::fn_dblog(NULL, NULL) " +
                            "where operation='LOP_DELETE_ROWS' and " +
                            "[RowLog Contents 0] <> 0x and " +
                            "[AllocUnitName]='dbo." + comboBox1.Text + ".PK_" + comboBox1.Text + "'";

            var dataTable = queryProcessing.ExecuteQuery(connData, borrados);

            dataGridView1.DataSource =  FixBinaryColumnsForDisplay(dataTable);
        }

        private static DataTable FixBinaryColumnsForDisplay(DataTable t)
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
                    r[tempColumnName] = BinaryDataColumnToString(hexBuilder, r[binaryColumnName]);
                }

                t.Columns.Remove(binaryColumnName);
                t.Columns[tempColumnName].ColumnName = binaryColumnName;
            }
            return t;
        }

        private static string BinaryDataColumnToString(StringBuilder hexBuilder, object columnValue)
        {
            const string hexChars = "0123456789ABCDEF";
            if (columnValue == DBNull.Value)
            {
                return "(null)";
            }
            var byteArray = (byte[])columnValue;
            var displayLength = (byteArray.Length > MaxBinaryDisplayString) ? MaxBinaryDisplayString : byteArray.Length;
            hexBuilder.Length = 0;
            hexBuilder.Append("0x");
            for (var i = 0; i < displayLength; i++)
            {
                hexBuilder.Append(hexChars[(int)byteArray[i] >> 4]);
                hexBuilder.Append(hexChars[(int)byteArray[i] % 0x10]);
            }
            return hexBuilder.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
          //  foreach (var row in dataGridView1.Rows)
            //{
                var rowlogContents0 = dataGridView1.CurrentCell.Value.ToString();
                var bytes = ConvertToBinary(rowlogContents0);
                var campos = GetCampos();
                //List<CamposNoFijos> camposNofijos = getCamposNofijos(campos);
                var camposVariables = GetCamposVariables();

                SetTable(Conversiones.Recorrer(rowlogContents0, campos, camposVariables));
           // }
        }

        private void SetTable(List<Campos> campos)
        {
            if (campos == null) throw new ArgumentNullException("campos");
            var dt = new DataTable();
            dt.Clear();

            for (var i = 0; i < campos.Count; i++)
            {
                dt.Columns.Add(campos.ElementAt(i).Nombre);
            }
            var row = dt.NewRow();

            for (var i = 0; i < campos.Count; i++)
            {
                row[campos.ElementAt(i).Nombre] = campos.ElementAt(i).Valor;
            }

            dt.Rows.Add(row);
            dataGridView1.DataSource = dt;
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

        private List<Campos> GetCampos()
        {
            var queryProcessing = new QueryProcessing();
            var connData = GetConnectionInformation();

            var selectCampo = "select colorder, syscolumns.name, systypes.name as NameType ,systypes.length as Size " +
                                 "from syscolumns inner join systypes on syscolumns.xusertype = systypes.xusertype " +
                                 "where id =object_id('dbo." + comboBox1.Text + "') and variable = 0 order by colorder";

            var dataTable = queryProcessing.ExecuteQuery(connData, selectCampo);


            return (from DataRow row in dataTable.Rows
                select new Campos()
                {
                    Nombre = row["name"].ToString(), Type = row["NameType"].ToString(), Tamaño = int.Parse(row["Size"].ToString())*2
                }).ToList();
        }


        public static byte[] ConvertToBinary(string str)
        {
            var encoding = new ASCIIEncoding();
            return encoding.GetBytes(str);
        }

    }
}
