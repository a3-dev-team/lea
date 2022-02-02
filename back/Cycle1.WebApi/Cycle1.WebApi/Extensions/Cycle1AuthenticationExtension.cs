using A3.Library.Mvc.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace A3.Lea.Cycle1.WebApi.Extensions
{
    public static class Cycle1AuthenticationExtension
    {
        public static IServiceCollection AddCycle1Authentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"))
                    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                    {
                        options.RequireHttpsMetadata = true;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidIssuer = configuration["JwtSettings:ValidIssuer"],
                            ValidAudience = configuration["JwtSettings:ValidAudience"],
                            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                        };
                    });

            return services;
        }
    }
}
