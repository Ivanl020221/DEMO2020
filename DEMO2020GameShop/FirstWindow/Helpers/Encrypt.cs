using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DEMO2020GameShop.FirstWindow.Helpers
{
    class Encrypt
    {
        public static string EncryptData(string data)
        {
            string sult = "hgjkhlijok;p'l[";
            byte[] original = Encoding.ASCII.GetBytes(data + sult);
            MD5 mD5 = new MD5CryptoServiceProvider();
            byte[] encrypt = mD5.ComputeHash(original);
            return BitConverter.ToString(encrypt);
        }

    }
}
