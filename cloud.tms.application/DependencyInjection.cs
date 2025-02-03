
using cloud.tms.application.Mappings;
using cloud.tms.domain.Repository;
using cloud.tms.infrastructure.Persistence.PostgreSQL;
using cloud.tms.infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using System.Data;
using System.Reflection;
using System.Text;
namespace cloud.tms.application
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Register JWT Token
            // Add JWT Authentication
            var jwtsettings = configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtsettings.Key);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtsettings["Issuer"],
                    ValidAudience = jwtsettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
            #endregion

            #region Config PostgreSQL Database

            // Retrieve the connection string (ONLY ONE PLACE TO CHANGE)
            var connectionString = configuration.GetConnectionString("localpgsql");

            services.AddDbContext<AppPostgreSQLDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            // Register Dapper Database Connection as Scoped (Reused within the same request)
            services.AddScoped<IDbConnection>(provider => new NpgsqlConnection(connectionString));

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
