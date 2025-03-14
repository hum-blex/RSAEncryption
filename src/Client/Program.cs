using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

class Program
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();
        string serverUrl = "http://localhost:5000/api/Crypto";

        //  Get Public Key from Server
        string publicKey = await client.GetStringAsync($"{serverUrl}/public-key");
        Console.WriteLine($"Received Public Key: {publicKey} \n");

        //  Encrypt Message
        Console.WriteLine("Provide text you want to encrypt");
        string? message = Console.ReadLine();
        string encryptedMessage = Encrypt(message, publicKey);
        Console.WriteLine($"Encrypted Message: {encryptedMessage}\n");

        //  Send Encrypted Message
        var content = new StringContent(JsonSerializer.Serialize(encryptedMessage), Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync($"{serverUrl}/decrypt", content);
        string decryptedMessage = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Decrypted Message from Server: {decryptedMessage}");

        Console.ReadLine();
    }

    static string Encrypt(string plaintext, string publicKeyBase64)
    {
        using RSA rsa = RSA.Create();
        rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKeyBase64), out _);
        byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(plaintext), RSAEncryptionPadding.OaepSHA256);
        return Convert.ToBase64String(encryptedData);
    }
}
