using Microsoft.Win32;
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
using Week3Lib;

namespace Week4
{
    /// <summary>
    /// Interaction logic for MonsterDexWindow.xaml
    /// </summary>
    public partial class MonsterDexWindow : Window
    {
        public Monsters Mons { get; set; }
        List<string> items = new List<string>();
        public MonsterDexWindow()
        {
            InitializeComponent();
            Mons = new Monsters();
            lbMonsters.ItemsSource = Mons;
        }

        private void LoadClicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "json format| *.json|xml format|*.xml|All files|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                MonsterLoader loader = new MonsterLoader();
                if (System.IO.Path.GetExtension(openFileDialog.FileName) == ".json")
                {
                    Mons.Clear();
                    var temp = loader.LoadListJSON(openFileDialog.FileName);
                    foreach (var mon in temp)
                    {
                        Mons.Add(mon);
                    }
                    lbMonsters.Items.Refresh();

                    // No longer need do the below for updating the list when I change the Monsters class to inherit from ObservableCollection
                    // lbMonsters.ItemsSource = null;
                    // lbMonsters.ItemsSource = Mons;
                }
                else if (System.IO.Path.GetExtension(openFileDialog.FileName) == ".xml")
                {
                    Mons = loader.LoadListXML(openFileDialog.FileName);
                }
            }
        }

        private void SaveClicked(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "json format| *.json|xml format|*.xml|All files|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                MonsterLoader loader = new MonsterLoader();
                if (System.IO.Path.GetExtension(saveFileDialog.FileName) == ".json")
                {
                    loader.SaveListJSON(saveFileDialog.FileName, Mons);
                }
                else if (System.IO.Path.GetExtension(saveFileDialog.FileName) == ".xml")
                {
                    loader.SaveListXML(saveFileDialog.FileName, Mons);
                }
            }
        }

        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddClicked(object sender, RoutedEventArgs e)
        {
            MonsterEditorWindow window = new MonsterEditorWindow();
            if (window.ShowDialog() == true)
            {
                Mons.Add(window.SavedMonster);
            }
            lbMonsters.Items.Refresh();
            //window.Show();
        }

        private void EditClicked(object sender, RoutedEventArgs e)
        {
            MonsterEditorWindow window = new MonsterEditorWindow();
            window.SavedMonster = lbMonsters.SelectedItem as Monster;
            int selectedIndex = lbMonsters.SelectedIndex;
            window.Setup();
            if (window.ShowDialog() == true)
            {
                Mons[selectedIndex] = window.SavedMonster;
                lbMonsters.Items.Refresh();
                // No longer need do the below for updating the list when I change the Monsters class to inherit from ObservableCollection
                // lbMonsters.ItemsSource = null;
                // lbMonsters.ItemsSource = Mons;
            }
        }

        private void RemoveClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Error, not implemented", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
