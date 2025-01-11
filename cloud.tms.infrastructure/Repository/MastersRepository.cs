using cloud.tms.domain.Repository;
using cloud.tms.domain.Masters.Location;
using cloud.tms.infrastructure.Persistence.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace cloud.tms.infrastructure.Repository
{
    public class MastersRepository : IMasterRepository
    {
        private readonly AppPostgreSQLDbContext _appPostgreSQLDbContext;

        public MastersRepository(AppPostgreSQLDbContext appPostgreSQLDbContext)
        {
            _appPostgreSQLDbContext = appPostgreSQLDbContext;
        }
        public async Task<int> CreateLocationAsync(LocationEntity locationEntity)
        {
            _appPostgreSQLDbContext.Add(locationEntity);
            await _appPostgreSQLDbContext.SaveChangesAsync();
            return locationEntity.Id;
        }

        public async Task<bool> DeleteLocationAsync(int id)
        {
            var location = await _appPostgreSQLDbContext.locationEntities.FindAsync(id);
            if (location == null) { return false; }

            _appPostgreSQLDbContext.locationEntities.Remove(location);
            _appPostgreSQLDbContext.SaveChangesAsync() ; return true;   
        }

        public async Task<IEnumerable<LocationEntity>> GetAllLocationsAsync()
        {
            return await _appPostgreSQLDbContext.locationEntities.ToListAsync();
        }

        public async Task<LocationEntity> GetLocationByIdAsync(int id)
        {
            return await _appPostgreSQLDbContext.locationEntities.FindAsync(id);
        }

        public async Task<bool> UpdateLocationAsync(LocationEntity locationEntity)
        {
            var existinglocation = await _appPostgreSQLDbContext.locationEntities.FindAsync(locationEntity.Id);
            if (existinglocation == null) { return false; }

            existinglocation.LocationName = locationEntity.LocationName;
            existinglocation.ContactName = locationEntity.ContactName;
            existinglocation.AddressLine1 = locationEntity.AddressLine1;
            existinglocation.AddressLine2 = locationEntity.AddressLine2;
            existinglocation.City = locationEntity.City;
            existinglocation.State = locationEntity.State;
            existinglocation.Country = locationEntity.Country;
            existinglocation.Phone = locationEntity.Phone;
            existinglocation.Email = locationEntity.Email;

            await _appPostgreSQLDbContext.SaveChangesAsync();
            return true;
        }
    }
}
