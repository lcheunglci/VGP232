using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week6
{
    public class RSA
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }

        // RSA

        public void Generate()
        {
            using (var csp = new RSACryptoServiceProvider(2048))
            {
                PrivateKey = csp.ToXmlString(true);
                PublicKey = csp.ToXmlString(false);
            }
        }

        // TODO: add save to file functionality
        public void ExportPublicKey(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(PublicKey);
            }
        }

        public void ExportPrivateKey()
        {
            // TODO: same as above
        }

        public void ImportPrivateKey(string path)
        {
            PrivateKey = File.ReadAllText(path);
            using (var csp = new RSACryptoServiceProvider(2048))
            {
                csp.FromXmlString(PrivateKey);
                // will throw exception if it was not valid
            }
        }

        // TODO: import pub key

        public string Decrypt(string plain)
        {
            string cipher = string.Empty;

            if (string.IsNullOrEmpty(PrivateKey))
            {
                throw new Exception("No key specified");
            }
            
            using (var csp = new RSACryptoServiceProvider(2048))
            {
                csp.FromXmlString(PrivateKey);
                // will throw exception if it was not valid

                byte[] plainBytes = Encoding.UTF8.GetBytes(plain);

                byte[] cipherBytes = csp.Encrypt(plainBytes, false);

                cipher = Convert.ToBase64String(cipherBytes);
            }

            return cipher;
        }


        // TODO: implement the encrypt

    }
}
