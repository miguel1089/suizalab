using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Suizalab.Citas.Application.External.GetTokenJwt;
using Suizalab.Citas.External.GetTokenJwt;
using System.Text;

namespace Suizalab.Citas.External
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IGetTokenJwtService, GetTokenJwtService>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opction =>
            {
                opction.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey= true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKeyJwt"])),
                    ValidIssuer = configuration["IssuerJwt"],
                    ValidAudience = configuration["AudienceJwt"]
                };
            });
            return services;
        }
    }
}
