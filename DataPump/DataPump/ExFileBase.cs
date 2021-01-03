using System;

namespace DataPump
{
    // represents a base class for any ExH/D files.
    // contains only common utility functions.
    // does not contain any file-format-specific stuff.
    class ExFileBase
    {
        // reverse the array if it is in the opposite endian.
        protected void checkEndian(ref byte[] data, bool isBigEndian)
        {
            if (isBigEndian == BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }
        }

        // conversion functions that take care of endian.
        protected short toInt16(byte[] buffer, int offset, bool isBigEndian)
        {
            byte[] tmp = new byte[2];
            Array.Copy(buffer, offset, tmp, 0, 2);
            checkEndian(ref tmp, isBigEndian);
            return BitConverter.ToInt16(tmp, 0);
        }

        protected int toInt32(byte[] buffer, int offset, bool isBigEndian)
        {
            byte[] tmp = new byte[4];
            Array.Copy(buffer, offset, tmp, 0, 4);
            checkEndian(ref tmp, isBigEndian);
            return BitConverter.ToInt32(tmp, 0);
        }
    }
}
