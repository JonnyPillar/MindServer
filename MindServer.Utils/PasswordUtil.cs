using System;
using System.Security.Cryptography;
using System.Text;

namespace MindServer.Utils
{
    public class PasswordUtil
    {
        private const int SaltLength = 32;
        private readonly string _passwordHash;
        private readonly string _passwordSalt;

        /// <summary>
        ///     Generate Hash and Salt For Password
        /// </summary>
        /// <param name="password">Password String</param>
        public PasswordUtil(string password)
        {
            _passwordSalt = ByteArrayToHexString(generateSalt());
            _passwordHash = ByteArrayToHexString(generateHash(password, _passwordSalt));
        }

        /// <summary>
        ///     Generate Hash with Pre generated salt for password
        /// </summary>
        /// <param name="password">Password String</param>
        /// <param name="inputPasswordSalt">Password Salt</param>
        public PasswordUtil(string password, string inputPasswordSalt)
        {
            _passwordSalt = inputPasswordSalt;
            _passwordHash = ByteArrayToHexString(generateHash(password, _passwordSalt));
        }

        /// <summary>
        ///     Returns the Password Hash
        /// </summary>
        public string PasswordHash
        {
            get { return _passwordHash; }
        }

        /// <summary>
        ///     Returns the Password Salt
        /// </summary>
        public string PasswordSalt
        {
            get { return _passwordSalt; }
        }

        /// <summary>
        ///     Generate A Hash
        /// </summary>
        /// <param name="password">User Password</param>
        /// <param name="salt">Password Salt</param>
        /// <returns>Resulting Hash</returns>
        private static byte[] generateHash(string password, string salt)
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
        private byte[] generateSalt()
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
        private string ByteArrayToHexString(byte[] ba)
        {
            var hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }
    }
}