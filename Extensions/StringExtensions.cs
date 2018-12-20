using System;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidIpv4(this string text)
        {
            if (text == null)
            {
                return false;
            }

            Regex regex = new Regex(@"^(?:(?:^|\.)(?:2(?:5[0-5]|[0-4]\d)|1?\d?\d)){4}$");
            return regex.IsMatch(text);
        }

        public static bool IsValidIpv6(this string text)
        {
            if (text == null)
            {
                return false;
            }

            Regex regex = new Regex(@"(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))");
            return regex.IsMatch(text);
        }

        public static bool IsEmail(this string text)
        {
            try
            {
                new MailAddress(text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string EmptyStringIfNull(this string text) => text ?? string.Empty;

        public static bool IsNumeric(this string text)
        {
            if (text.IsNullOrEmpty())
            {
                return false;
            }

            var charArray = text.ToCharArray();

            if (text.Length > 1 && charArray.First().Equals('-'))
            {
                charArray = charArray.TakeLast(charArray.Length - 2).ToArray();
            }
            return charArray.All(char.IsNumber);
        }

        public static string Encrypt(this string text, string key)
        {
            if (text.IsNullOrEmpty())
            {
                throw new ArgumentException($"Text has incorrect value (probably is empty or null). Text to encrypt: {text}.");
            }
            using (var tripleDes = new TripleDESCryptoServiceProvider())
            {
                tripleDes.Key = key.ComputeHash();
                tripleDes.Mode = CipherMode.ECB;
                tripleDes.Padding = PaddingMode.PKCS7;

                using (var transform = tripleDes.CreateEncryptor())
                {
                    byte[] textBytes = Encoding.UTF8.GetBytes(text);
                    byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                    return Convert.ToBase64String(bytes, 0, bytes.Length);
                }
            }
            
        }

        public static string Decrypt(this string text, string key)
        {
            if (text.IsNullOrEmpty())
            {
                throw new ArgumentException($"Text has incorrect value (probably is empty or null). Text to decrypt: {text}.");
            }
            using (var tripleDes = new TripleDESCryptoServiceProvider())
            {
                tripleDes.Key = key.ComputeHash();
                tripleDes.Mode = CipherMode.ECB;
                tripleDes.Padding = PaddingMode.PKCS7;

                using (var transform = tripleDes.CreateDecryptor())
                {
                    byte[] cipherBytes = Convert.FromBase64String(text);
                    byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                    return Encoding.UTF8.GetString(bytes);
                }
            }
            
        }

        public static bool IsNull(this string text) => text is null;

        public static bool IsNullOrEmpty(this string text) => text == null || text == string.Empty;

        public static byte[] ComputeHash(this string text)
        {
            if (text.IsNullOrEmpty())
            {
                throw new ArgumentException($"Key has incorrect value (probably is empty or null). Text to decrypt: {text}.");
            }
            using (var md5 = new MD5CryptoServiceProvider())
            {
                return md5.ComputeHash(Encoding.UTF8.GetBytes(text));
            }
        }
    }
}
