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

        private static void ZipArchiveExample()
        {
            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string myStuffPath = Path.Combine(myDocuments, "mystuff");
            string myZipFile = Path.Combine(myDocuments, "mystuff.zip");

            DirectoryInfo dir = new DirectoryInfo(myStuffPath);
            using (FileStream file = new FileStream(myZipFile, FileMode.Create))
            {
                using (ZipArchive zip = new ZipArchive(file, ZipArchiveMode.Update))
                {
                    
                    foreach (FileInfo png in dir.GetFiles("*.png"))
                    {
                        ZipArchiveEntry entry = zip.CreateEntryFromFile(
                            png.FullName,
                            png.Name,
                            CompressionLevel.Optimal);
                    }
                }
            }

            //zip.ExtractToDirectory()
        }

        static void ZipFileExample()
        {
            string myDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderName = "mystuff";
            string targetFolder = Path.Combine(myDoc, folderName);
            string zipFile = Path.Combine(myDoc, "mystuff.zip");
            string destinationFolder = Path.Combine(myDoc, "extracted");

            // ZipFile.CreateFromDirectory(targetFolder, zipFile);
            ZipFile.ExtractToDirectory(zipFile, destinationFolder);
        }

        static void Main(string[] args)
        {
            ZipFileExample();
        }

        static void CompressAndDecompress()
        {
            byte[] text = Encoding.ASCII.GetBytes(new string('A', 200000));
            File.WriteAllBytes("raw.bin", text);

            byte[] compressedText = Compress(text);
            File.WriteAllBytes("compressed.bin", compressedText);

            byte[] uncompressedText = Decompress(compressedText, 200000);
            File.WriteAllBytes("uncompressed.bin", uncompressedText);
        }
    }
}
