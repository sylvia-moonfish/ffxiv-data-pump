using System;
using System.Collections.Generic;
using System.Text;

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

        // decode ExD string type column to plain string.
        private string DecodeString(byte[] field)
        {
            List<byte> byteList = new List<byte>();

            for (int i = 0; i < field.Length; i++)
            {
                if (field[i] != 0x2)
                {
                    byteList.Add(field[i]);
                }
                else
                {
                    byteList.AddRange(DecodeTag(field, ref i));
                }
            }

            return new UTF8Encoding(false).GetString(byteList.ToArray());
        }

        // decode tag to a readable string and return the byte array representation.
        private byte[] DecodeTag(byte[] data, ref int offset)
        {
            // reject if not proper tag.
            if (data[offset] != 0x2) return new byte[0];

            // after opening of tag (0x2), the next byte is the tag type.
            offset++;
            byte tagType = data[offset];

            // after tag type, the next bytes are the numeric value for the length of the tag.
            offset++;
            int length = DecodeNumeric(data, offset, ref offset);

            // copy over the tag and increment the offset accordingly.
            byte[] tag = new byte[length];
            Array.Copy(data, offset, tag, 0, length);
            offset += length;


            // check closing of tag.
            if (data[offset] != 0x3) throw new Exception("Tag doesn't end with 0x3!");

            return DecodeTagByType(tagType, tag);
        }

        
        private byte[] DecodeTagByType(byte tagType, byte[] tag)
        {
            // some common variable names.
            int offset = 0;
            int opening;

            switch (tagType)
            {
                // new line.
                case 0x10:
                    // this tag always contains only new line character, so it's safe to return new line and ignore the data.
                    return new UTF8Encoding(false).GetBytes("<br />");

                // emphasis.
                case 0x1a:
                    if (tag.Length != 1) throw new Exception("Error while decoding emphasis (0x1a) tag: tag length is not 1.");

                    // the starting bytes of the tag are the numeric value that denotes opening/closing of the tag.
                    opening = DecodeNumeric(tag, offset, ref offset);

                    if (opening == 1)
                    {
                        return new UTF8Encoding(false).GetBytes("<em>");
                    }
                    else if (opening == 0)
                    {
                        return new UTF8Encoding(false).GetBytes("</em>");
                    }
                    
                    throw new Exception("Error while decoding emphasis (0x1a) tag: tag opening is not known.");

                // dash.
                case 0x1f:
                    // this tag always contains only dash character, so it's safe to return dash and ignore the data.
                    return new UTF8Encoding(false).GetBytes("-");

                // ui tag.
                case 0x48:
                    // the starting bytes of the tag are the numeric value that denotes type of the tag.
                    opening = DecodeNumeric(tag, offset, ref offset);

                    if (opening == 0)
                    {
                        return new UTF8Encoding(false).GetBytes("</ui>");
                    }
                    else
                    {
                        return new UTF8Encoding(false).GetBytes(string.Format("<ui value=\"0x{0}\">", opening.ToString("x")));
                    }

                // ui color decoration tag.
                case 0x49:
                    // the starting bytes of the tag are the numeric value that denotes type of the tag.
                    opening = DecodeNumeric(tag, offset, ref offset);

                    if (opening == 0)
                    {
                        return new UTF8Encoding(false).GetBytes("</uiColor>");
                    }
                    else
                    {
                        return new UTF8Encoding(false).GetBytes(string.Format("<uiColor value=\"0x{0}\">", opening.ToString("x")));
                    }

                default:
                    throw new Exception(string.Format("Unrecognized tag type: 0x{0}", tag[1].ToString("x")));
            }
        }

        // decode numeric from tag data and return it as a normal integer. (the numeric type should be at the given offset.)
        private int DecodeNumeric(byte[] data, int offset, ref int endingOffset)
        {
            // ending offset starts from the offset + 1 since the first byte is always numeric type and will be always read.
            // ending offset will move according to the actual amount of bytes that contains the numeric data.
            endingOffset = offset + 1;

            // if numeric is smaller than f0, the type itself is a numeric value, so return it.
            if (data[offset] < 0xf0)
            {
                return data[offset] - 1;
            }

            // [offset] -> numeric type.
            switch (data[offset])
            {
                // byte type.
                case 0xf0:
                    // the trailing byte is the actal value.
                    endingOffset++;
                    return data[offset + 1];

                // byte * 256 type.
                case 0xf1:
                    // the trailing byte times 256 is the actual value.
                    endingOffset++;
                    return data[offset + 1] * 256;

                // 2 bytes (int16) type.
                case 0xf2:
                    // next 2 bytes contain the actual value.
                    endingOffset += 2;
                    return (data[offset + 1] << 8) + data[offset + 2];

                // 3 bytes (int24) type.
                case 0xf3:
                    endingOffset += 3;
                    return (data[offset + 1] << 16) + (data[offset + 2] << 8) + data[offset + 3];

                // 4 bytes (int32) type.
                case 0xf4:
                    endingOffset += 4;
                    return (data[offset + 1] << 24) + (data[offset + 2] << 16) + (data[offset + 3] << 8) + data[offset + 4];

                default:
                    throw new Exception(string.Format("Unrecognized numeric type: 0x{0}", data[offset].ToString("x")));
            }
        }

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
            Array.Copy(data, 0x20 + offsetEntriesSize, rawRows, 0, totalRowSize);

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
                // first section is the fixed size data.
                byte[] fixedSizeData = new byte[headerFile.FixedSizeDataLength];
                Array.Copy(rawRows, rawRowPosition + 0x6, fixedSizeData, 0, headerFile.FixedSizeDataLength);

                // second section is the additional data that are used for some complex column values (like string type).
                byte[] additionalData = new byte[row.Size - headerFile.FixedSizeDataLength];
                Array.Copy(rawRows, rawRowPosition + 0x6 + headerFile.FixedSizeDataLength, additionalData, 0, additionalData.Length);

                // go through each column.
                foreach (ExHColumn column in headerFile.Columns)
                {
                    ExDData parsedData = new ExDData();

                    switch (column.Type)
                    {
                        // string type.
                        case 0x0:
                            // the first 4 bytes of the fixed size data contain start offset for additional data section.
                            int valueStart = toInt32(fixedSizeData, column.Offset, true);

                            // the additional data is 0-terminated.
                            int valueEnd = valueStart;
                            while (valueEnd < additionalData.Length && additionalData[valueEnd] != 0) valueEnd++;

                            // copy the value to new byte array.
                            byte[] field = new byte[valueEnd - valueStart];
                            Array.Copy(additionalData, valueStart, field, 0, field.Length);

                            // encode with utf8 for now...
                            parsedData.Type = typeof(string);
                            parsedData.Value = DecodeString(field);
                            break;

                        // boolean type.
                        case 0x1:
                            // the first byte of the fixed size data is the boolean value.
                            parsedData.Type = typeof(bool);
                            parsedData.Value = fixedSizeData[column.Offset] != 0;
                            break;

                        // signed byte type.
                        case 0x2:
                            // the first byte of the fixed size data is the value.
                            parsedData.Type = typeof(sbyte);
                            parsedData.Value = (sbyte)fixedSizeData[column.Offset];
                            break;

                        // byte type.
                        case 0x3:
                            // the first byte of the fixed size data is the value.
                            parsedData.Type = typeof(byte);
                            parsedData.Value = fixedSizeData[column.Offset];
                            break;

                        // short type.
                        case 0x4:
                            // the first 2 bytes of the fixed size data are the value.
                            parsedData.Type = typeof(short);
                            parsedData.Value = toInt16(fixedSizeData, column.Offset, true);
                            break;

                        // ushort type.
                        case 0x5:
                            // the first 2 bytes of the fixed size data are the value.
                            parsedData.Type = typeof(ushort);
                            parsedData.Value = toUInt16(fixedSizeData, column.Offset, true);
                            break;

                        // int type.
                        case 0x6:
                            // the first 4 bytes of the fixed size data are the value.
                            parsedData.Type = typeof(int);
                            parsedData.Value = toInt32(fixedSizeData, column.Offset, true);
                            break;

                        // uint type.
                        case 0x7:
                            // the first 4 bytes of the fixed size data are the value.
                            parsedData.Type = typeof(uint);
                            parsedData.Value = toUInt32(fixedSizeData, column.Offset, true);
                            break;

                        // float type.
                        case 0x9:
                            // the first 4 bytes of the fixed size data are the value.
                            parsedData.Type = typeof(float);
                            parsedData.Value = toFloat(fixedSizeData, column.Offset, true);
                            break;

                        // long type.
                        case 0xb:
                            // the first 8 bytes of the fixed size data are the value.
                            parsedData.Type = typeof(long);
                            parsedData.Value = toInt64(fixedSizeData, column.Offset, true);
                            break;

                        // masked boolean types.
                        // the first byte of the fixed size data contains the boolean value, where the bit offset is type value - 0x19 from right.
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

                        // unrecognized type.
                        // throw exception.
                        default:
                            throw new Exception(string.Format("Unrecognized column type: 0x{0}", column.Type.ToString("x")));

                    }

                    row.Data.Add(column, parsedData);
                }

                Rows.Add(row);
            }
        }
    }
}
