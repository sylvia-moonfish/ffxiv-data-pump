using System.Collections.Generic;

namespace DataPump
{
    // represents a column of the ExD data table.
    class ExHColumn
    {
        public ushort Type;
        public ushort Offset;
    }

    // represents a range for each ExD data table.
    class ExHRange
    {
        public int Start;
        public int Length;
    }

    // represents the language for each ExD data table.
    class ExHLanguage
    {
        public byte Value;
        
        // translat value into language code.
        public string Code
        {
            get
            {
                switch (Value)
                {
                    case 1:
                        return "ja";
                    case 2:
                        return "en";
                    case 3:
                        return "de";
                    case 4:
                        return "fr";
                    case 5:
                        return "chs";
                    case 6:
                        return "cht";
                    case 7:
                        return "ko";
                    default:
                        return null;
                }
            }
        }
    }

    // A file that contains ExH header. This header can contain information about multiple ExD data tables.
    class ExHFile : SqFile
    {
        // Variant = 1 for ExD data type headers.
        public ushort Variant;

        // length of the data block that contains the column definitions for ExD data table.
        public ushort FixedSizeDataLength;

        // columns for the ExD data table that belongs to this ExH.
        public ExHColumn[] Columns;

        // ranges for this ExH. There can be multiple ranges of ExD data tables for single ExH.
        public ExHRange[] Ranges;

        // languages for this ExH. There can be multiple languages for single ExH.
        public ExHLanguage[] Languages;

        // decode ExH from the raw data and populate this instance.
        public void DecodeExH()
        {
            // read the SqFile raw data.
            byte[] data = ReadData();

            // quit if no data is available.
            if (data == null || data.Length == 0) return;

            // some big endian values from fixed offset.
            FixedSizeDataLength = (ushort)toInt16(data, 0x6, true);
            Variant = (ushort)toInt16(data, 0x10, true);

            // counts for various entries.
            ushort columnCount = (ushort)toInt16(data, 0x8, true);
            ushort rangeCount = (ushort)toInt16(data, 0xa, true);
            ushort langCount = (ushort)toInt16(data, 0xc, true);

            // only care about ExD data table type headers.
            if (Variant != 1) return;

            Columns = new ExHColumn[columnCount];
            for (int i = 0; i < columnCount; i++)
            {
                // column offset start after the fixed offset values (0x20) and each column info is 4 bytes long.
                int columnOffset = 0x20 + i * 0x4;

                Columns[i] = new ExHColumn()
                {
                    Type = (ushort)toInt16(data, columnOffset, true),
                    Offset = (ushort)toInt16(data, columnOffset + 0x2, true)
                };
            }

            Ranges = new ExHRange[rangeCount];
            for (int i = 0; i < rangeCount; i++)
            {
                // range offset start after column offsets and each range info is 8 bytes long.
                int rangeOffset = (0x20 + columnCount * 0x4) + i * 0x8;

                Ranges[i] = new ExHRange()
                {
                    Start = toInt32(data, rangeOffset, true),
                    Length = toInt32(data, rangeOffset + 0x4, true)
                };
            }

            Languages = new ExHLanguage[langCount];
            for (int i = 0; i < langCount; i++)
            {
                // language offset start after range offsets and each language info is 2 bytes long.
                int langOffset = ((0x20 + columnCount * 0x4) + rangeCount * 0x8) + i * 0x2;

                Languages[i] = new ExHLanguage()
                {
                    Value = data[langOffset]
                };
            }
        }


    }
}
