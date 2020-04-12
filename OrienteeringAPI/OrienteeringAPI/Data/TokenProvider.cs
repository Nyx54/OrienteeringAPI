using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrienteeringAPI.Data.Base;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrienteeringAPI.Data
{
    public class TokenProvider : ITokenProvider
    {
        private const string _Secret = "Secret";
        private const string _Issuer = "Issuer";
        private const string _Audience = "Audience";

        private IConfiguration _configuration { get; }

        public TokenProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(string userName)
        {
            var appSettingsSection = _configuration.GetSection("AppSettings");
            var keyByteArray = Encoding.ASCII.GetBytes(appSettingsSection.GetValue<string>(_Secret));
            var signinKey = new SymmetricSecurityKey(keyByteArray);
            var myIssuer = appSettingsSection.GetValue<string>(_Issuer);
            var myAudience = appSettingsSection.GetValue<string>(_Audience);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, userName.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = myIssuer,
                Audience = myAudience,
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
