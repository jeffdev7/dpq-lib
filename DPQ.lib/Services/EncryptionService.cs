using System.Security.Cryptography;
using System.Text;

namespace DPQ.lib.Services
{
    public static class EncryptionService
    {
        private static readonly string DefaultKey = "DPQ-SecretKey-2025-ChangeInProd!";

        public static string Encrypt(string plainText, string key = null)
        {
            try
            {
                var keyBytes = Encoding.UTF8.GetBytes((key ?? DefaultKey).PadRight(32).Substring(0, 32));
                var data = Encoding.UTF8.GetBytes(plainText);

                using var aes = Aes.Create();
                aes.Key = keyBytes;
                aes.GenerateIV();

                using var encryptor = aes.CreateEncryptor();
                var encrypted = encryptor.TransformFinalBlock(data, 0, data.Length);

                var result = new byte[aes.IV.Length + encrypted.Length];
                Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
                Buffer.BlockCopy(encrypted, 0, result, aes.IV.Length, encrypted.Length);

                return Convert.ToBase64String(result);
            }
            catch
            {
                return "***ENCRYPTED***";
            }
        }

        public static string Decrypt(string cipherText, string key = null)
        {
            try
            {
                var keyBytes = Encoding.UTF8.GetBytes((key ?? DefaultKey).PadRight(32).Substring(0, 32));
                var fullCipher = Convert.FromBase64String(cipherText);

                using var aes = Aes.Create();
                aes.Key = keyBytes;

                var iv = new byte[aes.IV.Length];
                var cipher = new byte[fullCipher.Length - iv.Length];

                Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, cipher.Length);

                aes.IV = iv;

                using var decryptor = aes.CreateDecryptor();
                var decrypted = decryptor.TransformFinalBlock(cipher, 0, cipher.Length);

                return Encoding.UTF8.GetString(decrypted);
            }
            catch
            {
                return null;
            }
        }
    }
}
