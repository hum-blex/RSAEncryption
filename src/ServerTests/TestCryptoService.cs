using Server;

namespace ServerTests;

public class TestCryptoService
{
    [Fact]
    public void PublicKey_ShouldBeGenerated_Correctly()
    {
        string publicKey = CryptoService.GetPublicKey();
        Assert.False(string.IsNullOrEmpty(publicKey));
    }

    [Fact]
    public void EncryptionDecryption_ShouldWork_Correctly()
    {
        string message = "Test Message";
        string publicKey = CryptoService.GetPublicKey();

        string encryptedMessage = CryptoService.Encrypt(message, publicKey);
        Assert.False(string.IsNullOrEmpty(encryptedMessage));

        string decryptedMessage = CryptoService.Decrypt(encryptedMessage);
        Assert.Equal(message, decryptedMessage);
    }

    [Fact]
    public void Decryption_ShouldFail_WhenInvalidCipherText()
    {
        Assert.ThrowsAny<Exception>(() => CryptoService.Decrypt("InvalidCipherText"));
    }
}