using System;
using System.Collections.Generic;

namespace DataPump
{
    // represents a single row of the ExD data table.
    class ExDRow
    {
        public int Key;
        public int Offset;
        public int Size;
        public short CheckDigit;
        public Dictionary<ExHColumn, ExDData> Data = new Dictionary<ExHColumn, ExDData>();
    }

    // represents ExD data table.
    class ExDFile : ExFileBase
    {
        // data rows.
        public List<ExDRow> Rows = new List<ExDRow>();

        // decode ExD from the raw data and create new ExD instance.
        public ExDFile(SqFile sqFile, ExHFile headerFile)
        {
            // read the SqFile raw data.
            byte[] data = sqFile.ReadData();

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

                // first 32 bits of the offset entry is the key for the row that we're reading.
                row.Key = toInt32(offsetEntries, i, true);

                // next 32 bits are the actual offset.
                row.Offset = toInt32(offsetEntries, i + 0x4, true);

                // the offset includes the offset entries and 0x20 bytes for the raw header.
                // actual position in the raw data would be offset - raw header - offset entries.
                int rawRowPosition = row.Offset - 0x20 - offsetEntriesSize;

                // first 4 bytes in the raw data is the size of the raw data.
                row.Size = toInt32(rawRows, rawRowPosition, true);

                // next 2 bytes is the check digit.
                row.CheckDigit = toInt16(rawRows, rawRowPosition + 0x4, true);

                // after the size and the check digit, the raw data is actually divided into two sections.
                // first section is the fixed size data that contains information for possible column definitions. (if the column value is complex.)
                byte[] columnDefinitions = new byte[headerFile.FixedSizeDataLength];
                Array.Copy(rawRows, rawRowPosition + 0x6, columnDefinitions, 0, headerFile.FixedSizeDataLength);

                // second section is the actual data.
                byte[] actualData = new byte[row.Size - headerFile.FixedSizeDataLength];
                Array.Copy(rawRows, rawRowPosition + 0x6 + headerFile.FixedSizeDataLength, actualData, 0, actualData.Length);


            }
        }
    }
}
