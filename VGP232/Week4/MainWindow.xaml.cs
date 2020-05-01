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
        public int Count { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DoStuff()
        { 
        }

        private void clickButtonPressed(object sender, RoutedEventArgs e)
        {
            lblText.Text = "Hello world";
        }

        private void IncrementCount(object sender, RoutedEventArgs e)
        {
            Button myButton = sender as Button;
            
            if (myButton != null)
            {
                if (Count < 100)
                {
                    String buttonValue = myButton.Content.ToString();
                    Count += int.Parse(buttonValue);
                    lblText.Text = Count.ToString();
                }
                else
                {
                    MessageBox.Show("You WIN!");
                }

            }
        }

        private void DoStuff(object sender, RoutedEventArgs e)
        {

        }
    }
}
