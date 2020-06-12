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
    /// Interaction logic for SkillEditor.xaml
    /// </summary>
    public partial class SkillEditor : Window
    {
        public Skill MySkill { get; set; }
        public SkillEditor()
        {
            InitializeComponent();
            if (MySkill == null)
            {
                MySkill = new Skill();
            }
            this.DataContext = MySkill;
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            IconSelector iconSelector = new IconSelector(MySkill);
            if (iconSelector.ShowDialog() == true)
            {
                DialogResult = true;
                this.Close();
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
