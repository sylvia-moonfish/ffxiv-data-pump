using System;
using System.Collections.Generic;

namespace DataPump
{
    // represents a single row of the ExD data table.
    class ExDRow
    {
        public int Offset;
        public int Size;
        public short CheckDigit;
        public Dictionary<ExHColumn, ExDData> Data = new Dictionary<ExHColumn, ExDData>();
    }

    // represents ExD data table.
    class ExDFile : SqFile
    {
        // decode ExD from the raw data and populate this instance.
        public void DecodeExD()
        {
            // read the SqFile raw data.
            byte[] data = ReadData();

            // quit if no data is available.
            if (data == null || data.Length == 0) return;

            // retrieve offset entries and total row sizes from data header.
            int offsetEntriesSize = toInt32(data, 0x8, true);
            int totalRowSize = toInt32(data, 0xc, true);

            // copy offset entries from raw data for easier manipulation.
            // offset entries start from 0x20.
            byte[] offsetEntries = new byte[offsetEntriesSize];
            Array.Copy(data, 0x20, offsetEntries, 0, offsetEntriesSize);

            // copy all rows from raw data for easier manipulation.
            // rows start right after offset entries.
            byte[] rawRows = new byte[totalRowSize];
            Array.Copy(data, 0x20 + totalRowSize, rawRows, 0, totalRowSize);

            // going through each offset entry.
            // offset entry size is 0x8.
            for (int i = 0; i < offsetEntriesSize; i += 0x8)
            {
                ExDRow row = new ExDRow();


            }
        }
    }
}
