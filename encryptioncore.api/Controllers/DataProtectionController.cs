
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace encryptioncore.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataProtectionController : ControllerBase
    {
        private readonly IDataProtector _protector;
        public DataProtectionController(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("Encryption and decryption");
        }
        [HttpGet]
        [Route("encryt")]
        public string GetEncryt(string text)
        {
            string encryptedTxt = _protector.Protect(text);
            return encryptedTxt;
        }

        [HttpGet]
        [Route("dencryt")]
        public string GetDencryt(string encryptedText)
        {
            string decryptedTxt = _protector.Unprotect(encryptedText);
            return decryptedTxt;
        }
    }
}
