using System;
using System.Security.Cryptography;

namespace MindServer.Services.Utils
{
    public static class SessionTokenUtil
    {
        private const int SaltLength = 32;

        public static string GenerateSessionToken()
        {
            var rng = new RNGCryptoServiceProvider();
            var salt = new byte[SaltLength];
            rng.GetBytes(salt);
            return ByteArrayToHexString(salt);
        }

        /// <summary>
        ///     Converty Byte Array to Hex String
        /// </summary>
        /// <param name="ba">Byte Array</param>
        /// <returns>Hexadecimal String</returns>
        private static string ByteArrayToHexString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }
    }
}