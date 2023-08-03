using System.Security.Cryptography;
using System.Text;
namespace PracticaABC.Resources
{
    public class Utilidades
    {
        public static string EncryptClave(string clave) { 
            StringBuilder sb = new StringBuilder();
            using(SHA256 hash = SHA256Managed.Create()) { 
                Encoding enc = Encoding.UTF8;
                byte[] res = hash.ComputeHash(enc.GetBytes(clave));
                foreach(byte b in res)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }
}
