using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Week6
{
    public enum CryptoAlgorithm { AES, RSA }

    public class Crypto
    {
        AesCryptoServiceProvider aes;
        // RSACryptoServiceProvider rsa;

        CryptoAlgorithm mType;

        public void Initialize(CryptoAlgorithm type)
        {
            mType = type;
            aes = new AesCryptoServiceProvider();
        }

        public void Terminate()
        {
            if (aes != null)
            {
                aes.Dispose();
            }
        }


        public byte[] Encrypt(byte[] data)
        {
            if (data == null || data.Length == 0)
            {
                return null;
            }

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();
                }

                return ms.ToArray();
            }
        }

        public byte[] Decrypt(byte[] data)
        {
            if (data == null || data.Length == 0)
            {
                return null;
            }

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();
                }

                return ms.ToArray();
            }
        }
    }
}
