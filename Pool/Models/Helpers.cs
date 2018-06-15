using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Pool.Models
{
    public static class Helpers
    {
        public static string EncryptData(string value)
        {
            var provider = new SHA512Managed();
            var encoding = new UnicodeEncoding();
            return Convert.ToBase64String(provider.ComputeHash(encoding.GetBytes(value)));
        }

        public static bool CompareHash(string oldValue, string newValue)
        {
            return oldValue == newValue;
        }
    }
}