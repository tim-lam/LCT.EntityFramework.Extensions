using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.StepsContext.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Set = _unitOfWork.Set<T>();
        }

        public async Task<T> GetByKeyAsync(params object[] keyValues)
        {
            var entity = await Set.FindAsync(keyValues);

            return entity;
        }

        public async Task AddOrUpdateAsync(T entity)
        {
            await _unitOfWork.AddOrUpdateAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await _unitOfWork.DeleteAsync(entity);
        }

        public void Delete(T entity)
        {
            _unitOfWork.Delete(entity);
        }

        
        public IQueryable<T> Query()
        {
            return Set;
        }

        public T GetByKey(params object[] keyValues)
        {
            var entity = Set.Find(keyValues);
           
            return entity;
        }

        public void AddOrUpdate(T entity)
        {
            _unitOfWork.AddOrUpdate(entity);
        }

       
        private DbSet<T> Set { get; }
    }

    public interface IGenericRepository<T> where T : class
    {
        Task AddOrUpdateAsync(T entity);

        Task<T> GetByKeyAsync(params object[] keyValues);

        Task DeleteAsync(T entity);

        IQueryable<T> Query();

        T GetByKey(params object[] keyValues);
        
        void AddOrUpdate(T entity);

        void Delete(T entity);
    }
}
