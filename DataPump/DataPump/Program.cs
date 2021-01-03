using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace DataPump
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create cache for all SqFiles available.
            SqCache sqCache = new SqCache(@"C:\Program Files (x86)\SquareEnix\FINAL FANTASY XIV - A Realm Reborn\game\sqpack\ffxiv");

            // Print root.exl contents for debugging purposes.
            PrintRoot(sqCache);

            // Find exd/Item header file and read/decode it.
            ExHFile item = new ExHFile(sqCache.SqFiles[Hash.Compute("exd")][Hash.Compute("Item")]);

            ExDFile testFile = new ExDFile(sqCache.SqFiles[Hash.Compute("exd")][Hash.Compute(string.Format("Item_{0}_{1}.exd", item.Ranges[0].Start, "en"))], item);

            Console.ReadLine();
        }

        private static string prevLine;
        public static void Report(string line)
        {
            if (!string.IsNullOrEmpty(prevLine))
            {
                string cleanLine = string.Empty;
                while (cleanLine.Length != prevLine.Length) cleanLine += " ";
                Console.Write("\r");
                Console.Write(cleanLine);
            }

            Console.Write("\r");
            Console.Write(line);
            prevLine = line;
        }

        private static void PrintRoot(SqCache sqCache)
        {
            SqFile root = sqCache.SqFiles[Hash.Compute("exd")][Hash.Compute("root.exl")];

            using (MemoryStream ms = new MemoryStream(root.ReadData()))
            using (StreamReader sr = new StreamReader(ms, Encoding.ASCII))
            using (StreamWriter sw = new StreamWriter(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "root.exl"), false))
            {
                while (sr.Peek() != -1)
                {
                    sw.WriteLine(sr.ReadLine());
                }
            }
        }
    }
}
