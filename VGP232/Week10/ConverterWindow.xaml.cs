using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Week10
{
    /// <summary>
    /// Interaction logic for ConverterWindow.xaml
    /// </summary>
    public partial class ConverterWindow : Window
    {
        public ConverterWindow()
        {
            InitializeComponent();
        }
    }

    public class MyColorConverter : IValueConverter
    {
        // From true/false to blue/black
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

        // From blue/black to true/false
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush)
            {
                SolidColorBrush color = value as SolidColorBrush;
                if (color != null)
                {
                    return color.Color == Colors.Blue;
                }
            }
            return false;
        }
    }

}
