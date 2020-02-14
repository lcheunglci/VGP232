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
            Key = "1111111111111111";
            // Add 0
            // 0000000001830026
        }

        const string API_URL = "https://api.chucknorris.io/";
        public string Key { get; set; }

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

        private void DecryptButtonPressed(object sender, RoutedEventArgs e)
        {
            string cipher = txtEncrypted.Text;
            if (string.IsNullOrEmpty(cipher) || string.IsNullOrEmpty(Key))
            {
                return;
            }
            string plain = string.Empty;

            try
            {
                plain = AES.AESDecrypt(Key, cipher);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to decrypt: " + ex.Message);
            }

            txtDecrypted.Text = plain;
        }

        private void EncryptButtonPressed(object sender, RoutedEventArgs e)
        {
            string plain = txtJoke.Text;
            if (string.IsNullOrEmpty(plain) || string.IsNullOrEmpty(Key))
            {
                return;
            }

            string cipher = AES.AESEncrypt(Key, plain);

            txtEncrypted.Text = cipher;
        }
    }
}
