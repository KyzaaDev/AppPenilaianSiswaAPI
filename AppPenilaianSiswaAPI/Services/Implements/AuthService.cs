using AppPenilaianSiswaAPI.Data;
using AppPenilaianSiswaAPI.DTOs.Auths;
using AppPenilaianSiswaAPI.Models;
using AppPenilaianSiswaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppPenilaianSiswaAPI.Services.Implements
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        public AuthService(AppDbContext con, IConfiguration conf)
        {
            _config = conf;
            _context = con;
        }

        public async Task<AuthResponseDTO> Login(LoginRequestDTO data)
        {
            var user = await _context.Operators.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == data.Username);
            if (user == null) return null;

            var isValid = BCrypt.Net.BCrypt.Verify(data.Password, user.Password);
            if (!isValid) throw new Exception("Username atau password salah!");

            return new AuthResponseDTO
            {
                Username = user.Username,
                Role = user.Role.RoleName,
                OperatorId = user.OperatorId,
                Token = CreateToken(user)
            };

        }

        private string CreateToken(Operator user)
        {
            var jwtConf = _config.GetSection("Jwt");
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.OperatorId.ToString()),
                new Claim(ClaimTypes.Role, user.Role.RoleName),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConf["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: jwtConf["Issuer"],
                audience: jwtConf["Audience"],
                signingCredentials: creds,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(jwtConf["Lifetime"])),
                claims: claims
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
