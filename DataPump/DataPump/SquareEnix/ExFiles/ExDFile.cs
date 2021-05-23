using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPump.SquareEnix.ExFiles
{
    // Represents a data cell in ExD data table.
    // Can contain any type of data so be sure to do type-check!
    public class ExDData
    {
        public Type Type;
        public object Value;

        // Typed getter for convenience.
        public T GetAsTyped<T>()
        {
            if (Type != typeof(T)) throw new InvalidOperationException();
            return (T)Value;
        }
    }

    // Represents a data row in ExD data table.
    public class ExDRow
    {
        public ExDFile Parent;
        public int Key;
        public int Offset;
        public int Size;
        public short CheckDigit;
        public Dictionary<ExHColumn, ExDData> Data = new Dictionary<ExHColumn, ExDData>();

        // Get the data by column index.
        public ExDData GetDataByIndex(int index)
        {
            return Data[Parent.Header.Columns[index]];
        }
    }

    // Represents the ExD type of SqFile that contains ExD data tables.
    public class ExDFile : ExFileBase
    {
        // ExH that represents this ExD instance.
        public ExHFile Header;

        // Data rows.
        public List<ExDRow> Rows = new List<ExDRow>();

        // Get the row by key.
        public ExDRow GetRowByKey(int key)
        {
            return Rows.FirstOrDefault(row => row.Key == key);
        }

        // Decode ExD from the raw data and create new ExD instance.
        public ExDFile(SqFile sqFile, ExHFile exHFile)
        {
            Header = exHFile;

            // Read the raw data from SqFile.
            byte[] data = sqFile.ReadData();

            // Quit if no data is available.
            if (data == null || data.Length == 0) return;

            // Retrieve offset entries and total row sizes from the data header.
            int offsetEntriesSize = ToInt32(data, 0x8, true);
            int totalRowSize = ToInt32(data, 0xc, true);

            // Copy offset entries from raw data for easier manipulation.
            // Offset entries start from 0x20.
            byte[] offsetEntries = new byte[offsetEntriesSize];
            Array.Copy(data, 0x20, offsetEntries, 0, offsetEntriesSize);

            // Copy all rows from raw data for easier manipulation.
            // Rows start right after offset entries.
            byte[] rawRows = new byte[totalRowSize];
            Array.Copy(data, 0x20 + offsetEntriesSize, rawRows, 0, totalRowSize);

            // Going through each offset entry.
            // Offset entry size is 0x8.
            for (int i = 0; i < offsetEntriesSize; i += 0x8)
            {
                ExDRow row = new ExDRow();
                row.Parent = this;

                // First 32 bits of the offset entry is the key for the row that we're reading.
                row.Key = ToInt32(offsetEntries, i, true);

                // Next 32 bits are the actual offset.
                row.Offset = ToInt32(offsetEntries, i + 0x4, true);

                // The offset includes the offset entries and 0x20 bytes for the raw header.
                // Actual position in the raw row byte array would be offset - raw header size - offset entries size.
                int rawRowPosition = row.Offset - 0x20 - offsetEntriesSize;

                // First 4 bytes in the raw row data is the size of the raw data.
                row.Size = ToInt32(rawRows, rawRowPosition, true);

                // Next 2 bytes are the check digit.
                row.CheckDigit = ToInt16(rawRows, rawRowPosition + 0x4, true);

                // After the size and the check digit, the raw data is actually divided into two sections.
                // First section is the fixed size data.
                // Copy it over to separate array for easier manipulation.
                byte[] fixedSizeData = new byte[exHFile.FixedSizeDataLength];
                Array.Copy(rawRows, rawRowPosition + 0x6, fixedSizeData, 0, exHFile.FixedSizeDataLength);

                // Finally, rest of the raw row is the second section which contains the additional data that are used for some columns with varying lengths. (i.e. string type)
                byte[] additionalData = new byte[row.Size - exHFile.FixedSizeDataLength];
                Array.Copy(rawRows, rawRowPosition + 0x6 + exHFile.FixedSizeDataLength, additionalData, 0, additionalData.Length);

                // Let's go through each column of this row now.
                foreach (ExHColumn column in exHFile.Columns)
                {
                    ExDData parsedData = new ExDData();

                    switch (column.Type)
                    {
                        // String type.
                        case 0x0:
                            // The first 4 bytes of the fixed size data contain the starting offset for the additional data section.
                            int valueStart = ToInt32(fixedSizeData, column.Offset, true);

                            // The additional data is 0-terminated.
                            int valueEnd = valueStart;
                            while (valueEnd < additionalData.Length && additionalData[valueEnd] != 0) valueEnd++;

                            // Copy the value from additional data to new byte array for decoding.
                            byte[] field = new byte[valueEnd - valueStart];
                            Array.Copy(additionalData, valueStart, field, 0, field.Length);

                            // Decode it as string.
                            parsedData.Type = typeof(string);
                            parsedData.Value = DecodeString(field);
                            break;

                        // Bool type.
                        case 0x1:
                            // The first byte of the fixed size data is the boolean value.
                            parsedData.Type = typeof(bool);
                            parsedData.Value = fixedSizeData[column.Offset] != 0;
                            break;

                        // Signed byte type.
                        case 0x2:
                            // The first byte of the fixed size data is the value.
                            parsedData.Type = typeof(sbyte);
                            parsedData.Value = (sbyte)fixedSizeData[column.Offset];
                            break;

                        // Byte type.
                        case 0x3:
                            // The first byte of the fixed size data is the value.
                            parsedData.Type = typeof(byte);
                            parsedData.Value = fixedSizeData[column.Offset];
                            break;

                        // Short type.
                        case 0x4:
                            // The first 2 bytes of the fixed size data are the value.
                            parsedData.Type = typeof(short);
                            parsedData.Value = ToInt16(fixedSizeData, column.Offset, true);
                            break;

                        // Ushort type.
                        case 0x5:
                            // The first 2 bytes of the fixed size data are the value.
                            parsedData.Type = typeof(ushort);
                            parsedData.Value = ToUInt16(fixedSizeData, column.Offset, true);
                            break;

                        // Int type.
                        case 0x6:
                            // The first 4 bytes of the fixed size data are the value.
                            parsedData.Type = typeof(int);
                            parsedData.Value = ToInt32(fixedSizeData, column.Offset, true);
                            break;

                        // Uint type.
                        case 0x7:
                            // The first 4 bytes of the fixed size data are the value.
                            parsedData.Type = typeof(uint);
                            parsedData.Value = ToUInt32(fixedSizeData, column.Offset, true);
                            break;

                        // Float type.
                        case 0x9:
                            // The first 4 bytes of the fixed size data are the value.
                            parsedData.Type = typeof(float);
                            parsedData.Value = ToSingle(fixedSizeData, column.Offset, true);
                            break;

                        // Long type.
                        case 0xb:
                            // The first 8 bytes of the fixed size data are the value.
                            parsedData.Type = typeof(long);
                            parsedData.Value = ToInt64(fixedSizeData, column.Offset, true);
                            break;

                        // Masked boolean types.
                        // The first byte of the fixed size data contains the boolean value, where the bit offset is type value - 0x19 from right.
                        case 0x19:
                        case 0x1a:
                        case 0x1b:
                        case 0x1c:
                        case 0x1d:
                        case 0x1e:
                        case 0x1f:
                        case 0x20:
                            parsedData.Type = typeof(bool);
                            parsedData.Value = (fixedSizeData[column.Offset] & (0x1 << (column.Type - 0x19))) != 0;
                            break;

                        // Unrecognized type.
                        default:
                            throw new Exception($"Unrecognized column type: 0x{column.Type.ToString("x")}");
                    }

                    row.Data.Add(column, parsedData);
                }

                Rows.Add(row);
            }
        }

        // Iterate through all rows under this ExDFile and execute given iterator function on each of them.
        public void Iterate(Action<ExDRow> iterator)
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                ExDRow row = Rows[i];

                iterator(row);

                Program.ReportInnerProgress(((double)i + 1) / Rows.Count);
            }
        }

        // Decode ExD string type column raw data into plain string.
        private string DecodeString(byte[] field)
        {
            // We'll append utf8-encoded string as bytes here, then convert all of them into utf8 string later.
            List<byte> byteList = new List<byte>();

            // Go byte by byte.
            for (int i = 0; i < field.Length; i++)
            {
                // If not tag, just store the byte as it is and decode it later as utf8.
                if (field[i] != 0x2)
                {
                    byteList.Add(field[i]);
                }
                // If it's start of tag (0x2), start decoding it as tag.
                else
                {
                    byteList.AddRange(DecodeTag(field, ref i));
                }
            }

            // Since all tags are converted to appropriate string representation, just convert everything as utf8 string.
            return new UTF8Encoding(false).GetString(byteList.ToArray());
        }

        // Decode a tag inside ExD string type column into a string representation then return it as a byte array.
        // After decoding, this function will advance the offset received in the parameter.
        private byte[] DecodeTag(byte[] data, ref int offset)
        {
            // Reject if not proper tag.
            if (data[offset] != 0x2) return new byte[0];

            // After the opening of the tag (0x2), the next byte is the tag type.
            offset++;
            byte tagType = data[offset];

            // After tag type, the next bytes are the numeric value that represents the length of the tag.
            offset++;
            int length = DecodeNumeric(data, ref offset);

            // Copy over the tag and increment the offset accordingly.
            byte[] tag = new byte[length];
            Array.Copy(data, offset, tag, 0, length);
            offset += length;

            // Check the closing of the tag.
            if (data[offset] != 0x3) throw new Exception($"Tag doesn't end with 0x3: {PrintBytes(tag)}");

            // Decode the tag by type.
            // Passing the copied version of the tag so we don't interfere with the offset.
            return DecodeTagByType(tagType, tag);
        }

        // Decode a tag by given tag type.
        private byte[] DecodeTagByType(byte tagType, byte[] tag)
        {
            // Declaring some commonly used variables here.
            int offset = 0;
            int opening;

            // Decode by tag type...
            switch (tagType)
            {
                // New line.
                case 0x10:
                    // This tag always contains only new line character, so it's safe to ignore the data and just return new line.
                    return new UTF8Encoding(false).GetBytes("<br />");

                // Soft hyphen.
                case 0x16:
                    // This tag always contains only soft-hyphen, so just return it.
                    return new UTF8Encoding(false).GetBytes("\u00ad");

                // Emphasis.
                case 0x1a:
                    if (tag.Length != 1) throw new Exception($"Error while decoding emphasis (0x1a) tag. Tag length is not 1: {PrintBytes(tag)}");

                    // The starting bytes of the tag are the numeric value that represents opening/closing of the tag.
                    opening = DecodeNumeric(tag, ref offset);

                    // If opening is 1, it means this tag is the opening of the emphasis.
                    if (opening == 1)
                    {
                        return new UTF8Encoding(false).GetBytes("<em>");
                    }
                    // If opening is 0, it means this tag is the closing of the emphasis.
                    else if (opening == 0)
                    {
                        return new UTF8Encoding(false).GetBytes("</em>");
                    }

                    throw new Exception($"Error while decoding emphasis (0x1a) tag. Tag opening is not known: {opening}");

                // Dash.
                case 0x1f:
                    // This tag always contains only dash character, so it's safe to ignore the data and just return dash.
                    return new UTF8Encoding(false).GetBytes("-");

                // UI tag.
                case 0x48:
                    // The starting bytes of the tag are the numeric value that represents the type of the tag.
                    opening = DecodeNumeric(tag, ref offset);

                    // If opening is 0, it means this tag is the closing of the UI tag.
                    if (opening == 0)
                    {
                        return new UTF8Encoding(false).GetBytes("</ui>");
                    }
                    // If opening is not 0, it means this tag is the opening of the UI tag with special value equal to the opening value.
                    else
                    {
                        return new UTF8Encoding(false).GetBytes($"<ui value=\"0x{opening.ToString("x")}\">");
                    }

                // UI color decoration tag.
                case 0x49:
                    // The starting bytes of the tag are the numeric value the represents the type of the tag.
                    opening = DecodeNumeric(tag, ref offset);

                    // If opening is 0, it means this tag is the closing of the UI color tag.
                    if (opening == 0)
                    {
                        return new UTF8Encoding(false).GetBytes("</uiColor>");
                    }
                    // If opening is not 0, it means this tag is the opening of the UI color tag with special value equal to the opening value.
                    else
                    {
                        return new UTF8Encoding(false).GetBytes($"<uiColor value=\"0x{opening.ToString("x")}\">");
                    }

                default:
                    // Unrecognized tag.
                    throw new Exception($"Unrecognized tag type: 0x{tagType.ToString("x")}");
            }
        }

        // Decode numeric value and return it as a normal integer.
        // After decoding, this function will advance the offset received in the parameter.
        private int DecodeNumeric(byte[] data, ref int offset)
        {
            int value = -1;

            // If numeric type is smaller than 0xf0, the numeric type itself is the value, so return it.
            if (data[offset] < 0xf0)
            {
                value = data[offset] - 1;
            }
            // Else, the first byte of the data is the numeric type so decode accordingly.
            else
            {
                byte numericType = data[offset];

                switch (numericType)
                {
                    // Byte type.
                    case 0xf0:
                        // The trailing byte is the actual value.
                        offset++;
                        value = data[offset];
                        break;

                    // Byte * 256 type.
                    case 0xf1:
                        // The trailing byte multiplied by 256 is the actual value.
                        offset++;
                        value = data[offset] * 256;
                        break;

                    // 2 bytes type.
                    case 0xf2:
                        // Following 2 bytes are the actual integer value.
                        offset++;
                        value = data[offset] << 8;
                        offset++;
                        value += data[offset];
                        break;

                    // 3 bytes type.
                    case 0xf3:
                        // Following 3 bytes are the actual integer value.
                        offset++;
                        value = data[offset] << 16;
                        offset++;
                        value += data[offset] << 8;
                        offset++;
                        value += data[offset];
                        break;

                    // 4 bytes type.
                    case 0xf4:
                        // Following 4 bytes are the actual integer value.
                        offset++;
                        value = data[offset] << 24;
                        offset++;
                        value += data[offset] << 16;
                        offset++;
                        value += data[offset] << 8;
                        offset++;
                        value += data[offset];
                        break;

                    default:
                        // Unrecognized type.
                        throw new Exception($"Unrecognized numeric type: 0x{numericType.ToString("x")}");
                }
            }

            // Increment the offset to the next value then return.
            offset++;
            return value;
        }
    }
}
