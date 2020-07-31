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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Week3Lib;

namespace Week4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WeaponLoader weaponLoader;

        private int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            weaponLoader = new WeaponLoader();
            WeaponsListBox.ItemsSource = weaponLoader;

            List<string> elements = new List<string> { "All" };
            elements.AddRange(Enum.GetNames(typeof(Element)));
            ShowOnlyElementComboBox.ItemsSource = elements;

            //Grid grid = new Grid();

            //Button btn = new Button();
            //btn.Content = "Press me";

            //grid.Children.Add(btn);

            //this.Content = grid;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (count >= 10)
            {
                MessageBox.Show("You win!");
            }
            
            // Console.WriteLine("Hello");
            count += 1;
            MyTextBlock.Text = count.ToString();


        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Something happened");
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Something else happened");
        }

        private void OpenClicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "XML files| *.xml";
            if (openFile.ShowDialog() == true)
            {
                //MessageBox.Show(openFile.FileName);
                weaponLoader.LoadXML(openFile.FileName);
                WeaponsListBox.Items.Refresh();
            }
        }

        private void SaveClicked(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "XML files | *.xml";
            if (saveFile.ShowDialog() == true)
            {
                // MessageBox.Show(saveFile.FileName);
                weaponLoader.SaveAsXML(saveFile.FileName);
            }
        }

        private void AddClicked(object sender, RoutedEventArgs e)
        {
            WeaponEditor editor = new WeaponEditor();
            if (editor.ShowDialog() == true)
            {
                // MessageBox.Show(editor.TempWeapon.ToString());
                weaponLoader.Add(editor.TempWeapon);
                WeaponsListBox.Items.Refresh();
            }

        }

        private void EditClicked(object sender, RoutedEventArgs e)
        {
            if (WeaponsListBox.SelectedIndex != -1)
            {
                Weapon selectedWeapon = weaponLoader[WeaponsListBox.SelectedIndex];

                WeaponEditor editor = new WeaponEditor();
                editor.Setup(selectedWeapon);

                if (editor.ShowDialog() == true)
                {
                    // MessageBox.Show(editor.TempWeapon.ToString());
                    weaponLoader[WeaponsListBox.SelectedIndex] = editor.TempWeapon;
                    WeaponsListBox.Items.Refresh();
                }
            }
        }

        private void RemoveClicked(object sender, RoutedEventArgs e)
        {
            if (WeaponsListBox.SelectedIndex != -1)
            {
                weaponLoader.RemoveAt(WeaponsListBox.SelectedIndex);
                WeaponsListBox.Items.Refresh();
            }
        }

        private void SortChecked(object sender, RoutedEventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            if (btn != null)
            {
                if (btn.Content.ToString() == "Damage")
                {
                    weaponLoader.Sort(DamageSort);
                }
                else
                {
                    weaponLoader.Sort(NameSort);
                }
                WeaponsListBox.Items.Refresh();
            }
        }

        private int DamageSort(Weapon x, Weapon y)
        {
            return x.Damage - y.Damage;
        }

        private int NameSort(Weapon x, Weapon y)
        {
            return x.Name.CompareTo(y.Name);
        }

        private void SelectedElement(object sender, SelectionChangedEventArgs e)
        {
            if (ShowOnlyElementComboBox.SelectedItem.ToString() == "All")
            {
                WeaponsListBox.ItemsSource = weaponLoader;
                WeaponsListBox.Items.Refresh();
            }
            else
            {
                Element selectedElement = (Element)Enum.Parse(typeof(Element), ShowOnlyElementComboBox.SelectedItem.ToString(), true);
                List<Weapon> elementWeapons = weaponLoader.GetAllWeaponsOfElement(selectedElement);
                WeaponsListBox.ItemsSource = elementWeapons;
                WeaponsListBox.Items.Refresh();
            }
        }
    }
}
