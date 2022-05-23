using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepairApi.Factories;
using RepairApi.Infrastructure.Authorization;
using RepairApi.Repository;
using RepairApi.Repository.Entities;
using RepairApi.Repository.Interfaces;
using System;

namespace RepairApi.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }

        public static void ConfigureFactories(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepairRepository, RepairRepository>();
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
