using CertificateManager;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Cryptography;
using System.Text;

namespace EncryptDecryptManager
{
    public class EncryptDecryptManager
    {
        private string Encrypt(string text)
        {
            //var serviceProvider = new ServiceCollection()
            //   .AddCertificateManager()
            //   .BuildServiceProvider();

            //var cc = serviceProvider.GetService<CreateCertificates>();

            //var cert3072 = CreateRsaCertificates.CreateRsaCertificate(cc, 3072);
            //RSA rsa = Utility.CreateRsaPublicKey(cert3072);
            //byte[] data = Encoding.UTF8.GetBytes(text);
            //byte[] cipherText = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
            //return Convert.ToBase64String(cipherText);
            return "";
        }

        private string Decrypt(string text, RSA rsa)
        {
            byte[] data = Convert.FromBase64String(text);
            byte[] cipherText = rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
            return Encoding.UTF8.GetString(cipherText);
        }
    }


}
