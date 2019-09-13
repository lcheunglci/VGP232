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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CanvasExample
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

        private void MoveToMouse(object sender, DragEventArgs e)
        {
            Canvas.SetLeft(myRect, e.GetPosition(this).X);
            Canvas.SetTop(myRect, e.GetPosition(this).Y);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Canvas.SetLeft(myRect, e.GetPosition(this).X);
            Canvas.SetTop(myRect, e.GetPosition(this).Y);
        }

        private void loadSprite(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Filter = "PNG Images|*.png";
            if (fileOpen.ShowDialog() == true)
            {
                myImage.Source = new BitmapImage(new Uri(fileOpen.FileName));
            }
        }

        bool stickToCursor = false;

        private void MyImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (stickToCursor)
            {
                Canvas.SetLeft(myImage, e.GetPosition(this).X - myImage.Width*0.5f);
                Canvas.SetTop(myImage, e.GetPosition(this).Y - myImage.Height * 0.5f);
            }

            //Canvas.GetBottom(myImage);

        }

        private void MyImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            stickToCursor = !stickToCursor;
        }
    }
}
