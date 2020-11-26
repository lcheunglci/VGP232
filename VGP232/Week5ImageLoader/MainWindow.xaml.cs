using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using TextureAtlasLib;

namespace Week5ImageLoader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Spritesheet MySpriteSheet { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MySpriteSheet = new Spritesheet();
            MySpriteSheet.InputPaths = new List<String>();
            DataContext = MySpriteSheet;
            lbImages.ItemsSource = MySpriteSheet.InputPaths;
        }

        private void MenuOpen(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                // Do stuff to load.
            }
        }

        private void AddPressed(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PNG Images| *.png";
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == true)
            {
                foreach (string imagePath in openFile.FileNames)
                {
                    MySpriteSheet.InputPaths.Add(imagePath);
                }
                lbImages.Items.Refresh();

                // Do stuff to load.
            }
        }

        private void RemovePressed(object sender, RoutedEventArgs e)
        {
            // If nothing is selected from the list box, then don't do anything.
            if (lbImages.SelectedIndex == -1)
            {
                return;
            }

            MySpriteSheet.InputPaths.RemoveAt(lbImages.SelectedIndex);
            lbImages.Items.Refresh();
        }

        private void GeneratePressed(object sender, RoutedEventArgs e)
        {
            MySpriteSheet.IncludeMetaData = false;
            MySpriteSheet.OutputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            MySpriteSheet.OutputFile = "spritesheet.png";
            MySpriteSheet.IncludeMetaData = false;

            
            MySpriteSheet.Generate(true);
        }
    }
}
