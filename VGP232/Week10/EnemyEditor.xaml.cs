using Microsoft.Win32;
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
using System.Windows.Shapes;
using Week10.Model;

namespace Week10
{
    /// <summary>
    /// Interaction logic for EnemyEditor.xaml
    /// </summary>
    public partial class EnemyEditor : Window
    {
        public Enemy MyEnemy { get; set; }
        public EnemyEditor()
        {
            InitializeComponent();
            MyEnemy = new Enemy();
            this.DataContext = MyEnemy;
        }

        private void browseImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            { 
                MyEnemy.Face = dialog.FileName;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(dialog.FileName);
                image.EndInit();
                FaceImage.Source = image;
            }
        }
    }
}
