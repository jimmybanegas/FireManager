using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using FireManager.Models;

namespace FireManager.Controllers
{
    public class QueryProcessing
    {
        public DataTable ExecuteQuery(ConnectionData connectionData, string queryText)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();
            
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var transaction = connection.BeginTransaction();

                    using (var adapter = new SqlDataAdapter(queryText, connectionString))
                    {
                        adapter.Fill(dataTable);
                        transaction.Commit();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }
    }
}