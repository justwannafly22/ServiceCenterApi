using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace RepairApi.Infrastructure.Extensions
{
    public static class HealthCheckExtension
    {
        public static void UseHealthCheckLogCall(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                    .AddCheck("Database sql check", sql =>
                    {
                        var connectionString = configuration.GetConnectionString("sqlConnection");
                        using var connection = new SqlConnection(connectionString);
                        try
                        {
                            connection.Open();
                            return HealthCheckResult.Healthy();
                        }
                        catch (SqlException)
                        {
                            return HealthCheckResult.Unhealthy();
                        }
                    });
        }
    }
}
