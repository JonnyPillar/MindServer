using System;
using System.Security.Cryptography;
using System.Text;

namespace MindServer.Services.Utils
{
    public class PasswordHashUtil
    {
        private const int SaltLength = 32;

        /// <summary>
        ///     Generate Hash and Salt For Password
        /// </summary>
        /// <param name="password">Password String</param>
        public PasswordHashUtil(string password)
        {
            PasswordSalt = ByteArrayToHexString(GenerateSalt());
            PasswordHash = ByteArrayToHexString(GenerateHash(password, PasswordSalt));
        }

        /// <summary>
        ///     Generate Hash with Pre generated salt for password
        /// </summary>
        /// <param name="password">Password String</param>
        /// <param name="inputPasswordSalt">Password Salt</param>
        public PasswordHashUtil(string password, string inputPasswordSalt)
        {
            PasswordSalt = inputPasswordSalt;
            PasswordHash = ByteArrayToHexString(GenerateHash(password, PasswordSalt));
        }

        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }

        /// <summary>
        ///     Generate A Hash
        /// </summary>
        /// <param name="password">User Password</param>
        /// <param name="salt">Password Salt</param>
        /// <returns>Resulting Hash</returns>
        private static byte[] GenerateHash(string password, string salt)
        {
            var encoder = new UTF8Encoding();
            var sha256Hasher = new SHA256Managed();
            var hashedDataBytes = sha256Hasher.ComputeHash(encoder.GetBytes(password + salt));
            return hashedDataBytes;
        }

        /// <summary>
        ///     Generate A New Salt
        /// </summary>
        /// <returns>Resulting Salt</returns>
        private static byte[] GenerateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var salt = new byte[SaltLength];
            rng.GetBytes(salt);
            return salt;
        }

        /// <summary>
        ///     Converty Byte Array to Hex String
        /// </summary>
        /// <param name="ba">Byte Array</param>
        /// <returns>Hexadecimal String</returns>
        private static string ByteArrayToHexString(byte[] ba)
        {
            var hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }
    }
}