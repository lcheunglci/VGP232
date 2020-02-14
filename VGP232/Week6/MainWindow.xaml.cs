using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Week6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        const string API_URL = "https://api.chucknorris.io/";


        private void GetJokeButtonPressed(object sender, RoutedEventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(API_URL);

                // HTTP GET
                var responseTask = httpClient.GetAsync("jokes/random?category=dev");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadAsStringAsync();
                    res.Wait();

                    string message = res.Result;
                    if (!string.IsNullOrEmpty(message))
                    {

                        Joke joke = JsonConvert.DeserializeObject<Joke>(message);
                        txtJoke.Text = joke.value;
                    }
                }

            }
        }
    }
}
