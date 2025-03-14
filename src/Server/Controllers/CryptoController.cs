using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CryptoController : ControllerBase
{
    [HttpGet("public-key")]
    public IActionResult GetPublicKey()
    {
        try
        {
            return Ok(CryptoService.GetPublicKey());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error retrieving public key: {ex.Message}");
        }
    }

    [HttpPost("decrypt")]
    public IActionResult DecryptMessage([FromBody] string encryptedMessage)
    {
        try
        {
            string decryptedMessage = CryptoService.Decrypt(encryptedMessage);
            return Ok(decryptedMessage);
        }
        catch (Exception ex)
        {
            return BadRequest($"Decryption failed: {ex.Message}");
        }
    }

}
