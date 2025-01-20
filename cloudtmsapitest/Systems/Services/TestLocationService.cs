
using cloud.tms.domain.Repository;
using cloud.tms.infrastructure.Persistence.PostgreSQL;
using cloudtmsapitest.MockData.Locations;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace cloudtmsapitest.Systems.Services
{
    public class TestLocationService
    {
        private readonly AppPostgreSQLDbContext _appPostgreSQLDbContext;
        public TestLocationService() 
        {
            var options = new DbContextOptionsBuilder<AppPostgreSQLDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            _appPostgreSQLDbContext = new AppPostgreSQLDbContext(options);
            _appPostgreSQLDbContext.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAllLocationsAsync_ReturnLocationCollection()
        {
            //Arrange
           // var locations = new Mock<IMasterRepository>();
           // locations.Setup(s => s.GetAllLocationsAsync()).ReturnsAsync(LocationsMockData.GetLocations());
            //Act

            //Assert
        }
        
    }
}
