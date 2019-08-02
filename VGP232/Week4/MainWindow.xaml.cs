using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Week3Lib.Data;
using Week3Lib.Loader;

namespace Week4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //List<string> names = new List<string>();
        List<Digimon> digimons = new List<Digimon>();
        public MainWindow()
        {
            InitializeComponent();

            digimons.Add(Digimon.CreateDigimon("aaaa"));
            digimons.Add(Digimon.CreateDigimon("bbbb"));
            digimons.Add(Digimon.CreateDigimon("cccc"));
            digimons.Add(Digimon.CreateDigimon("dddd"));
            /*names.Add("Lawrence");
            names.Add("William");
            names.Add("Kairus");
            names.Add("Rena");
            myListbox.ItemsSource = names;
            */
            myListbox.ItemsSource = digimons;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myLabel.Text = "Lawrence";
        }

        private void MyListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;

            myLabel.Text = listBox.SelectedItem.ToString();
        }

        private void MyListbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            var selectedDigimon = listBox.SelectedItem as Digimon;
            DigiEditWindow window = new DigiEditWindow(selectedDigimon);
            window.ShowDialog();
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openWindow = new OpenFileDialog();

            openWindow.Filter = "CSV File|*.csv|XML File|*.xml|JSON File|*.json";
            if (openWindow.ShowDialog() == true)
            {
                string filePath = openWindow.FileName;
                Console.WriteLine(filePath);

                string ext = System.IO.Path.GetExtension(filePath);
                if (ext == ".csv")
                {
                    Console.WriteLine(filePath);

                    // load csv
                }
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveWindow = new SaveFileDialog();
            if (saveWindow.ShowDialog() == true)
            {
                Console.WriteLine(saveWindow.FileName);
            }
        }
    }
}
