using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Domain.Repositories;
using MillionAndUp.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Domain.UnitsOfWork
{

    public class SecurityUnitOfWork : ISecurityUnitOfWork
    {
        readonly IUserRepository _repo;
        readonly IConfiguration _configuration;
        public SecurityUnitOfWork(IUserRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }
        public async Task<string> GetToken(UserPayload user)
        {
            var users = await _repo.GetUserByLoginAndPassword(user.Login, Encrypt(user.Password));
            if (!users.Any())
            {
                throw new ApplicationException("User not found");
            }
            return BuildToken(users.FirstOrDefault());
        }

        private string BuildToken(User user)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserLogin", user.Login),
                        new Claim("DisplayName", $"{user.Name}"),
                        new Claim("Email", user.Email)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(2),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private string Encrypt(string data)
        {
            var key = _configuration["Salt"];
            byte[] initializationVector = Encoding.ASCII.GetBytes("abcede0123456789");
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = initializationVector;
                var symmetricEncryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream as Stream, symmetricEncryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream as Stream))
                        {
                            streamWriter.Write(data);
                        }
                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
        }
    }
}
