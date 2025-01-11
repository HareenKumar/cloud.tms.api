
using cloud.tms.domain.Masters.Location;
using Microsoft.EntityFrameworkCore;

namespace cloud.tms.infrastructure.Persistence.PostgreSQL
{
    public class AppPostgreSQLDbContext: DbContext
    {
        public AppPostgreSQLDbContext(DbContextOptions<AppPostgreSQLDbContext> options) : base(options) 
        {

        }

        public DbSet<LocationEntity> locationEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            object value = modelBuilder.Entity<LocationEntity>().ToTable("Locations");
            modelBuilder.Entity<LocationEntity>().HasKey(q => q.Id);
        }

    }
}
