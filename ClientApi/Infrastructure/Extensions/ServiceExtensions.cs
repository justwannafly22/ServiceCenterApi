using ClientApi.Factories;
using ClientApi.Repository;
using ClientApi.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        }
        
        public static void ConfigureJWT(this IServiceCollection services)
        {
            Environment.SetEnvironmentVariable("SECRET", "ServiceCenterApi");
            var secretKey = Environment.GetEnvironmentVariable("SECRET");

            services
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });
        }
    }
}
