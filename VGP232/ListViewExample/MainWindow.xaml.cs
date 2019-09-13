using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ListViewExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<string> names;
        ObservableCollection<Person> names;


        public MainWindow()
        {
            InitializeComponent();
            names = new ObservableCollection<Person>();

            ListStuff.ItemsSource = names;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            //names.Add(new Person(){ Name="Bob", Age=10});
            try
            {
                Person p = new Person() { Name = TextName.Text, Age = int.Parse(TextAge.Text) };
                names.Add(p);
            }
            catch (Exception)
            {
                // ignore
            }
            
            // ListStuff.ItemsSource = null;
            // ListStuff.ItemsSource = names;
        }
    }
}
