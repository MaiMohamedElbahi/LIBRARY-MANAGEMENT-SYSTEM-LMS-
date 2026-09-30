using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Data;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.AuthUserDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.REPOs.Interface;
using Microsoft.IdentityModel.Tokens;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.REPOs.Implementation
{
    public class AuthUserRepo : GenericRepo<AuthUser>, IAuthUserRepo
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthUserRepo(AppDbContext context, IConfiguration config) : base(context)
        {
            _config = config;
            _context = context;
        }
        private (string Token, DateTime Expiration) GenrateToken(string name)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Jwt:Key"]));
            var signincredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, name)
            };
            var tokenobj = new JwtSecurityToken
            (
                issuer: _config["Jwt : Issuer"],
                audience: _config["Jwt : Audience"],
                claims: claims,
                signingCredentials: signincredentials,
                expires: DateTime.UtcNow.AddHours(2)
            );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenobj);
            return (token, DateTime.UtcNow.AddHours(2));
        }

        public LoginResponseDto Login(LoginDto dto)
        {
            var us = _context.AuthUsers.Where(e => e.UserName == dto.UserName).FirstOrDefault();
            if (us == null)
            {
                return null;
            }
            if (dto.PasswordHash != us.PasswordHash)
            {
                return null;
            }
            var g = GenrateToken(dto.UserName);
            return new LoginResponseDto
            {

                Token = g.Token,
                ExpirationDate = g.Expiration
            };
        }

        public string Register(RegisterDto dto)
        {
            var us = _context.AuthUsers.Where(e => e.UserName == dto.UserName).FirstOrDefault();
            if (us != null)
            {
                return null;
            }
            var user = new AuthUser
            {
                UserName = dto.UserName,
                PasswordHash = dto.PasswordHash,
                Role = dto.Role,
            };
            _context.AuthUsers.Add(user);
            _context.SaveChanges();
            var g = GenrateToken(dto.UserName);
            return g.Token;
        }

        public AuthUser GetByName(string name)
        {
            var u = _context.AuthUsers.Where(e => e.UserName ==  name).FirstOrDefault();
            return u;
        }
    }
}
