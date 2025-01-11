using cloud.tms.infrastructure.Persistence.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace cloud.tms.infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Scan(scan => scan.FromAssemblies(Assembly.Load("cloud.tms.application"))
            //.AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository"))).AsImplementedInterfaces().WithScopedLifetime());

            #region Config PostgreSQL Database
            services.AddDbContext<AppPostgreSQLDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("localpgsql");
                options.UseNpgsql(connectionString);
            });

            #endregion
        }
    }
}
