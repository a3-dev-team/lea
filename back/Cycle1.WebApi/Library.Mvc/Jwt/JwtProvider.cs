using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace A3.Library.Mvc.Jwt
{
    public static class JwtProvider
    {
        public static string ProvideToken(IEnumerable<Claim> claims, JwtSettings jwtSettings)
        {
            byte[] key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.Key);
            DateTime expireTime = DateTime.UtcNow.AddDays(1);

            var JWToken = new JwtSecurityToken(claims: claims,
                                               expires: new DateTimeOffset(expireTime).DateTime,
                                               audience: jwtSettings.ValidAudience,
                                               issuer: jwtSettings.ValidIssuer,
                                               signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));
            return new JwtSecurityTokenHandler().WriteToken(JWToken);
        }
    }
}
