using cloud.tms.domain.Repository;
using cloud.tms.domain.Masters.Location;
using cloud.tms.infrastructure.Persistence.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using cloud.tms.domain.Common;
using System.Linq.Expressions;

namespace cloud.tms.infrastructure.Repository
{
    public class MastersRepository<T> : IMasterRepository<T> where T : BaseEntity
    {
        private readonly AppPostgreSQLDbContext _appPostgreSQLDbContext;


        public MastersRepository(AppPostgreSQLDbContext appPostgreSQLDbContext)
        {
            _appPostgreSQLDbContext = appPostgreSQLDbContext;
        }

        public async Task<int> CreateAsync(T Entity)
        {
            //_appPostgreSQLDbContext.Add(Entity);
            //await _appPostgreSQLDbContext.SaveChangesAsync();
            //return Entity.Id;

            _appPostgreSQLDbContext.GetDbSet<T>().Add(Entity);
            await _appPostgreSQLDbContext.SaveChangesAsync();
            return Entity.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            //var location = await _appPostgreSQLDbContext.FindAsync(id);
            //if (location == null) { return false; }

            //_appPostgreSQLDbContext.Remove(location);
            //_appPostgreSQLDbContext.SaveChangesAsync(); return true;


            var entity = await _appPostgreSQLDbContext.GetDbSet<T>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _appPostgreSQLDbContext.GetDbSet<T>().Remove(entity);
            await _appPostgreSQLDbContext.SaveChangesAsync();
            return true;
        }

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    return await _appPostgreSQLDbContext.GetDbSet<T>().ToListAsync();
        //}

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _appPostgreSQLDbContext.GetDbSet<T>().ToListAsync();
            
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _appPostgreSQLDbContext.GetDbSet<T>().FindAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, T Entity)
        {
            //var existinglocation = await _appPostgreSQLDbContext.GetDbSet<T>().FindAsync(id);
            //if (existinglocation == null) { return false; }

            //existinglocation.LocationName = locationEntity.LocationName;
            //existinglocation.ContactName = locationEntity.ContactName;
            //existinglocation.AddressLine1 = locationEntity.AddressLine1;
            //existinglocation.AddressLine2 = locationEntity.AddressLine2;
            //existinglocation.City = locationEntity.City;
            //existinglocation.State = locationEntity.State;
            //existinglocation.Country = locationEntity.Country;
            //existinglocation.Phone = locationEntity.Phone;
            //existinglocation.Email = locationEntity.Email;
            _appPostgreSQLDbContext.Update(Entity);

            await _appPostgreSQLDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _appPostgreSQLDbContext.GetDbSet<T>().AnyAsync(predicate);
        }


    }
}
