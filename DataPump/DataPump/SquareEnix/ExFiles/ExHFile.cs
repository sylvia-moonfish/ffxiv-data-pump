using System;

namespace DataPump.SquareEnix.ExFiles
{
    // Represents a column of the ExD data table.
    public class ExHColumn
    {
        public ushort Type;
        public ushort Offset;
    }

    // Represents a range for each ExD data table.
    public class ExHRange
    {
        public int Start;
        public int Length;
    }

    // Represents the language for each ExD data table.
    public class ExHLanguage
    {
        public byte Value;

        // Translates value into readable language code.
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

    // Represents the ExH type of SqFile. This is basically a header that contains information about multiple ExD data tables.
    public class ExHFile : ExFileBase
    {
        // Variant = 1 for ExD types.
        public ushort Variant;

        // Length of the data block that always has the fixed length.
        // For most of the columns this block contains the actual data.
        // For columns with varying lengths (like string column), this data block would contains offsets to where the actual string is.
        public ushort FixedSizeDataLength;

        // Columns for the ExD data table that belongs to this ExH.
        public ExHColumn[] Columns;

        // Ranges for this ExH. There can be multiple ranges of ExD data tables for single ExH.
        public ExHRange[] Ranges;

        // Languages for this ExH. There can be multiple languages for single ExH.
        public ExHLanguage[] Languages;

        // Decode ExH from the raw data and create new ExH instance.
        public ExHFile(SqFile sqFile)
        {
            // Read the SqFile raw data.
            byte[] data = sqFile.ReadData();

            // Quit if no data is available.
            if (data == null || data.Length == 0) return;

            // Some big endian values from fixed offset.
            FixedSizeDataLength = ToUInt16(data, 0x6, true);
            Variant = ToUInt16(data, 0x10, true);

            // Counts for various entries.
            ushort columnCount = ToUInt16(data, 0x8, true);
            ushort rangeCount = ToUInt16(data, 0xa, true);
            ushort langCount = ToUInt16(data, 0xc, true);

            // Only care about ExD data table type headers.
            if (Variant != 1) return;

            Columns = new ExHColumn[columnCount];
            for (int i = 0; i < columnCount; i++)
            {
                // Column offsets start after the fixed offset values (0x20).
                // Each column offset is 4 bytes long.
                int columnOffset = 0x20 + i * 0x4;
                Columns[i] = new ExHColumn()
                {
                    Type = ToUInt16(data, columnOffset, true),
                    Offset = ToUInt16(data, columnOffset + 0x2, true)
                };
            }

            Ranges = new ExHRange[rangeCount];
            for (int i = 0; i < rangeCount; i++)
            {
                // Range offsets start after the column offsets.
                // Each range offset is 8 bytes long.
                int rangeOffset = (0x20 + columnCount * 0x4) + i * 0x8;
                Ranges[i] = new ExHRange()
                {
                    Start = ToInt32(data, rangeOffset, true),
                    Length = ToInt32(data, rangeOffset + 0x4, true)
                };
            }

            Languages = new ExHLanguage[langCount];
            for (int i = 0; i < langCount; i++)
            {
                // Language offsets start after the range offsets.
                // Each language offset is 2 bytes long.
                int langOffset = ((0x20 + columnCount * 0x4) + rangeCount * 0x8) + i * 0x2;
                Languages[i] = new ExHLanguage()
                {
                    Value = data[langOffset]
                };
            }
        }

        // Iterate through all ranges of ExDFile under this ExH and execute given iterator function on each of them.
        // This does not iterate through language so the language code should be included in the fileNameFormat if applicable!
        public void Iterate(SqCache cache, string directoryName, string fileNameFormat, Action<ExDFile> iterator)
        {
            // Iterate through available ranges.
            for (int i = 0; i < Ranges.Length; i++)
            {
                ExHRange range = Ranges[i];

                iterator(new ExDFile(cache.GetFile(directoryName, string.Format(fileNameFormat, range.Start)), this));

                Program.ReportProgress(((double)i + 1) / Ranges.Length);
            }
        }
    }
}
