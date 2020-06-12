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
    /// Interaction logic for IconSelector.xaml
    /// </summary>
    public partial class IconSelector : Window
    {
        public Skill MySkill { get; set; }
        public IconSelector(Skill skill)
        {
            InitializeComponent();
            MySkill = skill;
        }

        private void backClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
