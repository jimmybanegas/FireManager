using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using FireManager.Models;

namespace FireManager.Controllers
{
    static class Conversiones
    {
        public static string DarleVuelta(string hex)
        {
            var converted = "";
            for (var i=hex.Length-1;i>=0;i-=2)
            {
                converted = converted+hex.Substring(i-1, 1);
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

        public static int Conversion_a_Int(string hex)
        {
            var converted = int.Parse(DarleVuelta(hex), NumberStyles.HexNumber);
            return converted;
        }


        public static string Conversion_a_DateTime(string hex)
        {
            var data=FromHex(DarleVuelta(hex));
           // if (data.Length != 4) throw new ArgumentException();
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(
                      BitConverter.ToUInt32(data, 0)).ToString(CultureInfo.InvariantCulture);
        }


        public static char Conversion_a_Char(string hex)
        {
            var value = Convert.ToInt32(DarleVuelta(hex), 16);
            return (char) value;
        }

        public static string Conversion_a_TinyInt(string hex)
        {
            if (hex == null) throw new ArgumentNullException("hex");
            var data = FromHex(DarleVuelta(hex));
            return ((int)data[0]).ToString();
        }

        public static string Conversion_a_Double(string hex)
        {
            var parsed = long.Parse(DarleVuelta(hex), NumberStyles.AllowHexSpecifier);
            var d = BitConverter.Int64BitsToDouble(parsed);

            return  d.ToString(CultureInfo.InvariantCulture);
        }

        public static BigInteger Conversion_a_BigInt(string hex)
        {
            return BigInteger.Parse(DarleVuelta(hex), NumberStyles.HexNumber);
        }
        
        public static string Conversion_a_String_Varchar(string hex)
        {
            var sData = "";
            while (hex.Length > 0)
            {
                var data1 = Convert.ToChar(Convert.ToUInt32(hex.Substring(0, 2), 16)).ToString();
                sData = sData + data1;
                hex = hex.Substring(2, hex.Length - 2);
            }
            return sData;
        }

        private static double Conversion_a_Decimal(string hex)
        {
            var hexNumber = DarleVuelta(hex).Substring(0,14);
            hexNumber = hexNumber.Replace("x", string.Empty);
            long result;
            long.TryParse(hexNumber, NumberStyles.HexNumber, null, out result);
            return result;
        }

        public static string Conversion_a_SmallDateTime(byte[] data)
        {
            var returnDate = new DateTime(1900, 1, 1);

            int timePart = BitConverter.ToUInt16(data, 0);
            int datePart = BitConverter.ToUInt16(data, 2);

            returnDate = returnDate.AddDays(datePart).AddMinutes(timePart);

            return returnDate.ToString(CultureInfo.InvariantCulture);
        }

        public static float Conversion_del_Real(string hex)
        {
            var raw = new byte[hex.Length / 2];
            for (var i = 0; i < raw.Length; i++)
            {
                //raw[raw.Length - i - 1] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            var f = BitConverter.ToSingle(raw, 0);
            return f;
        }

        public static List<Campos> Recorrer(string rowlog,List<Campos> campos,List<string>camposVariables )
        {
          //  var columnas=new List<string>();
            var recorrer = 10;

            for (var i = 0; i < campos.Count ;i++ )
            {
                switch (campos.ElementAt(i).Type)
                {
                    case "int":
                        campos.ElementAt(i).Valor=Conversion_a_Int(rowlog.Substring(recorrer,campos.ElementAt(i).Tamaño)).ToString();
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "nchar":
                        campos.ElementAt(i).Valor = (Conversion_a_String_Varchar(rowlog.Substring(recorrer,17)));
                        recorrer += 17;
                     /*   camposVariables.Add(new Campos()
                        {
                          Nombre   = campos.ElementAt(i).Nombre,
                          Type = "varchar"
                        });*/
                        break;
                    case "char":
                        campos.ElementAt(i).Valor = (Conversion_a_Char(rowlog.Substring(recorrer, 4)).ToString());
                        recorrer += 4;
                        break;
                    case "float":
                        campos.ElementAt(i).Valor = (Conversion_a_Double(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)));
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "bigint":
                        campos.ElementAt(i).Valor = (Conversion_a_BigInt(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).ToString());
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "money":
                        campos.ElementAt(i).Valor = (Conversion_a_Decimal(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).
                            ToString(CultureInfo.InvariantCulture));
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "decimal":
                        campos.ElementAt(i).Valor = (Conversion_a_Decimal(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).
                            ToString(CultureInfo.InvariantCulture));
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "real":
                        campos.ElementAt(i).Valor = (Conversion_del_Real(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).
                            ToString(CultureInfo.InvariantCulture));
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "tinyint":
                        campos.ElementAt(i).Valor = (Conversion_a_TinyInt(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)));
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "datetime":
                        campos.ElementAt(i).Valor = (Conversion_a_DateTime(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)));
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                   /* case "numeric":
                        campos.ElementAt(i).Valor = (Conversion_a_Int(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).ToString());
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;*/
                }
            }

            if (camposVariables.Count == 0) return campos;
            var totalColumnas = int.Parse(Conversion_a_Int(rowlog.Substring(recorrer, 4)).ToString());
            recorrer += 4;
            recorrer += int.Parse((Math.Ceiling(((double)totalColumnas / 8)) * 2).ToString(CultureInfo.InvariantCulture));
            int.Parse(Conversion_a_Int(rowlog.Substring(recorrer, 4)).ToString());
            recorrer += 4;

            var tamano = new int[camposVariables.Count];
            for (var i = 0; i < camposVariables.Count; i++)
            {
                tamano[i]=(Conversion_a_Int(rowlog.Substring(recorrer, 4))*2)+2; // +2 porque mi hex empieza con x0
                recorrer += 4;
            }

            for (var i = 0; i < camposVariables.Count; i++)
            {
                    
                campos.Add(new Campos()
                {
                    Nombre = camposVariables.ElementAt(i),
                    Type = "varchar",
                    Tamaño = tamano[i],
                    Valor = Conversion_a_String_Varchar(rowlog.Substring(recorrer, tamano[i]-recorrer))
                        
                });
                recorrer += tamano[i];
            }
            return campos;
        }
    }
}
