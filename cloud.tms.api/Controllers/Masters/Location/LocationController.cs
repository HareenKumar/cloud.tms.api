﻿using cloud.tms.application.DTO;
using cloud.tms.application.Service.Masters.Locations;
using Microsoft.AspNetCore.Mvc;

namespace cloud.tms.api.Controllers.Masters.Location
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            var result = await _locationService.GetAllLocationsAsync();
            if (result == null || !result.Any())
            {
                return NoContent();
            }
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
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var result = await _locationService.DeleteLocationAsync(id); if(!result) return NotFound();
            return Ok(result);
        }
    }
}
