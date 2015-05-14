using System;
using FirebirdSql.Data.FirebirdClient;
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
                    var connection = new FbConnection(connectionString);
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

        public Result CreateDatabase()
        {
            var result = new Result();
            try
            {
                var connectionString = CreateConnectionString();

                if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    FbConnection.CreateDatabase(connectionString);
                }
                result.Success = true;
                result.Message = "Creada";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public Result DropDatabase()
        {
            var result = new Result();
            try
            {
                var connectionString = CreateConnectionString();

                if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    FbConnection.DropDatabase(connectionString);
                }
                result.Success = true;
                result.Message = "Borrada";
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
            var connectionString = string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4}",
                _connectionData.ServerName, _connectionData.PortNumber, _connectionData.UserName, _connectionData.Password, _connectionData.DatabaseName);

            return connectionString;
        }
    }
}