using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using TextureAtlasLib;

namespace Week5ImageLoader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Spritesheet sheet;
        //List<SpriteInfo> images = new List<SpriteInfo>();
        List<string> images = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            sheet = new Spritesheet();
            DataContext = sheet;
            ImageListBox.ItemsSource = images;
        }

        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddClicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == true)
            {
                for (int i = 0; i < openFile.FileNames.Length; i++)
                {
                    //images.Add(new SpriteInfo() { Name = openFile.FileNames[i] });
                    images.Add(openFile.FileNames[i]);
                    ImageListBox.Items.Refresh();
                }
            }
        }

        private void GenerateClicked(object sender, RoutedEventArgs e)
        {
            //List<string> imagePaths = new List<string>();
            //for (int i = 0; i < images.Count; i++)
            //{
            //    imagePaths.Add(images[i].Name);
            //}
            sheet.Columns = 6;
            sheet.OutputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sheet.OutputFile = "animals.png";
            sheet.IncludeMetaData = true;
            //sheet.InputPaths = imagePaths;
            sheet.InputPaths = images;
            sheet.Generate(true);

            if (MessageBoxResult.Yes == MessageBox.Show("Success", "Sprite sheet generated. Would you like to view it", MessageBoxButton.YesNo))
            {
                Process.Start("explorer.exe ", sheet.OutputDirectory);
            }
        }

        private void OutputClicked(object sender, RoutedEventArgs e)
        {
            sheet.OutputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Process.Start("explorer.exe", sheet.OutputDirectory);
        }
    }
}
