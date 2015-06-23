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
        public static string Reverse(string hex)
        {
            var converted = "";
            for (var i = hex.Length - 1; i >= 0; i -= 2)
            {
                converted = converted + hex.Substring(i - 1, 1);
                converted = converted + hex.Substring(i, 1);
            }
            return converted;
        }

        public static byte[] FromHex(string hex)
        {
            var raw = new byte[hex.Length / 2];
            for (var i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }

        public static List<Campo> LoopHexadecimal(string rowlog, List<Campo> campos, List<string> camposVariables)
        {
            //  var columnas=new List<string>();
            var recorrer = 10;

            for (var i = 0; i < campos.Count; i++)
            {
                switch (campos.ElementAt(i).Type)
                {
                    case "int":
                        campos.ElementAt(i).Valor = Conversions.ConvertToInt(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).ToString();
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "nchar":
                        campos.ElementAt(i).Valor = (Conversions.ConvertToVarchar(rowlog.Substring(recorrer, 17)));
                        recorrer += 17;
                        break;
                    case "char":
                        campos.ElementAt(i).Valor = (Conversions.ConvertToChar(rowlog.Substring(recorrer, 2)).ToString());
                        recorrer += 2;
                        break;
                    case "float":
                        campos.ElementAt(i).Valor = (Conversions.ConvertToDouble(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)));
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "bigint":
                        campos.ElementAt(i).Valor = (Conversions.ConvertToBigInt(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).ToString());
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "money":
                        campos.ElementAt(i).Valor = (Conversions.ConvertToMoney(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).
                            ToString(CultureInfo.InvariantCulture)); 
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "decimal":
                        campos.ElementAt(i).Valor = (Conversions.ConvertToDecimal(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).
                            ToString(CultureInfo.InvariantCulture));
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "real":
                        campos.ElementAt(i).Valor = (Conversions.ConvertToReal(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).
                            ToString(CultureInfo.InvariantCulture));
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "tinyint":
                        campos.ElementAt(i).Valor = (Conversions.ConvertToTinyInt(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)));
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "datetime":
                        campos.ElementAt(i).Valor = (Conversions.ConvertToDateTime(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)));
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    /* case "numeric":
                         campos.ElementAt(i).Valor = (ConvertToInt(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).ToString());
                         recorrer += campos.ElementAt(i).Tamaño;
                         break;*/
                }
            }

            if (camposVariables.Count == 0) return campos;
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
                campos.Add(new Campo()
                {
                    Nombre = camposVariables.ElementAt(i),
                    Type = "varchar",
                    Tamaño = tamano[i],
                    Valor = Conversions.ConvertToVarchar(rowlog.Substring(recorrer, tamano[i] - recorrer))

                });
                recorrer += tamano[i];
            }
            return campos;
        }

    }
}
