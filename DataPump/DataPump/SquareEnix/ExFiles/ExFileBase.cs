using System;
using System.Text;

namespace DataPump.SquareEnix.ExFiles
{
    // Represents a base class for any Ex Header/Data files.
    // Contains only common utility functions.
    public class ExFileBase
    {
        // Utility function that prints byte array as hex string for debugging purposes.
        protected string PrintBytes(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:x2} ", b);
            }

            return sb.ToString();
        }

        // Copy the data with specified length from buffer, process it with proper endian and return it.
        protected byte[] ExtractBytes(byte[] buffer, int offset, bool isBigEndian, int length)
        {
            // Copy the contents from the buffer first.
            byte[] bytes = new byte[length];
            Array.Copy(buffer, offset, bytes, 0, length);

            // Do we need to reverse?
            if (isBigEndian == BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return bytes;
        }

        // Conversion functions with proper endian handling.
        protected short ToInt16(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToInt16(ExtractBytes(buffer, offset, isBigEndian, 2), 0);
        }

        protected ushort ToUInt16(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToUInt16(ExtractBytes(buffer, offset, isBigEndian, 2), 0);
        }

        protected int ToInt32(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToInt32(ExtractBytes(buffer, offset, isBigEndian, 4), 0);
        }

        protected uint ToUInt32(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToUInt32(ExtractBytes(buffer, offset, isBigEndian, 4), 0);
        }

        protected long ToInt64(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToInt64(ExtractBytes(buffer, offset, isBigEndian, 8), 0);
        }

        protected ulong ToUInt64(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToUInt64(ExtractBytes(buffer, offset, isBigEndian, 8), 0);
        }

        protected float ToSingle(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToSingle(ExtractBytes(buffer, offset, isBigEndian, 4), 0);
        }

        protected double ToDouble(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToDouble(ExtractBytes(buffer, offset, isBigEndian, 8), 0);
        }
    }
}
