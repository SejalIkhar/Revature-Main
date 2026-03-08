using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SecurityDemoApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecurityDemoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    public AuthController(IConfiguration config) => _config = config;

    [HttpPost("login")]
    public IActionResult Login(LoginRequest req)
    {
        // ✅ Demo validation (replace with DB later)
        if (string.IsNullOrWhiteSpace(req.Username) || string.IsNullOrWhiteSpace(req.Password))
            return BadRequest("Username/Password required.");

        if (req.Password != "123") // demo password
            return Unauthorized("Invalid credentials.");

        var (token, expiresAt) = GenerateToken(req.Username, req.Role, req.Department);

        return Ok(new AuthResponse { Token = token, ExpiresAtUtc = expiresAt });
    }

    private (string token, DateTime expiresAtUtc) GenerateToken(string username, string role, string department)
    {
        var jwt = _config.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role),                 // ✅ Role-based authorization
            new Claim("Department", department),              // ✅ Claims-based authorization
            new Claim("UserId", Guid.NewGuid().ToString())    // extra claim
        };

        var expires = DateTime.UtcNow.AddMinutes(double.Parse(jwt["DurationInMinutes"]!));

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return (tokenString, expires);
    }
}