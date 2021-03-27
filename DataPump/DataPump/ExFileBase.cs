using System;

namespace DataPump
{
    // represents a base class for any ExH/D files.
    // contains only common utility functions.
    // does not contain any file-format-specific stuff.
    class ExFileBase
    {
        // copy the data with specified length from buffer, process it with proper endian and return it.
        protected byte[] extractBytes(byte[] buffer, int offset, bool isBigEndian, int length)
        {
            byte[] bytes = new byte[length];
            Array.Copy(buffer, offset, bytes, 0, length);

            if (isBigEndian == BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return bytes;
        }

        // conversion functions that take care of endian.
        protected short toInt16(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToInt16(extractBytes(buffer, offset, isBigEndian, 2), 0);
        }

        protected ushort toUInt16(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToUInt16(extractBytes(buffer, offset, isBigEndian, 2), 0);
        }

        protected int toInt32(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToInt32(extractBytes(buffer, offset, isBigEndian, 4), 0);
        }

        protected uint toUInt32(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToUInt32(extractBytes(buffer, offset, isBigEndian, 4), 0);
        }

        protected long toInt64(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToInt64(extractBytes(buffer, offset, isBigEndian, 8), 0);
        }

        protected float toFloat(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToSingle(extractBytes(buffer, offset, isBigEndian, 4), 0);
        }

        protected double toDouble(byte[] buffer, int offset, bool isBigEndian)
        {
            return BitConverter.ToDouble(extractBytes(buffer, offset, isBigEndian, 8), 0);
        }
    }
}
