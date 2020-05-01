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
    /// Interaction logic for EditorWindow.xaml
    /// </summary>
    public partial class EditorWindow : Window
    {
        public Weapon MyWeapon { get; set; }
        public EditorWindow()
        {
            InitializeComponent();

            if (MyWeapon == null)
            {
                MyWeapon = new Weapon();
            }

            Setup();
        }

        public void Setup()
        {
            cbElement.ItemsSource = Enum.GetNames(typeof(Element));

            txtName.Text = MyWeapon.Name;
            txtDamage.Text = MyWeapon.Damage.ToString();
            txtRange.Text = MyWeapon.Range.ToString();
            txtAttackSpeed.Text = MyWeapon.AttackSpeed.ToString();
            cbElement.SelectedItem = MyWeapon.WeaponElement;
        }

        private void SaveButtonPressed(object sender, RoutedEventArgs e)
        {
            MyWeapon.Name = txtName.Text;
            MyWeapon.Damage = int.Parse(txtDamage.Text);
            MyWeapon.Range = float.Parse(txtRange.Text);
            MyWeapon.AttackSpeed = int.Parse(txtAttackSpeed.Text);
            MyWeapon.WeaponElement = (Element)Enum.Parse(typeof(Element), cbElement.SelectedItem.ToString());
            //MessageBox.Show(MyWeapon.ToString());
            DialogResult = true;
            Close();
        }

        private void CancelButtonPressed(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        //private void nameChanged(object sender, TextChangedEventArgs e)
        //{
        //    MyWeapon.Name = txtName.Text;
        //}

        //private void damageChanged(object sender, TextChangedEventArgs e)
        //{
        //    MyWeapon.Damage = int.Parse(txtDamage.Text);
        //}

        //private void rangeChanged(object sender, TextChangedEventArgs e)
        //{
        //    MyWeapon.Range = float.Parse(txtRange.Text);
        //}


        //private void nameAttackSpeed(object sender, TextChangedEventArgs e)
        //{
        //    MyWeapon.AttackSpeed = int.Parse(txtAttackSpeed.Text);
        //}

    }
}
