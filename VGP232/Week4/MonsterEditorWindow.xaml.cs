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
    /// Interaction logic for MonsterEditorWindow.xaml
    /// </summary>
    public partial class MonsterEditorWindow : Window
    {
        public Monster SavedMonster { get; set; }

        public MonsterEditorWindow()
        {
            InitializeComponent();

            cbElement.ItemsSource = Enum.GetNames(typeof(Element));
            cbAbility.ItemsSource = Enum.GetNames(typeof(Ability));
        }

        public void Setup()
        {
            if (SavedMonster == null)
            {
                return;
            }

            txtName.Text = SavedMonster.name;
            txtHP.Text = SavedMonster.health.ToString();
            cbAbility.Text = SavedMonster.ability.ToString();
            cbElement.Text = SavedMonster.element.ToString();
            lbParts.ItemsSource = SavedMonster.parts;
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            // Save logic
            SavedMonster = new Monster()
            {
                name = txtName.Text,
                health = int.Parse(txtHP.Text),
                ability = (Ability)Enum.Parse(typeof(Ability), cbAbility.Text),
                element = (Element)Enum.Parse(typeof(Element), cbElement.Text),
                parts = lbParts.ItemsSource as List<string>
            };

            DialogResult = true;
            Close();
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
