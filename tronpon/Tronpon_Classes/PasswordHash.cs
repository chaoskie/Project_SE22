using System;
using System.Text;
using System.Security.Cryptography;

namespace Tronpon_Classes
{  
    public class PasswordHash
    {        
        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;
              
        /// <summary>
        /// Maakt salted PBKDF2 hash van het password.
        /// </summary>
        /// <param name="password">Te hashen password</param>
        /// <returns>De hash van het password</returns>
        public static string CreateHash(string password)
        {
            // Generate random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            // Hash password en encode de parameters
            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Validate password met een correcte/bijbehorende hash
        /// </summary>
        /// <param name="password">Te checken password</param>
        /// <param name="correctHash">hash van het correcte password</param>
        /// <returns>True if password is correct. Anders False</returns>
        public static bool ValidatePassword(string password, string correctHash)
        {
            // Extract parameters uit de hash
            char[] delimiter = { ':' };
            string[] split = correctHash.Split(delimiter);
            int iterations = Int32.Parse(split[ITERATION_INDEX]);
            byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
            byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        /// <summary>
        /// Compares twee byte arrays in length-constant time. deze vergelijkingsmethode
        /// wordt gebruikt zodat passhashes niet onderschept kunnen worden door een
        /// on-line systeem dat een timing-attack gebruikt om vervolgens de hash off-line te decrypten
        /// </summary>
        /// <param name="a">first byte array</param>
        /// <param name="b">second byte array</param>
        /// <returns>True als beide byte arrays equal zijn. Anders False</returns>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }

        /// <summary>
        /// berekent de PBKDF2-SHA1 hash of a password
        /// </summary>
        /// <param name="password">Te hashen password</param>
        /// <param name="salt">De salt</param>
        /// <param name="iterations">De PBKDF2 iteration count</param>
        /// <param name="outputBytes">De length van de te genereren hash, in bytes.</param>
        /// <returns>Hash van het password</returns>
        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
} 
