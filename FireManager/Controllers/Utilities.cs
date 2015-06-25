using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireManager.Models;

namespace FireManager.Controllers
{
    class Utilities
    {
      public static List<Field> LoopRowLog(string rowlog, List<Field> fields, List<string> camposVariables)
        {
            var recorrer = 10;

            for (var i = 0; i < fields.Count; i++)
            {
                switch (fields.ElementAt(i).Type)
                {
                    case "char":
                        fields.ElementAt(i).Value = (Conversions.ConvertToChar(rowlog.Substring(recorrer, 2)).ToString());
                        recorrer += 2;
                        break;
                    case "datetime":
                        fields.ElementAt(i).Value = (Conversions.ConvertToDateTime(rowlog.Substring(recorrer, fields.ElementAt(i).Length)));
                        recorrer += fields.ElementAt(i).Length;
                        break;
                    case "smalldatetime":
                        fields.ElementAt(i).Value = (Conversions.ConvertToSmallDateTime(rowlog.Substring(recorrer, fields.ElementAt(i).Length+6))).
                            ToString(CultureInfo.InvariantCulture);
                        recorrer += fields.ElementAt(i).Length;
                        break;
                    case "int":
                        fields.ElementAt(i).Value = Conversions.ConvertToInt(rowlog.Substring(recorrer, fields.ElementAt(i).Length)).ToString();
                        recorrer += fields.ElementAt(i).Length;
                        break;
                    case "bigint":
                        fields.ElementAt(i).Value = (Conversions.ConvertToBigInt(rowlog.Substring(recorrer, fields.ElementAt(i).Length)).ToString());
                        recorrer += fields.ElementAt(i).Length;
                        break;
                    case "tinyint":
                        fields.ElementAt(i).Value = (Conversions.ConvertToTinyInt(rowlog.Substring(recorrer, fields.ElementAt(i).Length)));
                        recorrer += fields.ElementAt(i).Length;
                        break;
                    case "decimal":
                        fields.ElementAt(i).Value = (Conversions.ConvertToDecimal(rowlog.Substring(recorrer, fields.ElementAt(i).Length - 10)).
                            ToString(CultureInfo.InvariantCulture));
                        recorrer += fields.ElementAt(i).Length - 10;
                        break;
                    case "money":
                        fields.ElementAt(i).Value = (Conversions.ConvertToMoney(rowlog.Substring(recorrer, fields.ElementAt(i).Length)).
                            ToString(CultureInfo.InvariantCulture));
                        recorrer += fields.ElementAt(i).Length;
                        break;
                    case "float":
                        fields.ElementAt(i).Value = (Conversions.ConvertToFloat(rowlog.Substring(recorrer, fields.ElementAt(i).Length)))
                            .ToString(CultureInfo.InvariantCulture);
                        recorrer += fields.ElementAt(i).Length;
                        break;
                    case "real":
                        fields.ElementAt(i).Value = (Conversions.ConvertToReal(rowlog.Substring(recorrer, fields.ElementAt(i).Length)).
                            ToString(CultureInfo.InvariantCulture));
                        recorrer += fields.ElementAt(i).Length;
                        break;
                   /* case "numeric":
                        fields.ElementAt(i).Value = (Conversions.ConvertToNumeric(rowlog.Substring(recorrer, fields.ElementAt(i).Length)));
                        recorrer += fields.ElementAt(i).Length;
                        break;*/
                    case "bit":
                        fields.ElementAt(i).Value = (Conversions.ConvertToBit(rowlog.Substring(recorrer, fields.ElementAt(i).Length)))
                            .ToString();
                        recorrer += fields.ElementAt(i).Length;
                        break;
                   case "binary":
                        fields.ElementAt(i).Value = (Conversions.ConvertToBinary(rowlog.Substring(recorrer, fields.ElementAt(i).Length)))
                            .ToString();
                        recorrer += fields.ElementAt(i).Length;
                        break;
                    case "nchar":
                        fields.ElementAt(i).Value = (Conversions.ConvertToVarchar(rowlog.Substring(recorrer, 17)));
                        recorrer += 17;
                        break;
                }
            }

            if (camposVariables.Count == 0) return fields;
            var totalColumnas = int.Parse(Conversions.ConvertToInt(rowlog.Substring(recorrer, 4)).ToString());
            recorrer += 4;
            recorrer += int.Parse((Math.Ceiling(((double)totalColumnas / 8)) * 2).ToString(CultureInfo.InvariantCulture));
            int.Parse(Conversions.ConvertToInt(rowlog.Substring(recorrer, 4)).ToString());
            recorrer += 4;

            var tamano = new int[camposVariables.Count];
            for (var i = 0; i < camposVariables.Count; i++)
            {
                tamano[i] = (Conversions.ConvertToInt(rowlog.Substring(recorrer, 4)) * 2) + 2; // +2 porque mi hex empieza con x0
                recorrer += 4;
            }

            for (var i = 0; i < camposVariables.Count; i++)
            {
                fields.Add(new Field()
                {
                    Name = camposVariables.ElementAt(i),
                    Type = "varchar",
                    Length = tamano[i],
                    Value = Conversions.ConvertToVarchar(rowlog.Substring(recorrer, tamano[i] - recorrer))
                });
                recorrer += tamano[i];
            }
            return fields;
        }
    }
}
