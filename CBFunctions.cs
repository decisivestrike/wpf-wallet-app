using System.Security.Cryptography;
using System.Text;

namespace Coinbase
{
    public class CBFunctions
    { 
        public static string GetHash(string input)
        {
            using (SHA512 hash = SHA512.Create()) 
            {
                return Convert.ToHexString(hash.ComputeHash(Encoding.UTF8.GetBytes(input)));
            }
        }
    }
}
