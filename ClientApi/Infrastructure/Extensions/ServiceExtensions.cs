using ClientApi.Factories;
using ClientApi.Infrastructure.Authorization;
using ClientApi.Repository;
using ClientApi.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace ClientApi.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureFactories(this IServiceCollection services)
        {
            services.AddScoped<IDomainFactory, DomainFactory>();
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddSingleton<IAuthorizationHandler, TokenAuthorizationHandler>();
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
        }
    }
}
