using System;

namespace EncryptionConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string encryptedStr = TawMediaGroup.CommonManager.EncryptString("This is a testing text");
            string decryptedStr = TawMediaGroup.CommonManager.DecryptString(encryptedStr);

        }
    }
}
