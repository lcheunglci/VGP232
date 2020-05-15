using CryptoLib;
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

        public static string myKey = "somethingimports";


        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            byte[] key = Encoding.UTF8.GetBytes(myKey);
            byte[] iv = new byte[16];

            AES aes = new AES(iv, key);

            string cipherText = aes.Encrypt(txtMessage.Text);
            txtEncryptedText.Text = cipherText;
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            byte[] key = Encoding.UTF8.GetBytes(myKey);
            byte[] iv = new byte[16];

            AES aes = new AES(iv, key);

            string plainText = aes.Decrypt(txtEncryptedText.Text);
            txtDecryptedText.Text = plainText;
        }
    }
}
