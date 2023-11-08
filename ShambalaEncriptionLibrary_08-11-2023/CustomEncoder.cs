using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShambalaEncriptionLibrary_08_11_2023
{
    public class CustomEncoder
    {
        public string encode(string line)
        {
            string s;
            // вводим строку
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(line);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                s = System.Text.Encoding.UTF8.GetString(hashBytes, 0, hashBytes.Length);
            }
            return s;
        }
    }
}
