using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Week9.Model;

namespace Week9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Weapon myWeapon = new Weapon() { Name = "Axe", Power = 10 };
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = myWeapon;

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh");
            //nameText.Text = Properties.Resources.greetings;
        }

        private void selectionClicked(object sender, MouseButtonEventArgs e)
        {
            DataObject data = new DataObject(DataFormats.Bitmap, ((Image)e.Source).Source);
            DragDrop.DoDragDrop(
                (DependencyObject)e.Source, data, DragDropEffects.Copy);
        }

        private void droppedImage(object sender, DragEventArgs e)
        {
            Image droppedOnTo = e.Source as Image;
            droppedOnTo.Source = (ImageSource)e.Data.GetData(DataFormats.Bitmap);
        }

        private void ShowCurrentWeaponState(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(myWeapon.ToString());
        }
    }

    public class MyColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                {
                    return "Blue";
                }
            }
            return "Black";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush)
            {
                SolidColorBrush color = value as SolidColorBrush;
                if ( color != null)
                {
                    return color.Color == Colors.Blue;
                }
            }
            return false;
        }
    }
}
