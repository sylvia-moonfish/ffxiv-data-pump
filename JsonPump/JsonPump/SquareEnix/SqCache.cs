using System;
using System.Collections.Generic;
using System.IO;

namespace JsonPump.SquareEnix
{
    // Represents an indexed cache for all SqFiles inside given index file.
    public class SqCache
    {
        public string[] DatPaths;

        // Physical paths for index and data files.
        public string IndexPath;

        // Cached SqFiles.
        public Dictionary<uint, Dictionary<uint, SqFile>> SqFiles = new();

        // Initialize the indexed cache.
        // For dat paths, this constructor expects the order to be dat0, dat1, dat2, ...
        public SqCache(string baseDir, string indexFileName, params string[] datFileNames)
        {
            Console.WriteLine($"[SqCache] Caching {indexFileName}...");

            // Transform file names to file paths with given base directory.
            IndexPath = Path.Combine(baseDir, indexFileName);
            DatPaths = datFileNames;
            for (var i = 0; i < DatPaths.Length; i++) DatPaths[i] = Path.Combine(baseDir, DatPaths[i]);

            // Start reading index file...
            using (var fs = File.OpenRead(IndexPath))
            using (var br = new BinaryReader(fs))
            {
                // Index file's header offset is written on address 0xc.
                br.BaseStream.Position = 0xc;
                var headerOffset = br.ReadInt32();

                // Offsets for the file information are listed on index file's header, after the first 8 bytes.
                br.BaseStream.Position = headerOffset + 0x8;
                var fileOffset = br.ReadInt32();

                // File count is right next to offset.
                // Throw away 4 bits.
                var fileCount = br.ReadInt32() / 0x10;

                // Start reading file information offsets...
                br.BaseStream.Position = fileOffset;
                for (var i = 0; i < fileCount; i++)
                {
                    // Create SqFile instance and store offset information.
                    var sqFile = new SqFile(br.ReadUInt32(), br.ReadUInt32(), br.ReadInt32(), DatPaths);

                    // Skip 4 bytes.
                    br.ReadInt32();

                    // Create a new directory in the dictionary if it is not cached already.
                    if (!SqFiles.ContainsKey(sqFile.DirectoryKey))
                        SqFiles.Add(sqFile.DirectoryKey, new Dictionary<uint, SqFile>());

                    // Add SqFile instance to appropriate directory.
                    SqFiles[sqFile.DirectoryKey].Add(sqFile.Key, sqFile);

                    Utility.ReportProgress(((double) i + 1) / fileCount);
                }
            }
        }

        // Getter that takes care of hash computation for directory and file names.
        // Will return null if directory/file doesn't exist in the cache.
        public SqFile GetFile(string directoryName, string fileName)
        {
            // Pre-calculate hashes because it'll be used multiple times.
            var directoryNameHash = Hash.Compute(directoryName);
            var fileNameHash = Hash.Compute(fileName);

            // If directory doesn't exist, return null.
            if (!SqFiles.ContainsKey(directoryNameHash)) return null;
            var directory = SqFiles[directoryNameHash];

            // If file doesn't exist, return null.
            if (!directory.ContainsKey(fileNameHash)) return null;

            // If file is found, set the readable names for debugging purposes.
            directory[fileNameHash].DirectoryName = directoryName;
            directory[fileNameHash].FileName = fileName;

            // Finally return the found file.
            return directory[fileNameHash];
        }
    }
}