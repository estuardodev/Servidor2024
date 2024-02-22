using System.Security.Cryptography;
using System.Text;

namespace ServidorWeb.Clases
{
    public class Encrypt
    {

        public static string GetSHA256(string str)
        {
            SHA256 sha = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha.ComputeHash(encoding.GetBytes(str));
            for(int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }

    }
}
