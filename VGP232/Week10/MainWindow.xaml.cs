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

namespace Week10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageSource mSelectedBrush;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuNewClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New clicked");
        }

        private void menuExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void updateBrush(object sender, SelectionChangedEventArgs e)
        {
            ListBox box = sender as ListBox;
            if (box != null)
            {
                Image selectedImage = box.SelectedItem as Image;
                if (selectedImage != null)
                {
                    mSelectedBrush = selectedImage.Source;
                }
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            border.Background = new ImageBrush(mSelectedBrush);

            // mapGrid.Children.IndexOf(border);
        }
    }
}
