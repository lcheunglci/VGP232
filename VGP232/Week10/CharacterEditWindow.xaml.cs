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

namespace Week10
{
    /// <summary>
    /// Interaction logic for CharacterEditWindow.xaml
    /// </summary>
    public partial class CharacterEditWindow : Window
    {
        public Character MyCharacter { get; set; }

        public CharacterEditWindow()
        {
            InitializeComponent();
            MyCharacter = new Character();
            this.DataContext = MyCharacter;
        }

        private void SelectPicture(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG Images| *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                MyCharacter.ImagePath = openFileDialog.FileName;
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
