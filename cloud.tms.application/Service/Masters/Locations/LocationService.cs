using cloud.tms.application.DTO;
using cloud.tms.domain.Repository;
using cloud.tms.domain.Masters.Location;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace cloud.tms.application.Service.Masters.Locations
{
    public class LocationService : ILocationService
    {
        private readonly IMasterRepository<LocationEntity> _masterRepository;
        private readonly IMapper _mapper;
        public LocationService(IMasterRepository<LocationEntity> masterRepository, IMapper mapper)
        {
            _masterRepository = masterRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateLocationAsync(LocationDto locationDto)
        {
            var entity = _mapper.Map<LocationEntity>(locationDto);
            return await _masterRepository.CreateAsync(entity);
            //var location = new LocationEntity
            //{
            //    LocationName = locationDto.LocationName,
            //    ContactName = locationDto.ContactName,
            //    AddressLine1 = locationDto.AddressLine1,
            //    AddressLine2 = locationDto.AddressLine2,
            //    City = locationDto.City,
            //    State = locationDto.State,
            //    Country = locationDto.Country,
            //    Phone = locationDto.Phone,
            //    PostalCode = locationDto.PostalCode,
            //    CountryCode = locationDto.CountryCode,
            //    Email = locationDto.Email,
            //    Status = locationDto.Status,

            //};
            //return await _masterRepository.CreateAsync(location);
        }

        public async Task<bool> DeleteLocationAsync(int id)
        {
            return await _masterRepository.DeleteAsync(id);
        }

        public virtual async Task<IEnumerable<LocationDto>> GetAllLocationsAsync()
        {
            //var locations = await _masterRepository.GetAllAsync();
            //return locations.Select(s => new LocationDto
            //{
            //    Id = s.Id,
            //    LocationName = s.LocationName,
            //    ContactName = s.ContactName,
            //    AddressLine1 = s.AddressLine1,
            //    AddressLine2 = s.AddressLine2,
            //    City = s.City,
            //    State = s.State,
            //    PostalCode= s.PostalCode,
            //    Country = s.Country,
            //    CountryCode= s.CountryCode,
            //    Email = s.Email,
            //    Phone = s.Phone,
            //    Status = s.Status,

            //});
            var entities = await _masterRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LocationDto>>(entities);
        }

        public async Task<LocationDto> GetLocationByIdAsync(int id)
        {
            //var location = await _masterRepository.GetByIdAsync(id);
            //if (location == null) return null;

            //return new LocationDto
            //{
            //    Id = location.Id,
            //    LocationName = location.LocationName,
            //    ContactName = location.ContactName,
            //    AddressLine1 = location.AddressLine1,
            //    AddressLine2 = location.AddressLine2,
            //    City = location.City,
            //    State = location.State,
            //    PostalCode = location.PostalCode,
            //    Country = location.Country,
            //    CountryCode = location.CountryCode,
            //    Email = location.Email,
            //    Phone = location.Phone,
            //    Status = location.Status,
            //};

            var entity = await _masterRepository.GetByIdAsync(id);
            return _mapper.Map<LocationDto>(entity);
        }

        public async Task<bool> UpdateLocationAsync(int id, LocationDto locationDto)
        {
            //var location = new LocationEntity
            //{
            //    Id = id,
            //    LocationName = locationDto.LocationName,
            //    ContactName= locationDto.ContactName,
            //    AddressLine1 = locationDto.AddressLine1,
            //    AddressLine2 = locationDto.AddressLine2,
            //    City = locationDto.City,
            //    State = locationDto.State,
            //    PostalCode = locationDto.PostalCode,
            //    Country = locationDto.Country,
            //    CountryCode = locationDto.CountryCode,
            //    Email = locationDto.Email,
            //    Phone = locationDto.Phone,
            //    Status = locationDto.Status
            //};
            //return await _masterRepository.UpdateAsync(id, location);

            var entity = _mapper.Map<LocationEntity>(locationDto);
            return await _masterRepository.UpdateAsync(id, entity);
        }
    }
}
