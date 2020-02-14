using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week6
{
    public static class AES
    {
        public static string AESEncrypt(string key, string plain)
        {
            string cipherText = string.Empty;

            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plain);
                        }
                    }

                    array = ms.ToArray();
                    cipherText = Convert.ToBase64String(array);
                }


            }

            return cipherText;
        }

        public static string AESDecrypt(string key, string cipher)
        {
            string plain = string.Empty;
            byte[] buffer = Convert.FromBase64String(cipher);
            byte[] iv = new byte[16];

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sw = new StreamReader(cs))
                        {
                            plain = sw.ReadToEnd();
                        }
                    }
                }
            }

            return plain;
        }


    }
}
