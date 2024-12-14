using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Helpers.Helpers
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Şifreyi SHA-256 algoritmasıyla hashler.
        /// </summary>
        /// <param name="password">Hashlenecek şifre</param>
        /// <returns>Base64 formatında hashlenmiş şifre</returns>
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);// hashledik
            }
        }

        /// <summary>
        /// Hashlenmiş şifreyi doğrular.
        /// </summary>
        /// <param name="password">Kullanıcının girdiği şifre</param>
        /// <param name="hashedPassword">Veritabanındaki hashlenmiş şifre</param>
        /// <returns>Doğruluk sonucu (bool)</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            string hashOfInput = HashPassword(password); // Kullanıcıdan gelen şifreyi hashle
            return hashOfInput == hashedPassword; // Hashi veritabanındakiyle karşılaştır
        }
    }
}
