using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireManager.Models;

namespace FireManager.Controllers
{
    class SystemTables
    {
        public DataTable GetCharacterSets(ConnectionData connectionData)
        {
            return null;
        }

        public DataTable GetCheckConstraints()
        {
            return null;
        }

        public DataTable GetCheckConstraintsByTable()
        {
            return null;
        }

        public DataTable GetCollations()
        {
            return null;
        }

        public DataTable GetColumns()
        {
            return null;
        }

        public DataTable GetColumnPrivileges()
        {
            return null;
        }


        public DataTable GetDomains()
        {
            return null;
        }

        public DataTable GetForeignKeys()
        {
            return null;
        }

        public DataTable GetForeignKeyColumns()
        {
            return null;
        }

        public DataTable GetFunctions()
        {
            return null;
        }

        public DataTable GetGenerators()
        {
            return null;
        }

        public DataTable GetIndexes()
        {
            return null;
        }

        public DataTable GetIndexColumns()
        {
            return null;
        }

        public DataTable GetPrimaryKeys()
        {
            return null;
        }

        public DataTable GetProcedureParameters()
        {
            return null;
        }

        public DataTable GetProcedurePrivileges()
        {
            return null;
        }

        public DataTable GetProcedures()
        {
            return null;
        }

        public DataTable GetDataTypes()
        {
            return null;
        }

        public DataTable GetRoles()
        {
            return null;
        }

        public static StringBuilder GetTables(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS TABLE_CATALOG,
					null AS TABLE_SCHEMA,
					rdb$relation_name AS TABLE_NAME,
					null AS TABLE_TYPE,
					rdb$system_flag AS IS_SYSTEM_TABLE,
					rdb$owner_name AS OWNER_NAME,
					rdb$description AS DESCRIPTION,
					rdb$view_source AS VIEW_SOURCE
				FROM rdb$relations");

            if (restrictions != null)
            {
                int index = 0;

                /* TABLE_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* TABLE_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* TABLE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, "rdb$relation_name = @p{0}", index++);
                }

                /* TABLE_TYPE */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    if (where.Length > 0)
                    {
                        where.Append(" AND ");
                    }

                    switch (restrictions[3].ToString())
                    {
                        case "VIEW":
                            where.Append("rdb$view_source IS NOT NULL");
                            break;

                        case "SYSTEM TABLE":
                            where.Append("rdb$view_source IS NULL and rdb$system_flag = 1");
                            break;

                        case "TABLE":
                        default:
                            where.Append("rdb$view_source IS NULL and rdb$system_flag = 0");
                            break;
                    }
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rdb$system_flag, rdb$owner_name, rdb$relation_name");

            return sql;
        }

        public DataTable GetTableConstraints()
        {
            return null;
        }

        public DataTable GetTablePrivileges()
        {
            return null;
        }

        public DataTable GetTriggers()
        {
            return null;
        }

        public DataTable GetUniqueKeys()
        {
            return null;
        }

        public DataTable GetViewColumns()
        {
            return null;
        }

        public DataTable GetViews()
        {
            return null;
        }

        public DataTable GetViewPrivileges()
        {
            return null;
        }

    }
}
