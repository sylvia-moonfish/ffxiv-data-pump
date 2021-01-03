using System;
using System.IO;
using System.IO.Compression;

namespace DataPump
{
    class SqFile
    {
        // sqFile unique key.
        public uint Key;
        
        // unique key of the directory that this sqFile belongs to.
        public uint DirectoryKey;

        // Whole offset segment.
        public int WrappedOffset;

        // number of the dat file. (i.e. dat0, dat1,...)
        // last three bytes then throw away last byte.
        public byte DatFile
        {
            get
            {
                return (byte)((WrappedOffset & 0x7) >> 1);
            }
        }

        // offset of the actual data in the dat file.
        // throw away DatFile bits then shift by 3.
        public int Offset
        {
            get
            {
                return (int)(WrappedOffset & 0xfffffff8) << 3;
            }
        }

        // physical path to dat file.
        public string DatPath;

        // constructor.
        public SqFile(uint key, uint directoryKey, int wrappedOffset, string datPath)
        {
            Key = key;
            DirectoryKey = directoryKey;
            WrappedOffset = wrappedOffset;
            DatPath = datPath;
        }

        // read data blocks and uncompress and concatenate them to raw binary.
        public byte[] ReadData()
        {
            using (FileStream fs = File.OpenRead(DatPath))
            using (BinaryReader br = new BinaryReader(fs))
            {
                // start of the file is always the int32 length of the file header.
                br.BaseStream.Position = Offset;
                int endOfHeader = br.ReadInt32();

                // copy the file header.
                byte[] header = new byte[endOfHeader];
                br.BaseStream.Position = Offset;
                br.Read(header, 0, endOfHeader);

                // 4th byte denotes the type of data, which should be 2 for binary files.
                if (BitConverter.ToInt32(header, 0x4) != 2) return null;

                // supposed to be the total stream size.
                long length = BitConverter.ToInt32(header, 0x10) * 0x80;

                // number of data blocks that have to be read.
                short blockCount = BitConverter.ToInt16(header, 0x14);

                using (MemoryStream ms = new MemoryStream())
                {
                    for (int i = 0; i < blockCount; i++)
                    {
                        // read where the block is from the header.
                        // first 0x18 bytes are header information so skip that.
                        // block offsets are listed after every 8 bytes.
                        int blockOffset = BitConverter.ToInt32(header, 0x18 + i * 0x8);

                        // read the header of the block now. The length is always 0x10 (16) bytes.
                        // block offset start from after the file header.
                        byte[] blockHeader = new byte[0x10];
                        br.BaseStream.Position = Offset + endOfHeader + blockOffset;
                        br.Read(blockHeader, 0, 0x10);

                        // first int32 of the block header should always be 0x10.
                        int check = BitConverter.ToInt32(blockHeader, 0);
                        if (check != 0x10) return null;

                        // source size = size the block header thinks the block is taking up.
                        // raw size = size before compression if it is compressed.
                        int sourceSize = BitConverter.ToInt32(blockHeader, 0x8);
                        int rawSize = BitConverter.ToInt32(blockHeader, 0xc);

                        // compression threshold = 0x7d00.
                        bool isCompressed = sourceSize < 0x7d00;

                        // actual size = if it is compressed, take the source size. if it is not compressed, take the raw size.
                        int actualSize = isCompressed ? sourceSize : rawSize;

                        // block plus block header (0x10) is always padded to be divisible by 0x80.
                        int paddingLeftover = (actualSize + 0x10) % 0x80;

                        // if it is not compressed, no need to copy the paddings over.
                        // if it is compressed, we need to take the paddings so that uncompression makes sense.
                        if (isCompressed && paddingLeftover != 0)
                        {
                            actualSize += 0x80 - paddingLeftover;
                        }

                        // copy over the block (without the above block header) from file.
                        byte[] blockBuffer = new byte[actualSize];
                        br.Read(blockBuffer, 0, actualSize);

                        // uncompress it if needed.
                        if (isCompressed)
                        {
                            using (MemoryStream _ms = new MemoryStream(blockBuffer))
                            using (DeflateStream ds = new DeflateStream(_ms, CompressionMode.Decompress))
                            {
                                ds.CopyTo(ms);
                            }
                        }
                        else
                        {
                            // if not compressed, just write it to memory stream.
                            ms.Write(blockBuffer, 0, blockBuffer.Length);
                        }
                    }

                    // return all data concatenated in memory stream as byte array.
                    return ms.ToArray();
                }
            }
        }
    }
}
