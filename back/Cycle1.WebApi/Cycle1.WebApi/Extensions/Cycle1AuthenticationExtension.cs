using A3.Library.Mvc.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace A3.Lea.Cycle1.WebApi.Extensions
{
    public static class Cycle1AuthenticationExtension
    {
        public static IServiceCollection AddCycle1Authentication(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSettings jwtSettings = new JwtSettings();
            configuration.Bind("JwtSettings", jwtSettings);

            services.AddSingleton(jwtSettings)
                    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.IssuerSigningKey)),
                            ValidateIssuer = jwtSettings.ValidateIssuer,
                            ValidIssuer = jwtSettings.ValidIssuer,
                            ValidateAudience = jwtSettings.ValidateAudience,
                            ValidAudience = jwtSettings.ValidAudience,
                            RequireExpirationTime = jwtSettings.RequireExpirationTime,
                            ValidateLifetime = jwtSettings.RequireExpirationTime,
                            ClockSkew = TimeSpan.FromDays(1)
                        };
                    })
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

            return services;
        }
    }
}
