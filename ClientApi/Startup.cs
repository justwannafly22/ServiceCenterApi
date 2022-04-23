using ClientApi.Infrastructure.Exceptions;
using ClientApi.Infrastructure.Extensions;
using ClientApi.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace ClientApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddControllers();
            services.UseHealthCheckLogCall(Configuration);

            services.AddDbContext<RepositoryDbContext>(opts =>
                opts.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));

            services.ConfigureFactories();
            services.ConfigureRepository();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandler>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            #region Cors configuring
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller}/{action=Index}/{id?}");
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
