using cloud.tms.application.DTO;
using cloud.tms.application.Services;
using Microsoft.AspNetCore.Mvc;

namespace cloud.tms.api.Controllers.Masters.Location
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;
        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            var result = await _locationService.GetAllLocationsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] LocationDto location)
        {
            var id = await _locationService.CreateLocationAsync(location);
            return CreatedAtAction(nameof(GetLocationById), new { id }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null) { return NotFound(); }
            return Ok(location);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateLocation(int id, [FromBody] LocationDto locationDto)
        {
            var result = await _locationService.UpdateLocationAsync(id, locationDto);
            if(!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var result = await _locationService.DeleteLocationAsync(id); if(!result) return NotFound();
            return NoContent();
        }
    }
}
