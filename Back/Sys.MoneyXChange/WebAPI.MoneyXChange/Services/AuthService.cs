using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.MoneyXChange.Helpers;
using WebAPI.MoneyXChange.Models;
using WebAPI.MoneyXChange.Services.Contracts;

namespace WebAPI.MoneyXChange.Services
{
    public class AuthService : IAuthService
    {
        private StoreDBContext _context;
        private UserAccountService _userAccount;

        public AuthService(StoreDBContext context)
        {
            _context = context;
            _userAccount = new UserAccountService(context);
        }

        public bool ValidateLogin(string user, string pass)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                return false;

            if (_userAccount.Authenticate(user, pass))
                return true;
            
            return false;
        }

        public string GenerateToken(DateTime date, string user, TimeSpan time)
        {
            var expire = date.Add(time);
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(
                    JwtRegisteredClaimNames.Iat,
                    new DateTimeOffset(date).ToUniversalTime().ToUnixTimeSeconds().ToString(),
                    ClaimValueTypes.Integer64
                )
            };

            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(GlobalSettings.SYS_SINGINKEY)),
                SecurityAlgorithms.HmacSha256Signature
            );

            var jwt = new JwtSecurityToken(
                issuer: GlobalSettings.SYS_ISSUER,
                audience: GlobalSettings.SYS_AUDIENCE,
                claims: claims,
                notBefore: date,
                expires: expire,
                signingCredentials:signingCredentials
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
