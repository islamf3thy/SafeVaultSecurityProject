using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeVaultSecurityProject.Data;
using SafeVaultSecurityProject.Models;
using SafeVaultSecurityProject.Services;
using System.Security.Cryptography;
using System.Text;

namespace SafeVaultSecurityProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SafeVaultDbContext _context;
        private readonly AuthService _authService;

        public AuthController(SafeVaultDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Username == user.Username))
                return BadRequest("Username already exists.");

            user.PasswordHash = ComputeHash(user.PasswordHash);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username);
            if (user == null || user.PasswordHash != ComputeHash(login.PasswordHash))
                return Unauthorized("Invalid credentials.");

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        private string ComputeHash(string input)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(bytes);
        }
    }
}
