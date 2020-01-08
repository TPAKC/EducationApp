using EducationApp.BusinessLogicalLayer.Common;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public class JwtHelper
    {
        private readonly JwtOptions _jwtOptions;

        private readonly IOptions<AppSettings> _appSettings;

        public JwtHelper(IOptions<JwtOptions> jwtOptions,
            IOptions<AppSettings> appSettings)
        {
            _jwtOptions = jwtOptions.Value;
            _appSettings = appSettings;
        }

       /* public async Task<string> GenerateEncodedToken(ApplicationUser user, string userRole)
        {
            var identity = GenerateClaimsIdentity(user, userRole);
            var claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                 new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                 new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64)
             };
            claims.AddRange(identity.Claims);

            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: _jwtOptions.NotBefore,
                expires: _jwtOptions.Expiration);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }*/

       /* private ClaimsIdentity GenerateClaimsIdentity(ApplicationUser user, string role)
        {
            return new ClaimsIdentity(new GenericIdentity(user.UserName, "Token"), new[]
                {
                    new Claim("id", user.Id),
                    new Claim("role", role),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.Surname, user.LastName)
                });
        }*/

        private long ToUnixEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        }
    }
}
