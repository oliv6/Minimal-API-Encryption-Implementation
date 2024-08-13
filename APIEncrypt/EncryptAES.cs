using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace APIEncrypt
{
    
        public class EncryptAES
    {

        public (string Key, string IVBase64) InitSymmetricEncryptionKeyIV()
        {
            var key = extractKeyValue(32); // 256
            Aes cipher = CreateCipher(key);
            var IVBase64 = Convert.ToBase64String(cipher.IV);
            return (key, IVBase64);
        }


        private string extractKeyValue(int len)
        {
            string json = File.ReadAllText("appsettings.json");
            Configuration config = JsonSerializer.Deserialize<Configuration>(json); //Reading key from configuration file after deserializing.
            String key = config.RandomValues.KeyAES;
            return key;
        }


        Aes CreateCipher(string keyBase64)
        {
            // Default values: Keysize 256, Padding PKC27
            Aes cipher = Aes.Create();
            cipher.Mode = CipherMode.CBC;  // Ensure the integrity of the ciphertext if using CBC

            cipher.Padding = PaddingMode.ISO10126;
            cipher.Key = Convert.FromBase64String(keyBase64);

            return cipher;
        }
       

        public string startEncrypt(string text, string IV, string key)
        {
            Aes cipher = CreateCipher(key);
            cipher.IV = Convert.FromBase64String(IV);

            ICryptoTransform cryptTransform = cipher.CreateEncryptor();
            byte[] plaintext = Encoding.UTF8.GetBytes(text);
            byte[] cipherText = cryptTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);

            return Convert.ToBase64String(cipherText);
        }


        public string Decrypt(string encryptedText, string IV, string key)
        {
            Aes cipher = CreateCipher(key);
            cipher.IV = Convert.FromBase64String(IV);

            ICryptoTransform cryptTransform = cipher.CreateDecryptor();
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            byte[] plainBytes = cryptTransform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return Encoding.UTF8.GetString(plainBytes);
        }
    }
}
