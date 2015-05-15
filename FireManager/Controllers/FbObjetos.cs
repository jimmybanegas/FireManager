using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using FireManager.Models;

namespace FireManager.Controllers
{
    class FbObjetos
    {
       public static DataTable GetCharacterSets(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    var pr = connection.GetSchema();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetCheckConstraints(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                   dataTable = connection.GetSchema("Tables", new string[] {null, null, null, "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetCheckConstraintsByTable(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetCollations(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetColumns(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetColumnPrivileges(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }


       public static DataTable GetDomains(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Domains");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetForeignKeys(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetForeignKeyColumns(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetFunctions(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Functions");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetGenerators(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Generators");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetIndexes(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetIndexColumns(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetPrimaryKeys(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetProcedureParameters(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetProcedurePrivileges(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetProcedures(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Procedures");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetDataTypes(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetRoles(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Roles");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetTables(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetTableConstraints(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetTablePrivileges(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetTriggers(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Triggers");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetUniqueKeys(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetViewColumns(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetViews(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Views");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

       public static DataTable GetViewPrivileges(ConnectionData connectionData)
        {
            var dataTable = new DataTable();
            var access = new DataAccess(connectionData);
            var connectionString = access.CreateConnectionString();

            try
            {
                using (var connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    dataTable = connection.GetSchema("Tables", new string[] {null, null, null, 
                              "TABLE"});
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
