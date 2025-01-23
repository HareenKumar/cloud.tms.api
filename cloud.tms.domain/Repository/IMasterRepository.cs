using cloud.tms.domain.Masters.Location;
namespace cloud.tms.domain.Repository
{
    public interface IMasterRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> CreateAsync(T Entity);
        Task<bool> UpdateAsync(int id, T Entity);
        Task<bool> DeleteAsync(int id);
    }

}
