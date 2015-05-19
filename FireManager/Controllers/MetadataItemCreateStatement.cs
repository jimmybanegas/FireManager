using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FireManager.EnumTypes;
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
            var result = new Result();
            var sql = new StringBuilder();

            try
            {
                var nulos = dominio.NoNulos ? "NOT NULL" : "";

                sql.Append(@"CREATE DOMAIN " + dominio.Nombre + "\r\n" +
                           "AS " + dominio.Tipo + "\r\n" + nulos + ";\r\n");

                if (dominio.Comentario != "")
                {
                    sql.Append("\r\n\rCOMMENT ON DOMAIN " + dominio.Nombre + " IS '" + dominio.Comentario + "';\r\n\r");  
                }

                result.Message = sql.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                
                result.Message=ex.Message;
            }
            
            return result;
        }

        public static Result CrearTabla(Table tabla)
        {
            var result = new Result();
            var sql = new StringBuilder();
            var comentarios = new StringBuilder();

            try
            {
                sql.Append(
                    @"CREATE TABLE "+tabla.Nombre+ "( \r\n");

                var primaryKeys = tabla.Campos.FindAll(x => x.EsLlavePrimaria).Select(x=>x.Nombre).ToArray();
                
                foreach (var campo in tabla.Campos)
                {
                    if (campo.NoNulos)
                    {
                        if (campo.Tamano > 0)
                        {
                            sql.Append("  "+campo.Nombre + " " + campo.Tipo + "(" + campo.Tamano + ") " + " NOT NULL ,\r\n"); 
                        }
                        else
                        {
                            sql.Append("  " + campo.Nombre + " " + (campo.Tipo) + " " + " NOT NULL ,\r\n");
                        }
                    }
                    else
                    {
                        if (campo.Tamano > 0)
                        {
                            sql.Append("  " + campo.Nombre + " " + campo.Tipo + "(" + campo.Tamano + ")" + " , \r\n");
                        }
                        else
                        {
                            sql.Append("  " + campo.Nombre + " " + campo.Tipo + " , \r\n");
                        }
                    }
                }

                sql.Append("  " + "PRIMARY KEY (");
           
                var campos = string.Join(",", primaryKeys);

                sql.Append( campos+ "),");
                

                if (tabla.Foraneas.Count >= 0)
                {
                    foreach (var foreignKey in tabla.Foraneas)
                    {
                        sql.Append("\r\n\r CONSTRAINT " + foreignKey.Nombre +
                                   " FOREIGN KEY ("+foreignKey.Campo+")\r\n " +
                                   " REFERENCES "+foreignKey.TablaReferida+"("+foreignKey.CampoReferico+"),");
                    }

                    sql.Length -= 1;
                    sql.Append("\r\n);");
                }
                else
                {
                    sql.Length -= 1;
                    sql.Append("\r\n);");
                }


                if (tabla.Comentario != "")
                {
                    comentarios.Append("\r\n\rCOMMENT ON TABLE " + tabla.Nombre + " IS '"+tabla.Comentario+"';\r\n\r");
                }
                

                if (tabla.Indices.Count > 0)
                {
                    foreach (var indice in tabla.Indices)
                    {
                        var indices = indice.Campos.Select(x => x.Nombre).ToArray();

                        var ind = string.Join(",", indices);

                        sql.Append("\r\n\rCREATE INDEX " + indice.Nombre+ " \r\n ON "+tabla.Nombre+"\r\n "
                            +"("+ind+");\r\n\r");

                        if (indice.Comentario != "")
                        {
                            comentarios.Append("\r\nCOMMENT ON INDEX " + indice.Nombre + " IS '" + indice.Comentario + "';\r\n\r");
                        }
                    }
                }

                sql.Append(comentarios);

                result.Message = sql.ToString().ToUpper();

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            
            return result;
        }
        
        public static Result CrearFuncion(Function funcion)
        {
            var result = new Result();
            var sql = new StringBuilder();

            try
            {
                var parametros = funcion.Parametros.Select(x => x.Tipo).ToArray();
               // var camposSeparados  = string.Join(",", campos);

                var campoReturn = funcion.Parametros.Find(x => x.IsReturn);

                sql.Append(@"DECLARE EXTERNAL FUNCTION " + funcion.Nombre + "\r\n");

                foreach (var parametro in funcion.Parametros.Where(x=>!x.IsReturn))
                {
                    if (parametro.Tamano > 0)
                    {
                        sql.Append(parametro.Tipo+"("+parametro.Tamano+") ,");
                    }
                    else
                    {
                        sql.Append(parametro.Tipo + ",");
                    }
                }

                sql.Length -= 1;

                if (campoReturn.Tamano > 0)
                {
                    sql.Append("\r\nRETURNS " + campoReturn.Tipo + "(" + campoReturn.Tamano + ") ");
                }
                else
                {
                    sql.Append("\r\nRETURNS " +campoReturn.Tipo);
                }

                if (campoReturn.Mecanismo == MechanismFunctionParameter.Valor)
                {
                    sql.Append(" BY VALUE "+"\r\n");
                }

                sql.Append("\nENTRY_POINT ' '\r\n" +
                    "MODULE_NAME ' ';\r\n");

                if (funcion.Comentario != "")
                {
                    sql.Append("\r\nCOMMENT ON EXTERNAL FUNCTION " + funcion.Nombre + " IS '" + funcion.Comentario + "';\r\n\r");
                }
                
                result.Message = sql.ToString().ToUpper();
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }

            return result;
        }

        public static Result CrearGenerador(Generator generador)
        {
            var result = new Result();
            var sql = new StringBuilder();

            try
            {
                sql.Append(@"CREATE SEQUENCE " + generador.Nombre + ";\r\n");

                sql.Append("\r\n\rALTER SEQUENCE " + generador.Nombre + " RESTART WITH " + generador.Tamano + ";\r\n\r");

                result.Message = sql.ToString().ToUpper();   
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }

            return result;
        }

        public static Result CrearProcedimiento(Procedure procedimiento)
        {
            var result = new Result();
            var sql = new StringBuilder();

            try
            {
                var input = procedimiento.Parametros.FindAll(x => x.Scope == ScopeProcedureParameter.Input);

                var output = procedimiento.Parametros.FindAll(x => x.Scope==ScopeProcedureParameter.Output);

                sql.Append(@"SET TERM ^ ; " + "\r\n" +
                           "\r\n\rRECREATE PROCEDURE " + procedimiento.Nombre + "(\r\n");


                foreach (var parametro in input)
                {
                    if (parametro.Tamano > 0)
                    {
                        sql.Append(parametro.Nombre+" "+parametro.Tipo+"("+parametro.Tamano+"),");
                    }
                    else
                    {
                        sql.Append(parametro.Nombre + " " + parametro.Tipo + ",");
                    }
                }

                sql.Length -= 1;

                sql.Append(") \r\n" + "RETURNS (");

                foreach (var parametro in output)
                {
                    if (parametro.Tamano > 0)
                    {
                        sql.Append(parametro.Nombre + " " + parametro.Tipo + "(" + parametro.Tamano + "),");
                    }
                    else
                    {
                        sql.Append(parametro.Nombre + " " + parametro.Tipo + ",");
                    }
                }
                
                sql.Length -= 1;

                sql.Append(") \r\n");

                sql.Append("AS \r\n" +
                "BEGIN \r\n" +
                "   " + procedimiento.Definicion + "\r\n" +
                "END^\r\n\r" +
                "\nSET TERM ; ^\r\n");

                if (procedimiento.Comentario != "")
                {
                    sql.Append("\r\n\rCOMMENT ON PROCEDURE " + procedimiento.Nombre + " IS '" + procedimiento.Comentario + "';\r\n\r");
                }

                result.Message = sql.ToString().ToUpper();
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }

            return result;
        }

        public static Result CrearTrigger(Trigger trigger)
        {
            var result = new Result();
            var sql = new StringBuilder();

            try
            {
                var activo = trigger.Activo ? "ACTIVE" : "INACTIVE";
                
                sql.Append(@"SET TERM ^ ; "+"\r\n"+
                "\r\n\rCREATE TRIGGER "+trigger.Nombre+" FOR "+trigger.Tabla+" \r\n"+
                " "+activo+" " +trigger.Tipo+" "+trigger.Evento+" POSITION "+trigger.Posicion+" \r\n"+
                "AS \r\n"+
                "BEGIN \r\n"+
                "   "+trigger.Definicion+ "\r\n"+
                "END^\r\n\r"+
                "\nSET TERM ; ^\r\n");

                if (trigger.Comentario != "")
                {
                    sql.Append("\r\n\rCOMMENT ON TRIGGER " + trigger.Nombre + " IS '" + trigger.Comentario + "';\r\n\r");
                }

                result.Message = sql.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public static Result CrearVista(MyView vista)
        {
            var result = new Result();
            var sql = new StringBuilder();

            var nombresCampos = vista.Campos.Select(campo => campo.Replace(".", "_")).ToList();

            var tablas = vista.Campos.Select(campo => campo.Substring(0, campo.IndexOf('.'))).Distinct().ToList();

            try
            {
                sql.Append ( @"CREATE VIEW "+vista.Nombre+ "( \r\n");

                sql.Append(string.Join(",",nombresCampos) + ") \r\nAS \r\nSELECT\r\n");

                var campos = string.Join(",", vista.Campos);

                sql.Append(campos + "\r\nFROM\r\n");

                sql.Append(string.Join(",",tablas));
               
                result.Message = sql.ToString().ToUpper();
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }

            return result;
        }

        public static Result CrearUsuario(User usuario)
        {
            var result = new Result();
            var sql = new StringBuilder();

            try
            {
                sql.Append(@"CREATE USER "+usuario.Nombre+"\r\n");
                sql.Append(" PASSWORD '" + usuario.Contraseña+"'\r\n");
                sql.Append(" FIRSTNAME '" + usuario.Contraseña + "'\r\n");
                sql.Append(" LASTNAME '" + usuario.Contraseña + "';\r\n");

                result.Message = sql.ToString().ToUpper();
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }

            return result;
        }
    }
}
