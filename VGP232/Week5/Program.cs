using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace Week5
{
    class Program
    {
        public static byte[] Compress(byte[] raw)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip =
                    new GZipStream(memory, CompressionMode.Compress, true))
                {
                    gzip.Write(raw, 0, raw.Length);
                }
                return memory.ToArray();
            }
        }

        public static byte[] Decompress(byte[] compressed, int originalSize)
        {
            byte[] raw = new byte[originalSize];
            using (MemoryStream memory = new MemoryStream(compressed))
            {
                using (GZipStream gzip =
                    new GZipStream(memory, CompressionMode.Decompress, true))
                {
                    gzip.Read(raw, 0, raw.Length);
                }
                return raw;
            }
        }


        static void GZipExample()
        {
            byte[] text = Encoding.ASCII.GetBytes(new string('X', 20000));
            File.WriteAllBytes("uncompressed.bin", text);

            byte[] compressedText = Compress(text);
            File.WriteAllBytes("compressed.bin", compressedText);

            byte[] decompressedText = Decompress(compressedText, 20000);
            File.WriteAllBytes("decompressed.bin", decompressedText);
        }

        static void ZipExample()
        {
            string myDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string directoryPath = Path.Combine(myDoc, "Images");
            string targetPath = Path.Combine(myDoc, "pictures.zip");

            DirectoryInfo directory = new DirectoryInfo(directoryPath);

            using (FileStream myZipFile = new FileStream(targetPath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(myZipFile, ZipArchiveMode.Update))
                {
                    foreach (FileInfo file in directory.GetFiles("*.png"))
                    {
                        ZipArchiveEntry entry = archive.CreateEntryFromFile(
                            file.FullName, file.Name, CompressionLevel.Fastest);
                        Console.WriteLine($"adding {file.FullName} to the {targetPath}");
                    }
                }
            }

        }

        static void Main(string[] args)
        {
            //GZipExample();
            ZipExample();

            Console.ReadKey();
        }
    }
}
