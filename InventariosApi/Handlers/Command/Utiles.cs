using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;

namespace InventariosApi.Handlers.Command
{
    public class Utiles
    {
        public Utiles() { }


        public bool CheckStringWithoutSpecialChars(string word)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            return regexItem.IsMatch(word);
        }

        public bool CheckStringWithUppercaseLetters(string word)
        {
            var regexItem = new Regex("[A-Z]");
            return regexItem.IsMatch(word);
        }

        public string GetSha256Hash(string input)
        {
            using (var hashAlgorithm = new SHA256CryptoServiceProvider())
            {
                var byteValue = Encoding.UTF8.GetBytes(input);
                var byteHash = hashAlgorithm.ComputeHash(byteValue);
                return Convert.ToBase64String(byteHash);
            }
        }
    }
}

