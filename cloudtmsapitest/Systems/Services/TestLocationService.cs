
using AutoMapper;
using cloud.tms.application.DTO;
using cloud.tms.application.Service.Masters.Locations;
using cloud.tms.domain.Masters.Location;
using cloud.tms.domain.Repository;
using cloud.tms.infrastructure.Persistence.PostgreSQL;
using cloud.tms.infrastructure.Repository;
using cloudtmsapitest.MockData.Locations;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace cloudtmsapitest.Systems.Services
{
    public class TestLocationService
    {
        private readonly AppPostgreSQLDbContext _appPostgreSQLDbContext;
        private readonly Mock<IMasterRepository<LocationEntity>> _masterRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        public TestLocationService() 
        {
            var options = new DbContextOptionsBuilder<AppPostgreSQLDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            _appPostgreSQLDbContext = new AppPostgreSQLDbContext(options);
            _appPostgreSQLDbContext.Database.EnsureCreated();

            _masterRepositoryMock = new Mock<IMasterRepository<LocationEntity>>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetAllLocationsAsync_ReturnLocationCollection()
        {
            // Arrange
            var locationDtos = new List<LocationDto>
            {
                new LocationDto { /* Initialize LocationDto properties here */ },
                new LocationDto { /* Initialize another LocationDto */ }
            };

            var locationEntities = locationDtos.Select(dto => new LocationEntity
            {
                // Map properties from LocationDto to LocationEntity
            }).ToList();

            // Mock Mapper
            _mapperMock.Setup(m => m.Map<IEnumerable<LocationEntity>>(It.IsAny<IEnumerable<LocationDto>>()))
                .Returns(locationEntities);

            _mapperMock.Setup(m => m.Map<IEnumerable<LocationDto>>(It.IsAny<IEnumerable<LocationEntity>>()))
                .Returns(locationDtos);

            var sut = new LocationService(_masterRepositoryMock.Object, _mapperMock.Object);

            // Act
            var result = await sut.GetAllLocationsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(locationDtos.Count(), result.Count());
        }

    }
}
