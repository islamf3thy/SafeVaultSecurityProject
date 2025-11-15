using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SafeVaultSecurityProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultController : ControllerBase
    {
        [HttpGet("secure-data")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetSecureData()
        {
            return Ok(new { Message = "Access granted to secure data." });
        }

        [HttpPost("insert")]
        [Authorize(Roles = "Admin")]
        public IActionResult Insert([FromBody] string safeInput)
        {
            if (string.IsNullOrWhiteSpace(safeInput))
                return BadRequest("Input cannot be empty.");

            return Ok($"Data '{safeInput}' saved securely.");
        }
    }
}
