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
using Microsoft.Win32;

namespace Week6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Crypto crypto;

        public MainWindow()
        {
            InitializeComponent();
            crypto = new Crypto();
            crypto.Initialize(CryptoAlgorithm.AES);
        }

        private void EncryptPressed(object sender, RoutedEventArgs e)
        {
            string plainText = tbPlainText.Text;
            plainText = plainText.Replace(' ', '+');
            int padding = plainText.Length % 4;
            if (padding != 0)
            {
                plainText += new string('+', 4 - padding);
            }

            byte[] data = Convert.FromBase64String(plainText);


            byte[] cipherData = crypto.Encrypt(data);
            string cipherText = Convert.ToBase64String(cipherData);
            tbCipherText.Text = cipherText;
            // tbCipherText.Tag = cipherData;
        }

        private void DecryptPressed(object sender, RoutedEventArgs e)
        {
            string cipherText = tbCipherText.Text;
            //cipherText = cipherText.Replace(' ', '+');
            //int padding = cipherText.Length % 4;
            //if (padding != 0)
            //{
            //    cipherText += new string('+', 4 - padding);
            //}

            byte[] cipherData = Convert.FromBase64String(cipherText);


            byte[] plainData = crypto.Decrypt(cipherData);
            string plainText = Convert.ToBase64String(plainData);
            tbDecipherText.Text = plainText;
        }

        private void SavePressed(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, tbDecipherText.Text);
            }
        }

    }
}
