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
    /// Interaction logic for WeaponLibraryWindow.xaml
    /// </summary>
    public partial class WeaponLibraryWindow : Window
    {
        public WeaponLibrary Weapons { get; set; }

        public WeaponLibraryWindow()
        {
            InitializeComponent();
            Weapons = new WeaponLibrary();
            lbWeapons.ItemsSource = Weapons;
        }

        private void AddPressed(object sender, RoutedEventArgs e)
        {
            EditorWindow editor = new EditorWindow();

            if (editor.ShowDialog() == true)
            {
                Weapons.Add(editor.MyWeapon);
                lbWeapons.Items.Refresh();
            }
        }
        private void EditPressed(object sender, RoutedEventArgs e)
        {
            if (lbWeapons.SelectedIndex == -1)
            {
                return;
            }

            EditorWindow editor = new EditorWindow();
            editor.MyWeapon = Weapons[lbWeapons.SelectedIndex];
            editor.Setup();
            if (editor.ShowDialog() == true)
            {
                Weapons[lbWeapons.SelectedIndex] = editor.MyWeapon;
                lbWeapons.Items.Refresh();
            }
        }


        private void RemovePressed(object sender, RoutedEventArgs e)
        {
            if (lbWeapons.SelectedIndex == -1)
            {
                return;
            }

            Weapons.RemoveAt(lbWeapons.SelectedIndex);
            lbWeapons.Items.Refresh();
        }



        private void SavePressed(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML | *.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                Weapons.SaveXML(saveFileDialog.FileName);
            }
        }

        private void LoadPressed(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML|*.xml|Comma Seperated Values|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                Weapons.LoadXML(openFileDialog.FileName);
                lbWeapons.Items.Refresh();
            }
        }
    }
}
