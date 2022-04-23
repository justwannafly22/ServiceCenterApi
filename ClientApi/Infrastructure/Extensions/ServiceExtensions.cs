using ClientApi.Factories;
using ClientApi.Repository;
using ClientApi.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
