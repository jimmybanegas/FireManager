using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
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

        public Result ExecuteScript(ConnectionData conectionData, string queryText)
        {
            var result = new Result();
            var access = new DataAccess(conectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                FbScript fbs = new FbScript(queryText);
                fbs.Parse();

                // execute all statements
                FbBatchExecution fbe = new FbBatchExecution(new FbConnection(connectionString), fbs);
                fbe.Execute();

                result.Message = "Ejecutado";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result ;
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
                        CommandType = CommandType.StoredProcedure
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