
using cloud.tms.application.Mappings;
using cloud.tms.domain.Repository;
using cloud.tms.infrastructure.Persistence.PostgreSQL;
using cloud.tms.infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace cloud.tms.application
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Config PostgreSQL Database
            services.AddDbContext<AppPostgreSQLDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("localpgsql");
                options.UseNpgsql(connectionString);
            });
            services.AddScoped(typeof(IMasterRepository<>), typeof(MastersRepository<>));
            services.Scan(scan =>
                     scan.FromAssemblies(Assembly.Load("cloud.tms.application"))
                         .AddClasses(e => e.Where(e => e.Name.EndsWith("Service")))
                         .AsImplementedInterfaces().WithScopedLifetime());

            // Dynamically Register AutoMapper Mappings
            var applicationAssembly = Assembly.GetExecutingAssembly(); // Automatically detects the current assembly
            services.AddAutoMapper(cfg =>
            {
                var types = applicationAssembly.GetExportedTypes()
                    .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces()
                        .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)));

                foreach (var type in types)
                {
                    var instance = Activator.CreateInstance(type);
                    var method = type.GetMethod("Mapping");
                    method?.Invoke(instance, new object[] { cfg });
                }
            });
            #endregion
        }

    }
}
