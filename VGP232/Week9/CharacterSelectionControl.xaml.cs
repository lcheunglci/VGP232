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
using Week9.Model;

namespace Week9
{
    /// <summary>
    /// Interaction logic for CharacterSelectionControl.xaml
    /// </summary>
    public partial class CharacterSelectionControl : UserControl
    {
        public List<Character> MyCharacters { get; set; }

        public CharacterSelectionControl()
        {
            InitializeComponent();

            MyCharacters = new List<Character>()
            {
                new Character()
                {
                    Name = "Bob",
                    Dialogue = "How are you?",
                    Face = "Images/character_squareGreen.png"
                },
                new Character()
                {
                    Name = "Joe",
                    Dialogue = "Not bad, you?",
                    Face = "Images/character_squareYellow.png"
                }
            };

            characterList.ItemsSource = MyCharacters;
        }
    }
}
