using System.Security.Cryptography;
using System.Text;

namespace Server;

public class CryptoService
{
    // Generating 2048-bit RSA key
    private static RSA _rsa = RSA.Create(2048);

    public static string GetPublicKey()
    {
        // Encoding to base64 for easy transmission.
        return Convert.ToBase64String(_rsa.ExportRSAPublicKey());
    }

    public static string Encrypt(string plaintext, string publicKeyBase64)
    {
        RSA rsa = RSA.Create();

        // Converting the base64-encoded public key back into raw byte format and import it.
        rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKeyBase64), out _);

        // Encrypting plaintext using OAEP (Optimal Asymmetric Encryption Padding) with SHA-256 for enhanced security.
        byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(plaintext), RSAEncryptionPadding.OaepSHA256);

        return Convert.ToBase64String(encryptedData);
    }

    public static string Decrypt(string encryptedText)
    {
        byte[] decryptedData = _rsa.Decrypt(Convert.FromBase64String(encryptedText), RSAEncryptionPadding.OaepSHA256);

        return Encoding.UTF8.GetString(decryptedData);
    }
}
