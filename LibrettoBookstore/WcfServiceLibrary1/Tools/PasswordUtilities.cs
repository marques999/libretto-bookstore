using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace LibrettoWCF.Tools
{
    /// <summary>
    /// 
    /// </summary>
    internal class PasswordUtilities
    {
        /// <summary>
        /// 
        /// </summary>
        public const int SaltBytes = 24;
        public const int HashBytes = 18;
        public const int Pbkdf2Iterations = 64000;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public static string Hash(string userPassword)
        {
            var randomBytes = new byte[SaltBytes];

            try
            {
                using (var csprng = new RNGCryptoServiceProvider())
                {
                    csprng.GetBytes(randomBytes);
                }
            }
            catch
            {
                return null;
            }

            return GeneratePassword(randomBytes, Pbkdf2(userPassword, randomBytes, Pbkdf2Iterations, HashBytes));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="randomBytes"></param>
        /// <param name="generatedHash"></param>
        /// <returns></returns>
        private static string GeneratePassword(byte[] randomBytes, byte[] generatedHash)
        {
            return $"sha1:{Pbkdf2Iterations}:{generatedHash.Length}:{Convert.ToBase64String(randomBytes)}:{Convert.ToBase64String(generatedHash)}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="goodHash"></param>
        /// <returns></returns>
        public static bool Verify(string password, string goodHash)
        {
            var split = goodHash.Split(':');

            if (split.Length != 5 || split[0] != "sha1")
            {
                return false;
            }

            try
            {
                var iterations = int.Parse(split[1]);

                if (iterations > 0)
                {
                    return int.Parse(split[2]) == Convert.FromBase64String(split[4]).Length && SlowEquals(Convert.FromBase64String(split[4]), Pbkdf2(password, Convert.FromBase64String(split[3]), iterations, Convert.FromBase64String(split[4]).Length));
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static bool SlowEquals(IReadOnlyList<byte> a, IReadOnlyList<byte> b)
        {
            var diff = (uint)a.Count ^ (uint)b.Count;

            for (var i = 0; i < a.Count && i < b.Count; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }

            return diff == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="iterations"></param>
        /// <param name="outputBytes"></param>
        /// <returns></returns>
        private static byte[] Pbkdf2(string password, byte[] salt, int iterations, int outputBytes)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt))
            {
                pbkdf2.IterationCount = iterations;
                return pbkdf2.GetBytes(outputBytes);
            }
        }
    }
}