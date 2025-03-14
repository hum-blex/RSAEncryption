using Microsoft.AspNetCore.Mvc;
using Server;
using Server.Controllers;

namespace ServerTests;

public class TestCryptoController
{
    private readonly CryptoController _controller = new CryptoController();

    [Fact]
    public async Task GetPublicKey_ShouldReturn_ValidPublicKey()
    {
        var result = _controller.GetPublicKey() as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.False(string.IsNullOrWhiteSpace(result.Value?.ToString()));
    }

    [Fact]
    public void Encrypt_ShouldReturnEncryptedMessage()
    {
        // Arrange
        string publicKey = CryptoService.GetPublicKey();
        string message = "Hello, Test!";

        // Act
        var result = _controller.Encrypt(message, publicKey) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.False(string.IsNullOrWhiteSpace(result.Value?.ToString()));
        Assert.NotEqual(message, result.Value?.ToString());
    }

    [Fact]
    public void EncryptDecrypt_ShouldReturnOriginalMessage()
    {
        // Arrange
        string publicKey = CryptoService.GetPublicKey();
        string message = "Is this test working?";
        string encryptedMessage = CryptoService.Encrypt(message, publicKey);

        // Act
        var decryptedResult = _controller.DecryptMessage(encryptedMessage) as OkObjectResult;

        // Assert
        Assert.NotNull(decryptedResult);
        Assert.Equal(200, decryptedResult.StatusCode);
        Assert.Equal(message, decryptedResult.Value);
    }
}
