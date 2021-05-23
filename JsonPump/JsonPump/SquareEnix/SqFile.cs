using System;
using System.IO;
using System.IO.Compression;

namespace JsonPump.SquareEnix
{
    // Represents offset information for the commonly used Square Enix data file.
    // This "file" is not the same as one physical file! One dat file usually contains multiple Square Enix data files.
    // SqFile instance only contains offset information. Use "ReadData" to read the actual binary data.
    public class SqFile
    {
        // Physical path of the target dat file.
        public string DatPath;

        // SqFile directory name hash.
        public uint DirectoryKey;

        // SqFile directory name.
        public string DirectoryName;

        // SqFile file name.
        public string FileName;

        // SqFile file name hash.
        public uint Key;

        // Whole offset segment.
        public int WrappedOffset;

        public SqFile(uint key, uint directoryKey, int wrappedOffset, params string[] datPaths)
        {
            Key = key;
            DirectoryKey = directoryKey;
            WrappedOffset = wrappedOffset;

            // Figure out which physical dat file contains this SqFile.
            DatPath = datPaths[DatFile];
        }

        // Number of the dat file. (i.e. dat0, dat1, ...)
        // Take last three bytes then throw away last bit.
        public byte DatFile => (byte) ((WrappedOffset & 0x7) >> 1);

        // Offset of the actual data in the physical dat file.
        // Throw away DatFile bits then shift it by 3.
        public int Offset => (int) (WrappedOffset & 0xfffffff8) << 3;

        // Read data blocks, uncompress and concatenate them to raw byte array.
        public byte[] ReadData()
        {
            using (var fs = File.OpenRead(DatPath))
            using (var br = new BinaryReader(fs))
            {
                // Right at the offset of this file is the int32 that denotes the length of this file's header.
                br.BaseStream.Position = Offset;
                var endOfHeader = br.ReadInt32();

                // Copy the file header.
                var header = new byte[endOfHeader];
                br.BaseStream.Position = Offset;
                br.Read(header, 0, endOfHeader);

                // 4th byte denotes the type of data, which should be 2 for binary files.
                if (BitConverter.ToInt32(header, 0x4) != 2) return null;

                // Supposed to be the total stream size.
                long length = BitConverter.ToInt32(header, 0x10) * 0x80;

                // Number of data blocks that have to be read.
                var blockCount = BitConverter.ToInt16(header, 0x14);

                // Memory stream for concatenating incoming uncompressed data.
                using (var ms = new MemoryStream())
                {
                    // We'll go block by block.
                    for (var i = 0; i < blockCount; i++)
                    {
                        // Skip the first 0x18 bytes of the header because they are just header information.
                        // After 0x18 bytes, the block offset are listed every 8 bytes.
                        var blockOffset = BitConverter.ToInt32(header, 0x18 + i * 0x8);

                        // Read the header of the block now. The length is always 0x10 bytes.
                        // Block offset start from after the file header.
                        var blockHeader = new byte[0x10];
                        br.BaseStream.Position = Offset + endOfHeader + blockOffset;
                        br.Read(blockHeader, 0, 0x10);

                        // First int32 of the block header should always be 0x10.
                        var check = BitConverter.ToInt32(blockHeader, 0);
                        if (check != 0x10) return null;

                        // Source size = size the block header thinks the block is taking up.
                        // Raw size = size before compression if it is compressed.
                        var sourceSize = BitConverter.ToInt32(blockHeader, 0x8);
                        var rawSize = BitConverter.ToInt32(blockHeader, 0xc);

                        // Compression threshold = 0x7d00.
                        var isCompressed = sourceSize < 0x7d00;

                        // Actual size = if it is compressed, take the source size. If it is not compressed, take the raw size.
                        var actualSize = isCompressed ? sourceSize : rawSize;

                        // Block plus block header (0x10) is always padded to be divisible by 0x80.
                        var paddingLeftover = (actualSize + 0x10) % 0x80;

                        // If it is not compressed, no need to copy the paddings over.
                        // If it is compressed, we need to take the paddings too so we can uncompress.
                        if (isCompressed && paddingLeftover != 0) actualSize += 0x80 - paddingLeftover;

                        // Copy over the block (without the above block header) from the binary.
                        var blockBuffer = new byte[actualSize];
                        br.Read(blockBuffer, 0, actualSize);

                        // Uncompress if needed.
                        if (isCompressed)
                            using (var _ms = new MemoryStream(blockBuffer))
                            using (var ds = new DeflateStream(_ms, CompressionMode.Decompress))
                            {
                                // Write the uncompressed data to the memory stream.
                                ds.CopyTo(ms);
                            }
                        else
                            // If not compressed, just write it to memory stream.
                            ms.Write(blockBuffer, 0, blockBuffer.Length);
                    }

                    // Return all data concatenated in memory stream as byte array.
                    return ms.ToArray();
                }
            }
        }
    }
}