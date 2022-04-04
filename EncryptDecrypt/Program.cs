using System;
using System.Security.Cryptography;


namespace EncryptDecrypt
{
    class Program
    {

        private static byte[] KEY;
        private static byte[] IV;
        static void Main(string[] args)
        {
            var tripleDes = new TripleDESCryptoServiceProvider();

            KEY = tripleDes.Key;
            IV = tripleDes.IV;
            Console.WriteLine(string.Join(",", KEY));
            var text = "salam baku";
            var cipherText = Encrypt(text);
            Console.WriteLine(cipherText);

        }
        public static string Encrypt(string text)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes(text);
            var tripleDes = new TripleDESCryptoServiceProvider()
            {
                IV = IV,
                Key = KEY
            };
            ICryptoTransform transform = tripleDes.CreateEncryptor();

            var cipherText = transform.TransformFinalBlock(buffer, 0, buffer.Length);
            return Convert.ToBase64String(cipherText);

        } 

        public static string Decrypt(string encryptedText)
        {
            var buffer = Convert.FromBase64String(encryptedText);
            var tripleDes = new TripleDESCryptoServiceProvider()
            {
                IV = IV,
                Key = KEY
            };

            ICryptoTransform transform = tripleDes.CreateDecryptor();
            var plainText = transform.TransformFinalBlock(buffer, 0, buffer.Length);
            return Convert.ToBase64String(plainText);

             
        }
    }
}
