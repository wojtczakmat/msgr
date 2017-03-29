using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace msgr.Helpers
{
    public class HashHelper
    {
        public static string GenerateHash(string str)
        {
            using (SHA256 hash = SHA256.Create()) {
                return string.Concat(hash
                .ComputeHash(Encoding.UTF8.GetBytes(str))
                .Select(item => item.ToString("x2")));
            }
        }
    }
}