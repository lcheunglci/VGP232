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
    /// Interaction logic for WeaponEditor.xaml
    /// </summary>
    public partial class WeaponEditor : Window
    {
        public Weapon TempWeapon { get; set; }

        public WeaponEditor()
        {
            InitializeComponent();
            // elementSelection.ItemsSource = new List<String> { "stuff1", "a", "v" };
            elementSelection.ItemsSource = Enum.GetNames(typeof(Element));
            TempWeapon = new Weapon();
            this.DataContext = TempWeapon;
            this.Title = "Add Weapon";
            SubmitButton.Content = "Add";
        }

        public void Setup(Weapon weapon)
        {
            TempWeapon = weapon;
            this.DataContext = TempWeapon;
            this.Title = "Edit Weapon";
            SubmitButton.Content = "Save";
        }

        private void CancelClicked(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void SaveClicked(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
