using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TawMediaGroup
{
    public static class CommonManager
    {        
        //public static string Encrypt(string text)
        //{
        //    var dataProtectionProvider = DataProtectionProvider.Create("Test App");
        //    var _protector = dataProtectionProvider.CreateProtector("Encryption and decryption");            
        //    string encrytedTxt = _protector.Protect(text);
        //    return encrytedTxt;
        //}
        //public static string Decrypt(string text)
        //{
        //    var dataProtectionProvider = DataProtectionProvider.Create("Test App");
        //    var _protector = dataProtectionProvider.CreateProtector("Encryption and decryption");            
        //    string decryptedTxt = _protector.Unprotect(text);
        //    return decryptedTxt;
        //}

        public static string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(GetKey());
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(GetKey());
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static string GetKey()
        {
            return "b14ca5898a4e4133bbce2ea2315a1916";
        }
    }
}
