using System.Security.Cryptography;

namespace CryptoUtilities
{
    public class HashData
    {
        public static byte[] ComputeHashSha256(byte[] dataToBeHashed)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(dataToBeHashed);
            }
        }
    }
}