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
using System.Windows.Forms;

namespace Week7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButtonPressed(object sender, RoutedEventArgs e)
        {
            SpriteGenerator.Generate();
        }

        private void BrowseButtonPressed(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                selectedFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ShowButtonPressed(object sender, RoutedEventArgs e)
        {
            string pathToSpriteSheet = System.IO.Path.Combine(selectedFolder.Text, "spritesheet.png");
            var image = (new ImageSourceConverter()).ConvertFromString(pathToSpriteSheet) as ImageSource;
            previewImage.Width = image.Width;
            previewImage.Height = image.Height;
            previewImage.Source = image;
        }

        private void FindButtonPressed(object sender, RoutedEventArgs e)
        {
            string pathToSpriteSheet = selectedFolder.Text;
            System.Diagnostics.Process.Start("explorer", pathToSpriteSheet);

        }
    }
}
