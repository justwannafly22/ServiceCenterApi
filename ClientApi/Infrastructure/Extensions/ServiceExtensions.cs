using ClientApi.Factories;
using ClientApi.Infrastructure.Authorization;
using Database;
using Database.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ClientApi.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureFactories(this IServiceCollection services)
        {
            services.AddScoped<IDomainFactory, DomainFactory>();
            services.AddScoped<IClientRepositoryFactory, ClientRepositoryFactory>();
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
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
