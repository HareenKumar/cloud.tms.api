using cloud.tms.application.DTO;

namespace cloud.tms.application.Service
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDto>> GetAllLocationsAsync();
        Task<LocationDto> GetLocationByIdAsync(int id);
        Task<int> CreateLocationAsync(LocationDto locationEntity);
        Task<bool> UpdateLocationAsync(int id, LocationDto locationEntity);
        Task<bool> DeleteLocationAsync(int id);
    }
}
