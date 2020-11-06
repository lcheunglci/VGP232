using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Week5
{
    class Program
    {
        public static byte[] Compress(byte[] raw)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(memory, CompressionMode.Compress, true))
                {
                    gzip.Write(raw, 0, raw.Length);
                }
                return memory.ToArray();
            }
        }

        public static byte[] Decompress(byte[] compressed, int originalSize)
        {
            byte[] uncompressed = new byte[originalSize];

            using (MemoryStream memory = new MemoryStream(compressed))
            {
                using (GZipStream gzip = new GZipStream(memory, CompressionMode.Decompress, true))
                {
                    gzip.Read(uncompressed, 0, originalSize);
                }
                return uncompressed;
            }
        }


        public static void ZipArchiveExample()
        {
            string myDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string myStuffPath = Path.Combine(myDoc, "mystuff");
            string myStuffZip = Path.Combine(myDoc, "mystuffbundle.zip");

            DirectoryInfo dir = new DirectoryInfo(myStuffPath);
            FileInfo[] allImageFiles = dir.GetFiles("*.png");

            using (FileStream file = new FileStream(myStuffZip, FileMode.Create))
            {
                using (ZipArchive zip = new ZipArchive(file, ZipArchiveMode.Update))
                {
                    foreach (var png in allImageFiles)
                    {
                        ZipArchiveEntry entry = zip.CreateEntryFromFile(
                            png.FullName,
                            png.Name,
                            CompressionLevel.Optimal);
                    }
                }
            }


        }


        static void ZipFileExample()
        {
            string myDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string extractedMyStuffPath = Path.Combine(myDoc, "mystuffextracted");
            string myStuffZip = Path.Combine(myDoc, "mystuffbundle.zip");

            // ZipFile.CreateFromDirectory(extractedMyStuffPath, myStuffZip);
            ZipFile.ExtractToDirectory(myStuffZip, extractedMyStuffPath);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello Week5!");

            ZipFileExample();

            // ZipArchiveExample();

            // GZipExample();

        }

        private static void GZipExample()
        {
            byte[] text = Encoding.ASCII.GetBytes(new string('A', 200000));
            File.WriteAllBytes("raw.bin", text);

            byte[] compressed = Compress(text);
            File.WriteAllBytes("compressed.bin", compressed);

            byte[] expand = Decompress(compressed, 200000);
            File.WriteAllBytes("uncompressed.bin", expand);
        }
    }
}
