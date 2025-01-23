
using cloud.tms.domain.Common;
using Microsoft.EntityFrameworkCore;
namespace cloud.tms.infrastructure.Persistence.PostgreSQL
{
    public class AppPostgreSQLDbContext: DbContext
    {
        public AppPostgreSQLDbContext(DbContextOptions<AppPostgreSQLDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dynamically find and configure all entities implementing IBaseEntity
            var entityTypes = typeof(BaseEntity).Assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && typeof(BaseEntity).IsAssignableFrom(type));

            foreach (var entityType in entityTypes)
            {
                // Extract a cleaner table name by removing "Entity" suffix and pluralizing
                var tableName = entityType.Name.EndsWith("Entity")
                    ? entityType.Name.Replace("Entity", "") + "s" // Replace "Entity" and pluralize
                    : entityType.Name + "s";

                // Configure the entity's table name and primary key
                modelBuilder.Entity(entityType).ToTable(tableName); // Use the modified table name
                modelBuilder.Entity(entityType).HasKey("Id");       // Assumes each entity has an "Id" property
            }

            // Apply additional configurations from the assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppPostgreSQLDbContext).Assembly);
        }

        // Generic access to DbSet<T>
        public DbSet<T> GetDbSet<T>() where T : class
        {
            return Set<T>();
        }
    }
}
