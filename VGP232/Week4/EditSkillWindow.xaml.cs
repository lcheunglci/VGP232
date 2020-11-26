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
using System.Windows.Shapes;
using Week03Lib;

namespace Week4
{
    /// <summary>
    /// Interaction logic for EditSkillWindow.xaml
    /// </summary>
    public partial class EditSkillWindow : Window
    {
        private Skill mySkill;

        public Skill MySkill
        {
            get { return mySkill; }
            set 
            {
                mySkill = value;
                DataContext = MySkill;
            }
        }

        public EditSkillWindow()
        {
            InitializeComponent();

            string[] elements = Enum.GetNames(typeof(ElementType));
            cbElements.ItemsSource = elements;

            MySkill = new Skill();
            //MySkill.Name = "Fireball";
            //MySkill.Cost = 5;
            //MySkill.Modifier = -20;

        }

        private void CancelPressed(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void SavePressed(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
