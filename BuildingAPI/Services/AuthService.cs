using BuildingAPI.Data;
using BuildingAPI.Dto.Auth_Dto;
using BuildingAPI.Dto.TokenDto;
using BuildingAPI.Interfaces;
using BuildingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace BuildingAPI.Services
{
    public class AuthService: IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;
        public AuthService(IConfiguration configuration, DataContext context) 
        {
            _configuration = configuration;
            _context = context;

        }

        public async Task<User> Register(UserDto request)
        {
            CreatePaswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User();

            user.Email = request.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            user.Role = "User"; // change to make users insted of admins on registration <Admin, User>

            _context.Add(user);
             
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<TokenDto> Login(UserDto request, HttpResponse Response)
        {
            var tokens = new TokenDto();
            var user = await _context.Users.FirstOrDefaultAsync(b => b.Email == request.Email);


            if (user != null) 
            {
                if (user.Email != request.Email)
                {
                    throw new Exception("Email not found");
                }

                if (user.PasswordHash != null && user.PasswordSalt != null)
                    if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                    {
                        throw new Exception("Password wrong");
                    } 
            }

            if (user == null)
                throw new Exception("User not found");

            string token = CreateToken(user);

            var refreshToken = GenerateRefreshToken();

            tokens.AccessToken = token;
            tokens.RefreshToken = refreshToken;
            tokens.Role = user.Role;
            tokens.UserId = user.Id;


            return tokens;
        }

        public async Task<string> RefreshToken(string refreshToken, UserDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(b => b.Email == request.Email);

            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found");
            }

            var isValid = IsRefreshTokenValid(refreshToken);
            if (!isValid)
            {
                throw new UnauthorizedAccessException("Token expired.");
            }

            string token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();

            return newRefreshToken;
        }

        private bool IsRefreshTokenValid(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                var token = handler.ReadToken(jwt) as JwtSecurityToken;
                if (token == null)
                    return false;
                return token.ValidTo >= DateTime.UtcNow;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string GenerateRefreshToken()
        {
            var handler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(),
                Expires = DateTime.UtcNow.AddMinutes(120),
                SigningCredentials = signingCredentials
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePaswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
