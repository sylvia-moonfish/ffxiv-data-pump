using System.Collections.Generic;
using System.IO;

namespace DataPump
{
    // represents a indexed cache for all available SqFiles.
    class SqCache
    {
        // directory that contains index and dat file for 0a0000.
        public string BaseDir;

        // cached SqFiles.
        public Dictionary<uint, Dictionary<uint, SqFile>> SqFiles = new Dictionary<uint, Dictionary<uint, SqFile>>();

        // initialize the indexed cache.
        public SqCache(string baseDir)
        {
            BaseDir = baseDir;

            string indexPath = Path.Combine(BaseDir, "0a0000.win32.index");
            string datPath = Path.Combine(BaseDir, "0a0000.win32.dat0");

            using (FileStream fs = File.OpenRead(indexPath))
            using (BinaryReader br = new BinaryReader(fs))
            {
                // index file's header offset is written on 0xc.
                br.BaseStream.Position = 0xc;
                int headerOffset = br.ReadInt32();

                // offsets for file information are listed on index file's header, after the first 8 bytes.
                br.BaseStream.Position = headerOffset + 0x8;
                int fileOffset = br.ReadInt32();

                // file count is right next to offset, throw away last 2 bytes.
                int fileCount = br.ReadInt32() / 0x10;

                // start reading file information offsets.
                br.BaseStream.Position = fileOffset;
                for (int i = 0; i < fileCount; i++)
                {
                    // create SqFile instance and store relative information.
                    SqFile sqFile = new SqFile(br.ReadUInt32(), br.ReadUInt32(), br.ReadInt32(), datPath);

                    // skip 4 bytes.
                    br.ReadInt32();

                    // create a new directory dictionary if it is not cached already.
                    if (!SqFiles.ContainsKey(sqFile.DirectoryKey))
                    {
                        SqFiles.Add(sqFile.DirectoryKey, new Dictionary<uint, SqFile>());
                    }

                    SqFiles[sqFile.DirectoryKey].Add(sqFile.Key, sqFile);

                    Program.Report(string.Format("Reading SqFile: {0} ({1} / {2})", sqFile.Key, i + 1, fileCount));
                }
            }
        }
    }
}
