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

namespace Week4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FirstName { get; set; }
        private int count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonPressed(object sender, RoutedEventArgs e)
        {
            txtWelcome.Text = "Hello Class";
        }

        private void Button2Pressed(object sender, RoutedEventArgs e)
        {
            txtWelcome.Text = "Hello Class, how are you?";
        }


        private void ButtonAnotherPressed()
        {
            txtWelcome.Text = "Another button was pressed.";
        }

        private void SayHelloPressed(object sender, RoutedEventArgs e)
        {
            string name = tbInputName.Text;
            MessageBox.Show("Hello, " + name);
        }

        private void IncrementCountPressed(object sender, RoutedEventArgs e)
        {
            if (count >= 10)
            {
                MessageBox.Show("You win!");
            }
            else
            {
                count++;
            }
            txtCount.Text = string.Format("Count: {0}", count);
        }
    }
}
