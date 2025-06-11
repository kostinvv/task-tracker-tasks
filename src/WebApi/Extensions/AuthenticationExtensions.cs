using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Extensions;

public static class AuthenticationExtensions
{
    public static IServiceCollection ConfigureAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var authenticationOptions = configuration
                    .GetSection(AuthenticationOptions.Section)
                    .Get<AuthenticationOptions>()!;

                options.Authority = authenticationOptions.Schemes.Bearer.Authority;

                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudiences = authenticationOptions.Schemes.Bearer.Audience
                };
            });

        return services;
    }
}
