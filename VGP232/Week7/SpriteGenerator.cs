using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;

namespace Week7
{
    public class SpriteGenerator
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

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
                List<SpriteInfo> spriteInfos = new List<SpriteInfo>();
                using (Graphics gfx = Graphics.FromImage(sheet))
                {
                    int col = 0;
                    int row = 0;



                    System.Windows.Media.Imaging.GifBitmapEncoder encoder = new System.Windows.Media.Imaging.GifBitmapEncoder();

                    foreach (string f in files)
                    {
                        // Sprite Info intialization
                        SpriteInfo sprite = new SpriteInfo();
                        sprite.Name = System.IO.Path.GetFileNameWithoutExtension(f);

                        Image img = Image.FromFile(f);
                        Bitmap bimg = (Bitmap)img;

                        var bmp = bimg.GetHbitmap();
                        var src = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                            bmp, IntPtr.Zero,
                            System.Windows.Int32Rect.Empty,
                            System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                        encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(src));

                        DeleteObject(bmp);

                        Console.Write(".");

                        // center it
                        int x = (col * maxWidth) + (maxWidth / 2 - img.Width / 2);
                        int y = (row * maxHeight) + (maxHeight / 2 - img.Height / 2);

                        Rectangle srcRect = new Rectangle(0, 0, img.Width, img.Height);
                        Rectangle destRect = new Rectangle(x, y, img.Width, img.Height);

                        // Populate the coordinates for the sprite.
                        sprite.Left = x;
                        sprite.Top = y;
                        sprite.Right = x + img.Width;
                        sprite.Bottom = y + img.Height;

                        spriteInfos.Add(sprite);

                        gfx.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);

                        img.Dispose();

                        col++;
                        if (col == columns)
                        {
                            col = 0;
                            row++;
                        }
                    }
                    using (var fs = new FileStream(path + "anim.gif", FileMode.Create))
                    {
                        encoder.Save(fs);
                    }


                }

                string exportedMetaData = System.IO.Path.GetFileNameWithoutExtension(output) + ".json";
                string exportedPath = System.IO.Path.Combine(path, exportedMetaData);
                string json = JsonConvert.SerializeObject(spriteInfos);
                System.IO.File.WriteAllText(exportedPath, json);

                

                Console.WriteLine("\nSaving:\n{0}", outputPath);
                sheet.Save(outputPath);
            }
            else
            {
                Console.WriteLine("No PNG files found.");
            }

            Console.WriteLine("\nPRESS ANY KEY TO EXIT...");
        }

        public static System.Drawing.Image[] GetFrames(string path)
        {
            byte[] rawData = File.ReadAllBytes(path);
            var originalImg = System.Drawing.Image.FromStream(new MemoryStream(rawData));

            int frameCount = originalImg.GetFrameCount(System.Drawing.Imaging.FrameDimension.Time);
            System.Drawing.Image[] frames = new System.Drawing.Image[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                originalImg.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Time, i);
                frames[i] = (System.Drawing.Image)originalImg.Clone();
            }

            return frames;

        }


        public static void ConvertToGif(System.Drawing.Bitmap[] images, string path)
        {
            System.Windows.Media.Imaging.GifBitmapEncoder encoder = new System.Windows.Media.Imaging.GifBitmapEncoder();

            foreach (var img in images)
            {
                var bmp = img.GetHbitmap();
                var src = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    bmp, IntPtr.Zero,
                    System.Windows.Int32Rect.Empty,
                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(src));

                DeleteObject(bmp);
            }

            using (var fs = new FileStream(path, FileMode.Create))
            {
                encoder.Save(fs);
            }

        }


    }

}
