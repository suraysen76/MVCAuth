﻿using MVCAuth.Models;
using System.Security.Cryptography;
using System.Text;

namespace MVCAuth.Handler
{
    public class PasswordHandler
    {
        public static PasswordModel GetPasswordModel(string password,string expectedHash)
        {
            var model =new PasswordModel() { HashedPassword="",Verified=false};
            
            using (MD5 md5Hash = MD5.Create())
            {                
                model.HashedPassword = PasswordHandler.GetMd5Hash(md5Hash, password);
                if (CompareHash(model.HashedPassword, expectedHash))
                {
                    model.Verified= true;
                }
                else
                {
                    model.Verified= false;
                }
            }
            return model;
        }
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.  
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes  
            // and create a string.  
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string.  
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.  
            return sBuilder.ToString();
        }
        // Verify a hash against a string.  
        public static bool CompareHash(string inputHash, string expectedHash)
        {

            // Create a StringComparer an compare the hashes.  
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(inputHash, expectedHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
