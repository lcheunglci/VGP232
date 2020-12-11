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
        Math myMath;

        public MainWindow()
        {
            InitializeComponent();
            myMath = new Math { Left = 1, Right = 2 };
            DataContext = myMath;
        }

        private void Sum_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("The sum total is {0}", myMath.Left + myMath.Right));
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            txNumber.Text = string.Format("{0}", mucSum.Left * mucSum.Right);
        }
    }
}
