using System;
using System.Data.SqlClient;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Server;
using FireManager.Models;

namespace FireManager.Controllers
{
    public class DataAccess
    {
        private readonly ConnectionData _connectionData;

        public DataAccess(ConnectionData connectionData)
        {
            _connectionData = new ConnectionData();
            _connectionData = connectionData;
        }

        public Result TestDatabaseConnection()
        {
            var result = new Result();
            try
            {
                var connectionString = CreateConnectionString();

                if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    var connection = new SqlConnection(connectionString);
                    connection.Open();

                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        result.Success = true;
                        result.Message = "Test satisfactorio";
                        result.ConnectionString = connectionString;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Test fallido";
                        result.ConnectionString = connectionString;
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

     

        public string CreateConnectionString()
        {
            var connectionString = string.Format("Server={0};User Id={1};Password={2};Database={3}",
                _connectionData.ServerName, _connectionData.UserName, _connectionData.Password, _connectionData.DatabaseName);

            return connectionString;
        }
    }
}