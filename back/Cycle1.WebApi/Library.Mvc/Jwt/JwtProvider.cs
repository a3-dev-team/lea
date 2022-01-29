using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace A3.Library.Mvc.Jwt
{
    public static class JwtProvider
    {
        //public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid Id)
        //{
        //    IEnumerable<Claim> claims = new Claim[] {
        //        new Claim("Id", userAccounts.Id.ToString()),
        //            new Claim(ClaimTypes.Name, userAccounts.UserName),
        //            new Claim(ClaimTypes.Email, userAccounts.EmailId),
        //            new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
        //            new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
        //    };
        //    return claims;
        //}

        //public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        //{
        //    Id = Guid.NewGuid();
        //    return GetClaims(userAccounts, Id);
        //}

        public static string Provide(IEnumerable<Claim> claims, JwtSettings jwtSettings)
        {
            byte[] key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
            DateTime expireTime = DateTime.UtcNow.AddDays(1);

            var JWToken = new JwtSecurityToken(issuer: jwtSettings.ValidIssuer,
                                               audience: jwtSettings.ValidAudience,
                                               claims: claims,
                                               notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                                               expires: new DateTimeOffset(expireTime).DateTime,
                                               signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(JWToken);
        }
    }
}
