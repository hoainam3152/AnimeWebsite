using System.Security.Cryptography;

namespace AccountService.Helpers
{
    public class Pbkdf2Hasher
    {
        private const int SaltSize = 16; // 128 bit
        private const int HashSize = 64; // 512 bit
        private const int Iterations = 10000;

        public static byte[] GenerateRandomSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public static string HashPassword(string password) 
        {
            byte[] salt = GenerateRandomSalt();

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA512);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            byte[] hashBytes = new byte[SaltSize + HashSize];
            Buffer.BlockCopy(salt, 0, hashBytes, 0, SaltSize);
            Buffer.BlockCopy(hash, 0, hashBytes, SaltSize, HashSize);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            byte[] salt = new byte[SaltSize];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, SaltSize);

            byte[] storedHash = new byte[HashSize];
            Buffer.BlockCopy(hashBytes, SaltSize, storedHash, 0, HashSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA512);
            byte[] inputHash = pbkdf2.GetBytes(HashSize);

            return CryptographicOperations.FixedTimeEquals(storedHash, inputHash);
        }
    }
}
