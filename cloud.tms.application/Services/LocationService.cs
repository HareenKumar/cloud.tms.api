using cloud.tms.application.DTO;
using cloud.tms.domain.Repository;
using cloud.tms.domain.Masters.Location;


namespace cloud.tms.application.Services
{
    public class LocationService
    {
        private readonly IMasterRepository _masterRepository;
        public LocationService(IMasterRepository masterRepository) 
        {
            _masterRepository = masterRepository;
        }

        public async Task<int> CreateLocationAsync(LocationDto locationDto)
        {
            var location = new LocationEntity
            {
                LocationName = locationDto.LocationName,
                ContactName = locationDto.ContactName,
                AddressLine1 = locationDto.AddressLine1,
                AddressLine2 = locationDto.AddressLine2,
                City = locationDto.City,
                State = locationDto.State,
                Country = locationDto.Country,
                Phone = locationDto.Phone,
                PostalCode = locationDto.PostalCode,
                CountryCode = locationDto.CountryCode,
                Email = locationDto.Email,
                Status = locationDto.Status,
                
            };
            return await _masterRepository.CreateLocationAsync(location);
        }

        public async Task<bool> DeleteLocationAsync(int id)
        {
            return await _masterRepository.DeleteLocationAsync(id);
        }

        public async Task<IEnumerable<LocationDto>> GetAllLocationsAsync()
        {
            var locations = await _masterRepository.GetAllLocationsAsync();
            return locations.Select(s => new LocationDto
            {
                Id = s.Id,
                LocationName = s.LocationName,
                ContactName = s.ContactName,
                AddressLine1 = s.AddressLine1,
                AddressLine2 = s.AddressLine2,
                City = s.City,
                State = s.State,
                PostalCode= s.PostalCode,
                Country = s.Country,
                CountryCode= s.CountryCode,
                Email = s.Email,
                Phone = s.Phone,
                Status = s.Status,
                
            });
        }

        public async Task<LocationDto> GetLocationByIdAsync(int id)
        {
            var location = await _masterRepository.GetLocationByIdAsync(id);
            if (location == null) return null;

            return new LocationDto
            {
                Id = location.Id,
                LocationName = location.LocationName,
                ContactName = location.ContactName,
                AddressLine1 = location.AddressLine1,
                AddressLine2 = location.AddressLine2,
                City = location.City,
                State = location.State,
                PostalCode = location.PostalCode,
                Country = location.Country,
                CountryCode = location.CountryCode,
                Email = location.Email,
                Phone = location.Phone,
                Status = location.Status,
            };
        }

        public async Task<bool> UpdateLocationAsync(int id, LocationDto locationDto)
        {
            var location = new LocationEntity
            {
                Id = id,
                LocationName = locationDto.LocationName,
                ContactName= locationDto.ContactName,
                AddressLine1 = locationDto.AddressLine1,
                AddressLine2 = locationDto.AddressLine2,
                City = locationDto.City,
                State = locationDto.State,
                PostalCode = locationDto.PostalCode,
                Country = locationDto.Country,
                CountryCode = locationDto.CountryCode,
                Email = locationDto.Email,
                Phone = locationDto.Phone,
                Status = locationDto.Status
            };
            return await _masterRepository.UpdateLocationAsync(location);
        }
    }
}
