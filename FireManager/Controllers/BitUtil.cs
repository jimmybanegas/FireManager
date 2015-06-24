using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FireManager.Controllers
{
    class BitUtil
    {
        private static long FromBytes(byte[] bytes, int offset, int count, bool littleEndian)
        {
            long ret = 0;
            if (littleEndian)
            {
                for (int i = 0; i < count; i++)
                {
                    ret = unchecked((ret << 8) | bytes[offset + count - 1 - i]);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    ret = unchecked((ret << 8) | bytes[offset + i]);
                }
            }
            return ret;
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

        private static byte[] ToBytes(long val, int count, bool littleEndian)
        {
            byte[] bytes = new byte[count];
            if (littleEndian)
            {
                for (int i = 0; i < count; i++)
                {
                    bytes[i] = unchecked((byte)(val & 0xff));
                    val = val >> 8;
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    bytes[count - i - 1] = unchecked((byte)(val & 0xff));
                    val = val >> 8;
                }
            }
            return bytes;
        }

        public static byte[] GetBytes(short val, bool littleEndian)
        {
            return ToBytes(val, 2, littleEndian);
        }

        public static short ToInt16(byte[] bytes, int offset, bool littleEndian)
        {
            return unchecked((short)(FromBytes(bytes, offset, 2, littleEndian)));
        }

        public static int ToInt32(byte[] bytes, int offset, bool littleEndian)
        {
            return unchecked((int)(FromBytes(bytes, offset, 4, littleEndian)));
        }

        public static long ToInt64(byte[] bytes, int offset, bool littleEndian)
        {
            return FromBytes(bytes, offset, 8, littleEndian);
        }

        public static ushort ToUInt16(byte[] bytes, int offset, bool littleEndian)
        {
            return unchecked((ushort)(FromBytes(bytes, offset, 2, littleEndian)));
        }

        public static uint ToUInt24(byte[] bytes, int offset, bool littleEndian)
        {
            return unchecked((uint)FromBytes(bytes, offset, 3, littleEndian));
        }

        public static uint ToUInt32(byte[] bytes, int offset, bool littleEndian)
        {
            return unchecked((uint)FromBytes(bytes, offset, 4, littleEndian));
        }

        public static float ToSingle(byte[] bytes, int offset, bool littleEndian)
        {
            return new Int32SingleUnion(ToInt32(bytes, offset, littleEndian)).AsSingle;
        }

        public static double ToDouble(byte[] bytes, int offset, bool littleEndian)
        {
            return BitConverter.Int64BitsToDouble(ToInt64(bytes, offset, littleEndian));
        }

        //thanks to Skeet's MiscUtils...
        [StructLayout(LayoutKind.Explicit)]
        private struct Int32SingleUnion
        {
            [FieldOffset(0)]
            int i;
            [FieldOffset(0)]
            float f;

            internal Int32SingleUnion(int i)
            {
                this.f = 0;
                this.i = i;
            }

            internal Int32SingleUnion(float f)
            {
                this.i = 0;
                this.f = f;
            }

            internal int AsInt32
            {
                get { return i; }
            }

            internal float AsSingle
            {
                get { return f; }
            }
        }
    }
}
