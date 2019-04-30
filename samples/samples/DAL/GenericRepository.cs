using System.Threading.Tasks;
using samples.DomainModels;

namespace samples.DAL
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrUpdate(T entity)
        {
            _unitOfWork.AddOrUpdate(entity);
        }

        public async Task AddOrUpdateAsync(T entity)
        {
            await _unitOfWork.AddOrUpdateAsync(entity);
        }

        public void Delete(T entity)
        {
            _unitOfWork.AddOrUpdate(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await _unitOfWork.DeleteAsync(entity);
        }
    }
}
