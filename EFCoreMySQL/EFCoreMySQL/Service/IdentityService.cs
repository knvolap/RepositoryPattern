﻿using connectMySQL.Interface;
using EFCoreMySQL.DBContexts;
using EFCoreMySQL.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace connectMySQL.Serivce
{
    public class IdentityService : IIdentityService
    {
        private readonly MyDBContext _context;
        private readonly IConfiguration _configuration;
        public IdentityService(MyDBContext context, IConfiguration configuration)
        {
            this._context = context;
            _configuration = configuration;
        }

        public ResponseToken Authentication(LoginModels loginModels)
        {
            var user1 = _context.Users.Where(a => a.Account == loginModels.username && a.Password == loginModels.password)
                .FirstOrDefault<User>();
            if (user1 != null)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user1.Account),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                authClaims.Add(new Claim(ClaimTypes.Role, user1.Role));

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                var tokenResult = new ResponseToken
                {
                    Message = "Login successful",
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
                return tokenResult;
            }
            return new ResponseToken { Message = "Username or password incorrect" };
        }

    
    }
}
