using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
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
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    var transaction = connection.BeginTransaction();

                    using (var adapter = new FbDataAdapter(queryText, connectionString))
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

        public DataTable ExecuteStoredProcedure(ConnectionData connectionData, string queryText)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    var transaction = connection.BeginTransaction();

                    var command = new FbCommand(queryText, connection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        
                    };

                    using (var reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
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