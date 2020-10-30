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
using Microsoft.Win32;
using Week03Lib;

namespace Week4
{
    /// <summary>
    /// Interaction logic for MyWindow.xaml
    /// </summary>
    public partial class MyWindow : Window
    {
        public SkillCollection MySkillCollection { get; set; }
        public MyWindow()
        {
            InitializeComponent();
            MySkillCollection = new SkillCollection();
        }

        private void LoadPressed(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "XML files |*.xml| Json files| *.json";
            if (openFile.ShowDialog() == true)
            {
                if (!MySkillCollection.Load(openFile.FileName))
                {
                    MessageBox.Show("Unable to load the file.");
                }
                else
                {
                    lbSkills.ItemsSource = MySkillCollection;
                    lbSkills.Items.Refresh();
                }
            }
        }

        private void SavePressed(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "XML files |*.xml| Json files| *.json";
            if (saveFile.ShowDialog() == true)
            {
                if (!MySkillCollection.Save(saveFile.FileName))
                {
                    MessageBox.Show("Unable to save file.");
                }
            }
        }

        private void AddPressed(object sender, RoutedEventArgs e)
        {
            EditSkillWindow editSkillWindow = new EditSkillWindow();
            if (editSkillWindow.ShowDialog() == true)
            {
                MySkillCollection.Add(editSkillWindow.MySkill);
                lbSkills.Items.Refresh();
            }
        }

        private void EditPressed(object sender, RoutedEventArgs e)
        {
            // If nothing is selected from the list box, then don't do anything.
            if (lbSkills.SelectedIndex == -1)
            {
                return;
            }

            EditSkillWindow editSkillWindow = new EditSkillWindow();

            editSkillWindow.MySkill = lbSkills.SelectedItem as Skill;

            if (editSkillWindow.ShowDialog() == true)
            {
                MySkillCollection[lbSkills.SelectedIndex] = editSkillWindow.MySkill;
                lbSkills.Items.Refresh();
            }

        }

        private void RemovePressed(object sender, RoutedEventArgs e)
        {
            // If nothing is selected from the list box, then don't do anything.
            if (lbSkills.SelectedIndex == -1)
            {
                return;
            }

            MySkillCollection.RemoveAt(lbSkills.SelectedIndex);
            // MySkillCollection.Remove((Skill)lbSkills.SelectedItem);
            lbSkills.Items.Refresh();

        }
    }
}
