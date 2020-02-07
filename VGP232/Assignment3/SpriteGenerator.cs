using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Assignment3
{
    public class SpriteGenerator
    {
        public static void Generate()
        {
            // Modify these three/four variables and use WPF Controls to trigger this function 

            // TODO: parameterize it
            string myFolder = "mystuff";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), myFolder);
            string output = "spritesheet.png";
            int columns = 6;

            if (!path.EndsWith(@"\"))
            {
                path = path + @"\";
            }
            string outputPath = path + output;

            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            // Everything below here should be automatic
            Console.WriteLine("Analyzing input files:\n{0}", path);
            string[] files = Directory.GetFiles(path, "*.png");
            int fileCount = files.Length;
            if (fileCount > 0)
            {
                Console.WriteLine("{0} files found, analyzing dimensions.", files.Length);

                int maxWidth = 0;
                int maxHeight = 0;
                foreach (string f in files)
                {
                    Console.Write(".");
                    Image img = Image.FromFile(f);
                    maxWidth = Math.Max(maxWidth, img.Width);
                    maxHeight = Math.Max(maxHeight, img.Height);
                    img.Dispose();
                }
                Console.WriteLine("\nLargest input image is {0} x {1}.", maxWidth, maxHeight);

                if (fileCount < columns)
                {
                    Console.WriteLine("Single row, reducing column count to match file count.");
                    columns = fileCount;
                }

                int width = columns * maxWidth;
                int rows = (fileCount / columns) + ((fileCount % columns > 0) ? 1 : 0);
                int height = rows * maxHeight;

                Console.WriteLine("Output: {0} rows, {1} cols, {2} x {3} resolution.", rows, columns, width, height);

                Bitmap sheet = new Bitmap(width, height);
                using (Graphics gfx = Graphics.FromImage(sheet))
                {
                    int col = 0;
                    int row = 0;
                    foreach (string f in files)
                    {
                        Image img = Image.FromFile(f);
                        Console.Write(".");

                        // center it
                        int x = (col * maxWidth) + (maxWidth / 2 - img.Width / 2);
                        int y = (row * maxHeight) + (maxHeight / 2 - img.Height / 2);

                        Rectangle srcRect = new Rectangle(0, 0, img.Width, img.Height);
                        Rectangle destRect = new Rectangle(x, y, img.Width, img.Height);

                        gfx.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);

                        img.Dispose();

                        col++;
                        if (col == columns)
                        {
                            col = 0;
                            row++;
                        }
                    }
                }

                Console.WriteLine("\nSaving:\n{0}", outputPath);
                sheet.Save(outputPath);
            }
            else
            {
                Console.WriteLine("No PNG files found.");
            }

            Console.WriteLine("\nPRESS ANY KEY TO EXIT...");
        }


    }

}
