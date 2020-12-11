using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for MathUserControl.xaml
    /// </summary>
    public partial class MathUserControl : UserControl
    {
        Math myMath;

        public MathUserControl()
        {
            InitializeComponent();
            myMath = new Math { Left = 1, Right = 2 };
            DataContext = myMath;
        }

        public int Right { get { return myMath.Right; } }
        public int Left { get { return myMath.Left; } }

        private void Sum_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("The sum total is {0}", myMath.Left + myMath.Right));
        }
    }
}
