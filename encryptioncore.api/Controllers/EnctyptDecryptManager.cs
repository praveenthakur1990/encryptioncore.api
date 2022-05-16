using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace encryptioncore.api.Controllers
{
    public static class EnctyptDecryptManager
    {
        //private readonly IDataProtector _protector;
        
        //public EnctyptDecryptManager(IDataProtectionProvider provider)
        //{
        //    _protector = provider.CreateProtector("Encryption and decryption");
        //}
        public static string Encrypt(string text)
        {
            var dataProtectionProvider = DataProtectionProvider.Create("Test App");
            var _protector = dataProtectionProvider.CreateProtector("Encryption and decryption");
            DataProtectionController obj = new DataProtectionController(_protector);
            string encrytedTxt= obj.GetEncryt(text);
            return encrytedTxt;
        }
        public static string Decrypt(string text)
        {
            var dataProtectionProvider = DataProtectionProvider.Create("Test App");
            var _protector = dataProtectionProvider.CreateProtector("Encryption and decryption");
            DataProtectionController obj = new DataProtectionController(_protector);
            string decryptedTxt = obj.GetDencryt(text);
            return decryptedTxt;
        }

    }
}
