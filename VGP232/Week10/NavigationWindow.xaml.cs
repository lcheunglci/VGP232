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

namespace Week10
{
    /// <summary>
    /// Interaction logic for NavigationWindow.xaml
    /// </summary>
    public partial class NavigationWindow : Window
    {
        public NavigationWindow()
        {
            InitializeComponent();
        }

        private void GoToPage1(object sender, RoutedEventArgs e)
        {
            frame.Source = new Uri("Page1a.xaml", UriKind.Relative);
        }

        private void GoToPage2(object sender, RoutedEventArgs e)
        {
            frame.Source = new Uri("Page2.xaml", UriKind.Relative);
        }
    }
}
