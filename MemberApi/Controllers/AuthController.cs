using MemberApi.Data;
using MemberApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MemberApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private UserDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(UserDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var isUser =   _context.User.FirstOrDefault(u=>u.Email == request.Email);
        if (isUser == null || isUser.Password != request.Password)
        {
            return BadRequest("帳號或密碼錯誤");
        }

        var jwtKey = _configuration["Jwt:Key"];
        var keyBytes = Encoding.UTF8.GetBytes(jwtKey);
        var securityKey = new SymmetricSecurityKey(keyBytes);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        ); var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(tokenString);
    }
}