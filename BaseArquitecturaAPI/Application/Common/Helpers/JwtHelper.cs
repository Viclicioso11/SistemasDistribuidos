using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;

namespace Application.Common.Helpers
{
    public class JwtHelper
    {
        IConfiguration _conf;
        public JwtHelper(IConfiguration configuration)
        {
            _conf = configuration;
        }

        public string GenerateJwtToken(User user, List<Option> options, Rol rol) 
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_conf.GetValue<string>("auth:token"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[] {
                        new Claim("id", user.Id.ToString()),
                        new Claim("names", user.Names),
                        new Claim("last_name", user.LastNames),
                        new Claim("identification", user.Identification),
                        new Claim("email", user.Email),
                        new Claim("rol", rol.RolName) }),
                Expires = DateTime.UtcNow.AddHours(1),
                //Claims = { { "options", options } },
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
