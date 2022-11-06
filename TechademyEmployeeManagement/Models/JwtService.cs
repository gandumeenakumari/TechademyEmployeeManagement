using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TechademyEmployeeManagement.Models
{
    public class JwtService
    {
        public string Secretkey { get; set; }
        public int TokenDuration { get; set; }
        private readonly IConfiguration config;
        public JwtService(IConfiguration _config)
        {
            config = _config;
            this.Secretkey = config.GetSection("jwtConfig").GetSection("Key").Value;
            this.TokenDuration = Int32.Parse(config.GetSection("jwtConfig").GetSection("Duration").Value);

        }
        public string GenerateToken(string employeeID, string firstname, string lastname, string email, string mobile, string gender)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Secretkey));
            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var payload = new[]
            {
                new Claim("employeeID",employeeID),
                new Claim("firstname",firstname),
                new Claim("lastnam",lastname),
                new Claim("email",email),
                new Claim("mobile",mobile),
                new Claim("gender",gender)

            };
            var jwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: payload,
                expires: DateTime.Now.AddMinutes(TokenDuration),
                signingCredentials: signature

                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
