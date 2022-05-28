using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReplacedPartApi.Infrastructure.Authorization;
using System;

namespace ReplacedPartApi.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IReplacedPartRepository, ReplacedPartRepository>();
        }

        public static void ConfigureJWT(this IServiceCollection services)
        {
            Environment.SetEnvironmentVariable("SECRET", "ServiceCenterApi");
            var secretKey = Environment.GetEnvironmentVariable("SECRET");

            services.AddAuthentication(TokenAuthenticationHandler.AuthenticationScheme)
                .AddScheme<TokenKeyOptions, TokenAuthenticationHandler>(TokenAuthenticationHandler.AuthenticationScheme, _ => { });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("default", policy =>
                {
                    policy.AddAuthenticationSchemes(TokenAuthenticationHandler.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                });

                opt.AddPolicy(TokenAuthorizationHandler.Policy, policy =>
                {
                    policy.AddAuthenticationSchemes(TokenAuthenticationHandler.AuthenticationScheme);
                    policy.Requirements.Add(new TokenRequirement());
                });
            });

            services.AddSingleton<IAuthorizationHandler, TokenAuthorizationHandler>();
        }
    }
}
