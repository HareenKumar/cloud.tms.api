using cloud.tms.domain.Masters.Location;
namespace cloud.tms.domain.Repository
{
    public interface IMasterRepository
    {
        Task<IEnumerable<LocationEntity>> GetAllLocationsAsync();
        Task<LocationEntity> GetLocationByIdAsync(int id);
        Task<int> CreateLocationAsync(LocationEntity locationEntity);
        Task<bool> UpdateLocationAsync(LocationEntity locationEntity);
        Task<bool> DeleteLocationAsync(int id);
    }
}
