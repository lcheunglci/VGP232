using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6
{
    class Program
    {
        static void UserInput()
        {
            string input = "";
            while (true)
            {
                if (input == "-1")
                {
                    break;
                }

                Console.WriteLine("Enter your password");

                input = Console.ReadLine();

                string hashedPassword = Cypto.HashString(input);

                Console.WriteLine(hashedPassword);
            }
        }

        static void HashFile()
        {
            Console.WriteLine("Enter a file path: ");

            string filepath = Console.ReadLine();

            if (File.Exists(filepath))
            {
                string hashString = "";
                using (FileStream fs = new FileStream(filepath, FileMode.Open))
                {
                    byte[] hashedBytes = Cypto.HashBytes(fs);
                    hashString = Encoding.UTF8.GetString(hashedBytes);
                }
                Console.WriteLine(hashString);
            }
        }

        static void Main(string[] args)
        {
            // HashInput();
            // HashFile();

            RSAEncryption rsa = new RSAEncryption();
            //Console.WriteLine("Please enter path to save private key: ");
            Console.WriteLine("Please enter path to load private key: ");
            string filePath = Console.ReadLine();
            //rsa.ExportPrivateKey(filePath);
            rsa.ImportPrivateKey(filePath);

            Console.WriteLine("Please enter text to encrypt: ");
            string input = Console.ReadLine();
            string cipherText = rsa.Encrypt(input);
            Console.WriteLine(cipherText);

            Console.WriteLine("Please enter text to decrypt: ");
            //string input = Console.ReadLine();
            string plain = rsa.Decrypt(cipherText);

            //Console.WriteLine(plain);

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
