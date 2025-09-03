using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RubyApp.Security
{
    public static class PasswordHasher
    {
        public static string Hash(string password, int iterations = 120_000, int saltSize = 16, int keySize = 32)
        {
            using var rng = RandomNumberGenerator.Create();
            var salt = new byte[saltSize];
            rng.GetBytes(salt);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            var key = pbkdf2.GetBytes(keySize);
            return $"PBKDF2|{iterations}|{Convert.ToBase64String(salt)}|{Convert.ToBase64String(key)}";
        }

        public static bool Verify(string password, string stored)
        {
            var parts = stored.Split('|');
            if (parts.Length != 4 || parts[0] != "PBKDF2") return false;
            int iterations = int.Parse(parts[1]);
            var salt = Convert.FromBase64String(parts[2]);
            var key = Convert.FromBase64String(parts[3]);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            var computed = pbkdf2.GetBytes(key.Length);
            return CryptographicOperations.FixedTimeEquals(computed, key);
        }
    }
}
