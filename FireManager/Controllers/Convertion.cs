using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using FireManager.Models;

namespace FireManager.Controllers
{
    static class Conversions
    {
        private const double THREE_AND_ONE_THIRD = 10 / 3.0d;

        public static int ConvertToInt(string hex)
        {
            var converted = int.Parse(Utilities.Reverse(hex), NumberStyles.HexNumber);
            return converted;
        }

        public static string ConvertToDateTime(string hex)
        {
            var dateBytes = Utilities.FromHex(hex);
            
            return new DateTime(1900, 1, 1).AddDays(BitUtil.ToInt32(dateBytes, 4, true)).
                           AddMilliseconds(THREE_AND_ONE_THIRD * BitUtil.ToInt32(dateBytes, 0, true)).ToString(CultureInfo.InvariantCulture);
        }

        public static DateTime ConvertWindowsDate(byte[] bytes)
        {
            if (bytes.Length != 8) throw new ArgumentException();
            return DateTime.FromFileTimeUtc(BitConverter.ToInt64(bytes, 0));
        }

        public static char ConvertToChar(string hex)
        {
            var value = Convert.ToInt32(Utilities.Reverse(hex), 16);
            return (char) value;
        }

        public static string ConvertToTinyInt(string hex)
        {
            if (hex == null) throw new ArgumentNullException("hex");
            var data = Utilities.FromHex(Utilities.Reverse(hex));
            return ((int)data[0]).ToString();
        }

        public static string ConvertToDouble(string hex)
        {
            var parsed = long.Parse(Utilities.Reverse(hex), NumberStyles.AllowHexSpecifier);
            var d = BitConverter.Int64BitsToDouble(parsed);

            return  d.ToString(CultureInfo.InvariantCulture);
        }

        public static BigInteger ConvertToBigInt(string hex)
        {
            return BigInteger.Parse(Utilities.Reverse(hex), NumberStyles.HexNumber);
        }
        
        public static string ConvertToVarchar(string hex)
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

        public static double ConvertToDecimal(string hex)
        {
            var hexNumber = Utilities.Reverse(hex).Substring(0,14);
            hexNumber = hexNumber.Replace("x", string.Empty);
            long result;
            long.TryParse(hexNumber, NumberStyles.HexNumber, null, out result);
            return result;
        }

        public static string ConvertToSmallDateTime(byte[] data)
        {
            var returnDate = new DateTime(1900, 1, 1);

            int timePart = BitConverter.ToUInt16(data, 0);
            int datePart = BitConverter.ToUInt16(data, 2);

            returnDate = returnDate.AddDays(datePart).AddMinutes(timePart);

            return returnDate.ToString(CultureInfo.InvariantCulture);
        }

        public static float ConvertToReal(string hex)
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
     
    }
}
