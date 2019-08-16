using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week6
{
    public class Cypto
    {
        public static string HashString(string plainText)
        {
            string hashedString = string.Empty;
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            using (SHA256 sha256 = SHA256Managed.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(plainBytes);
                hashedString = Encoding.UTF8.GetString(hashedBytes);
            }

            return hashedString;
        }

        public static byte[] HashBytes(FileStream filestream)
        {
            using (SHA256 sha256 = SHA256Managed.Create())
            {
                return sha256.ComputeHash(filestream);
            }
        }

    }
}
