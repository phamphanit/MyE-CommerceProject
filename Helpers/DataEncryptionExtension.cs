using System;
using System.Security.Cryptography;
using System.Text;

namespace FinalProject.Helpers
{
    public static class DataEncryptionExtension
    {
        public static string ToSHA512Hash(this string password, string saltKey = null)
        {
            SHA512Managed sha512 = new SHA512Managed();
            byte[] encryptedSHA512 = sha512.ComputeHash(Encoding.UTF8.GetBytes(string.Concat(password, saltKey)));
            sha512.Clear();

            return Convert.ToBase64String(encryptedSHA512);
        }
    }
}
