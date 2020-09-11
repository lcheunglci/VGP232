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

namespace Week10
{
    /// <summary>
    /// Interaction logic for CharacterWindow.xaml
    /// </summary>
    public partial class CharacterWindow : Window
    {
        List<Character> characters;

        public CharacterWindow()
        {
            InitializeComponent();
            characters = new List<Character>()
            {
                new Character() { Name="Bob", HealthPoints =100, ImagePath="Images/character_roundGreen.png" },
                new Character() { Name = "Alice", HealthPoints = 80, ImagePath = "Images/character_roundRed.png" },
                new Character() { Name = "Joe", HealthPoints = 120, ImagePath = "Images/character_roundPurple.png" }
            };
            lbCharacters.ItemsSource = characters;

        }

        private void AddCharacter(object sender, RoutedEventArgs e)
        {
            CharacterEditWindow editor = new CharacterEditWindow();
            if (editor.ShowDialog() == true)
            {
                characters.Add(editor.MyCharacter);
                lbCharacters.Items.Refresh();
            }
        }
    }
}
