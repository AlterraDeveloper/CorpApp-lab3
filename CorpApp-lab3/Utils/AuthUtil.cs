using System.Security.Cryptography;
using System.Text;

namespace CorpApp_lab3.Utils
{
    public class AuthUtil
    {
        public static string GetPasswordHash(string password)
        {
            return Encoding.ASCII.GetString(
                new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(password)));
        }
    }
}