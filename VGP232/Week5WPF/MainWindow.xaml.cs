using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextureAtlasLib;

namespace Week5WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Spritesheet TextureAtlas { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            TextureAtlas = new Spritesheet();
        }

        private void Generate_Button(object sender, RoutedEventArgs e)
        {
            TextureAtlas.Columns = 4;
            TextureAtlas.InputPath = lblLocation.Text;
            TextureAtlas.OutputPath = txtName.Text;

            TextureAtlas.Generate(true);

            imgPreview.Source = (new ImageSourceConverter()).ConvertFromString(txtName.Text) as ImageSource;
        }

        private void Browse_Button(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblLocation.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void Show_Button(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", lblLocation.Text);
        }
    }
}
