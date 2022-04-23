using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepairApi.Factories;
using RepairApi.Repository;
using RepairApi.Repository.Entities;
using RepairApi.Repository.Interfaces;

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
    }
}
