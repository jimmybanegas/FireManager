using System;
using FirebirdSql.Data.FirebirdClient;

namespace FireManager
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
                        result.Message = "Connection Test Passed";
                        result.ConnectionString = connectionString;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Connection Test Failed";
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

            // Set the ServerType to 1 for connect to the embedded server
         /*   string connectionString =
            "User=SYSDBA;" +
            "Password=masterkey;" +
            "Database=SampleDatabase.fdb;" +
            "DataSource=localhost;" +
            "Port=3050;" +
            "Dialect=3;" +
            "Charset=NONE;" +
            "Role=;" +
            "Connection lifetime=15;" +
            "Pooling=true;" +
            "MinPoolSize=0;" +
            "MaxPoolSize=50;" +
            "Packet Size=8192;" +
            "ServerType=0";*/

            var connectionString = string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4}",
                _connectionData.ServerName, _connectionData.PortNumber, _connectionData.UserName, _connectionData.Password, _connectionData.DatabaseName);

            return connectionString;
        }
    }
}