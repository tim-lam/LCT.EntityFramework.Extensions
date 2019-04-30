using System.Threading.Tasks;

namespace samples.DomainModels
{
    public interface IRepository<in T> where T : class
    {
        void AddOrUpdate(T entity);
        Task AddOrUpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
    }
}
