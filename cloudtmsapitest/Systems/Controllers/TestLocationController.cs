using cloud.tms.api.Controllers.Masters.Location;
using cloud.tms.application.Service.Masters.Locations;
using cloudtmsapitest.MockData.Locations;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Moq;

namespace cloudtmsapitest.Systems.Controllers
{
    public class TestLocationController
    {
        [Fact]
        public async Task GetAllLocations_ShouldReturn200Status()
        {
            //Arrange
            var locationservice = new Mock<ILocationService>();
            locationservice.Setup(s => s.GetAllLocationsAsync()).ReturnsAsync(LocationsMockData.GetLocations());
            var sut = new LocationController(locationservice.Object);
            
            //Act
            var result = await sut.GetAllLocations();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAllLocations_ShouldReturnStatus204()
        {
            //Arrange
            var locationservice = new Mock<ILocationService>();
            locationservice.Setup(s => s.GetAllLocationsAsync()).ReturnsAsync(LocationsMockData.EmptyLocations());
            var sut = new LocationController(locationservice.Object);
            
            //Act
            var result = await sut.GetAllLocations();

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
    }
}
