using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReplacedPartApi.Repository;
using ReplacedPartApi.Repository.Entities;
using ReplacedPartApi.Repository.Interfaces;

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
    }
}
