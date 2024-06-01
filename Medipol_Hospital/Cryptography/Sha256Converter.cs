using System.Security.Cryptography;
using System.Text;

namespace Medipol_Hospital.Cryptography
{
    public static class Sha256Converter
    {
        public static string ComputeSha256Hash(string hamveri)  //ham veriyi al
        {
            // SHA256 oluştur
            using (SHA256 sha256Hash = SHA256.Create())
            {         
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(hamveri));
                
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString(); //işlenmiş veriyi gönder
            }
        }
    }
}
