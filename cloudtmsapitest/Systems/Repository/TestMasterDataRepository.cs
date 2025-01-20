using cloud.tms.infrastructure.Persistence.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudtmsapitest.Systems.Repository
{
    public class TestMasterDataRepository : IDisposable
    {
        private readonly AppPostgreSQLDbContext _appPostgreSQLDbContext;
        public TestMasterDataRepository() 
        {
            var options = new DbContextOptionsBuilder<AppPostgreSQLDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            _appPostgreSQLDbContext = new AppPostgreSQLDbContext(options);
            _appPostgreSQLDbContext.Database.EnsureCreated();
        }
        public void Dispose()
        {
            _appPostgreSQLDbContext.Database.EnsureDeleted();
            _appPostgreSQLDbContext.Dispose();
        }
    }
}
