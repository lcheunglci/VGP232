using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Week6
{
    public class RSAEncryption
    {
        private RSACryptoServiceProvider mRsa;

        public RSAParameters PrivateKey { get; set; }
        public RSAParameters PublicKey { get; set; }

        public RSAEncryption()
        {
            mRsa = new RSACryptoServiceProvider(2048);
            PrivateKey = mRsa.ExportParameters(true);
            PublicKey = mRsa.ExportParameters(false);
        }

        public RSAEncryption(string privateKeyPath)
        {
            mRsa = new RSACryptoServiceProvider(2048);
            ImportPrivateKey(privateKeyPath);
        }

        public void ExportPrivateKey(string privateKeyPath)
        {
            using (StreamWriter writer = new StreamWriter(privateKeyPath))
            {
                writer.Write(mRsa.ToXmlString(true));
            }
        }

        public void ImportPrivateKey(string privateKeyPath)
        {
            using (StreamReader reader = new StreamReader(privateKeyPath))
            {
                mRsa.FromXmlString(reader.ReadToEnd());
                PrivateKey = mRsa.ExportParameters(true);
            }
        }

        public string Encrypt(string plainText)
        {
            ASCIIEncoding byteConverter = new ASCIIEncoding();
            byte[] plain = byteConverter.GetBytes(plainText);
            Console.WriteLine("before: " + byteConverter.GetString(plain));

            byte[] cipher = mRsa.Encrypt(plain, true);
            //string cipherText = byteConverter.GetString(cipher);

            // This conversion will create a different number of bytes
            string cipherText = Convert.ToBase64String(cipher);
            Console.WriteLine("cipher: " + cipherText);

            byte[] byteToDecypher = byteConverter.GetBytes(cipherText);

            byte[] decipher = mRsa.Decrypt(byteToDecypher, true);
            Console.WriteLine("decipher: " + byteConverter.GetString(decipher));

            return byteConverter.GetString(cipher);
        }

        public string Decrypt(string cipherText)
        {
            ASCIIEncoding byteConverter = new ASCIIEncoding();
            byte[] cipher = byteConverter.GetBytes(cipherText);
            try
            {
                byte[] plain = mRsa.Decrypt(cipher, true);
                return byteConverter.GetString(plain);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return "";
        }
    }
}
