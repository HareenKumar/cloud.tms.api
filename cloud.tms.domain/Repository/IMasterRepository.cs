using cloud.tms.domain.Masters.Location;
using System.Linq.Expressions;
namespace cloud.tms.domain.Repository
{
    public interface IMasterRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> CreateAsync(T Entity);
        Task<bool> UpdateAsync(int id, T Entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }

}
