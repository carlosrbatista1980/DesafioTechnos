using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using IConfiguration = AutoMapper.Configuration.IConfiguration;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace EntityFrameworkCore.Services
{
    public static class AuthenticationService
    {
        static IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

        public static string BuildToken(string user)
        {
            string signingKey = configuration["Jwt:SigningKey"];
            var expiration = DateTime.Now.AddMinutes(Convert.ToInt32(configuration["Jwt:Expiration"]));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user),
                new Claim(user, signingKey),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var credencial = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: credencial);

            var ret = new JwtSecurityTokenHandler().WriteToken(token);
            return ret;
        }
    }
}
