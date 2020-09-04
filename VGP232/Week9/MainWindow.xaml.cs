using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Week9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Project myProject;
        private bool isLoad;

        public MainWindow()
        {
            InitializeComponent();
            myProject = new Project() { Columns = 2, Rows =2 , Name = "template", TilesFolder = "C:/test" };
            DataContext = myProject;
            UpdateGrid();
            ReloadTiles();
        }

        private void UpdateGrid()
        {
            if (ugMap == null)
                return;

            ugMap.Children.Clear();

            int cellCount = ugMap.Rows * ugMap.Columns;
            for (int i = 0; i < cellCount; i++)
            {
                Border border = new Border();
                border.Background = Brushes.AliceBlue;
                border.BorderThickness = new Thickness(1);
                border.MouseLeftButtonDown += ApplyBrushToCell;
                ugMap.Children.Add(border);
            }

        }

        private void MapGridUpdated(object sender, TextChangedEventArgs e)
        {
            UpdateGrid();
        }

        private void ImportTiles(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(myProject.TilesFolder))
            {
                MessageBox.Show("Please set the tiles folder");
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG images| *.png";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                {
                    File.Copy(
                        openFileDialog.FileNames[i], // source
                        System.IO.Path.Combine( // target
                            myProject.TilesFolder,
                            System.IO.Path.GetFileName(openFileDialog.FileNames[i])),
                        true // overwrite
                        );
                }
                ReloadTiles();
            }
        }

        private void ReloadTiles()
        {
            //lbTileBrushes;

            List <Image> tileBrushes = new List<Image>();

            for (int i = 1; i < 4; i++)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(
                    "Tiles/platformPack_tile00" + i.ToString() + ".png",
                    UriKind.Relative);
                bitmap.EndInit();
                tileBrushes.Add(new Image() { Source = bitmap });
            }

            DirectoryInfo tilesDirectory = new DirectoryInfo(myProject.TilesFolder);
            FileInfo[] tiles = tilesDirectory.GetFiles("*.png");
            for (int i = 0; i < tiles.Length; i++)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(tiles[i].FullName);
                bitmap.EndInit();
                tileBrushes.Add(new Image() { Source = bitmap });
            }

            lbTileBrushes.ItemsSource = tileBrushes;
        }


        private void ApplyBrushToCell(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;

            if (lbTileBrushes.SelectedIndex == -1)
            {
                return;
            }

            if (border == null)
            {
                return;
            }
            Image selectedBrush = lbTileBrushes.SelectedItem as Image;
            border.Background = new ImageBrush(selectedBrush.Source);
            border.Tag = lbTileBrushes.SelectedIndex.ToString();
        }

        private void SaveProject(object sender, RoutedEventArgs e)
        {
            if (isLoad)
            {

            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XEngine map | *.txt";
                if (saveFileDialog.ShowDialog() == true)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        int totalCells = ugMap.Columns * ugMap.Rows;

                        writer.WriteLine("columns: " + ugMap.Columns);
                        writer.WriteLine("rows: " + ugMap.Rows);
                        writer.WriteLine();
                        for (int i = 0; i < totalCells; i++)
                        {
                            Border border = ugMap.Children[i] as Border;
                            if (border != null)
                            {
                                writer.Write(border.Tag);
                            }
                        }
                        writer.WriteLine();
                        /*
                         * columns 2
                         * rows: 2
                         * 
                         * 00
                         * 11
                         */
                    }
                }

            }
        }
    }
}
