using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireManager.Models;
using FireManager.Objects;

namespace FireManager.Controllers
{
    public class MetadataItemCreateStatement
    {
        public static string GetCreateDomainStatement()
        {
            return  "CREATE DOMAIN domain_name\n " +
                    "AS datatype [CHARACTER SET charset]\n" +
                    "DEFAULT {literal | NULL | USER}\n"+
                    "[NOT NULL]\n"+
                    "[CHECK (dom_search_condition)]\n"+
                    "COLLATE collation;\n";;
        }

        public static string GetCreateExceptionStatement()
        {
            return null;
        }

        public static string GetCreateFunctionStatement()
        {
           return "DECLARE EXTERNAL FUNCTION name [datatype | CSTRING (int) "+
           "[, datatype | CSTRING (int) ...]]\n"+
           "RETURNS {datatype [BY VALUE] | CSTRING (int)} [FREE_IT]\n"+
           "ENTRY_POINT 'entryname'\n"+
           "MODULE_NAME 'modulename';\n";
        }

        public static string GetCreateGeneratorStatement()
        {
            const string s = ("SET TERM ^ ;\n\n"+
                              "CREATE PROCEDURE name \n"+
                              " ( input_parameter_name < datatype>, ... ) \n"+
                              "RETURNS \n"+
                              " ( output_parameter_name < datatype>, ... )\n"+
                              "AS \n"+
                              "DECLARE VARIABLE variable_name < datatype>; \n"+
                              "BEGIN\n"+
                              "  /* write your code here */ \n"+
                              "END^\n\n"+
                              "SET TERM ; ^\n");
            return s;
        }

        public static string GetCreateRoleStatement()
        {
            return "CREATE ROLE role_name;\n";
        }

        public static string GetCreateTableStatement()
        {
            return "CREATE TABLE table_name\n"+
                    "(\n"+
                    "    column_name {< datatype> | COMPUTED BY (< expr>) | domain}\n"+
                    "        [DEFAULT { literal | NULL | USER}] [NOT NULL]\n"+
                    "    ...\n"+
                    "    CONSTRAINT constraint_name\n"+
                    "        PRIMARY KEY (column_list),\n"+
                    "        UNIQUE      (column_list),\n"+
                    "        FOREIGN KEY (column_list) REFERENCES other_table (column_list),\n"+
                    "        CHECK       (condition),\n"+
                    "    ...\n"+
                    ");\n";    

        }


        public static string GetCreateTriggerStatement()
        {
            return "SET TERM ^ ;\n\n"+
                "CREATE TRIGGER name [FOR table/view] \n"+
                " [IN]ACTIVE \n"+
                " [ON {[DIS]CONNECT | TRANSACTION {START | COMMIT | ROLLBACK}} ] \n"+
                " [{BEFORE | AFTER} INSERT OR UPDATE OR DELETE] \n"+
                " POSITION number \n"+
                "AS \n"+
                "BEGIN \n"+
                "    /* enter trigger code here */ \n"+
                "END^\n\n"+
                "SET TERM ; ^\n";
        }


        public static Result CrearDominio(Domain dominio)
        {
            return null;
        }

        public static Result CrearTabla(Table tabla)
        {
            return null;
        }


        public static Result CrearFuncion(Function funcion)
        {
            throw new NotImplementedException();
        }

        public static Result CrearGenerador(Generator generador)
        {
            throw new NotImplementedException();
        }

        public static Result CrearProcedimiento(Procedure procedimiento)
        {
            throw new NotImplementedException();
        }

        public static Result CrearTrigger(Trigger trigger)
        {
            throw new NotImplementedException();
        }

        public static Result CrearVista(MyView vista)
        {
            throw new NotImplementedException();
        }

        public static Result CrearUsuario(User usuario)
        {
            throw new NotImplementedException();
        }
    }
}
