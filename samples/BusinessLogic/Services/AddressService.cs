using DAL.StepsContext;
using DAL.StepsContext.Repositories;

namespace BusinessLogic.Services
{
    public class ServiceBase<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _genericRepository;

        public ServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = new GenericRepository<T>(_unitOfWork);
        }


        public void AddOrUpdate(T entity)
        {
            _genericRepository.AddOrUpdate(entity);
        }
    }
}
