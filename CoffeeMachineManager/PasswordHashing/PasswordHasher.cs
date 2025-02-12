﻿using CoffeeMachineManager.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace CoffeeMachineManager.PasswordHashing
{
    public class PasswordHasher : IPasswordHasher
    {
        // THIS IS NOT the right way to password hashing, just a showcase of it.
        // A real implementation should use: https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.passwordhasher-1?view=aspnetcore-8.0
        // Read more here: https://learn.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-8.0
        // This method is code used in the example from Microsoft: https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithm.computehash?view=net-8.0
        public string GetHash(string userPwdInput)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = SHA256.HashData(Encoding.UTF8.GetBytes(userPwdInput));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
