using System.Data.Entity;

namespace DAL.StepsContexts.StepsContext.Repositories
{
    internal class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        internal RepositoryBase(IUnitOfWork unitOfWork)
        {
            Set = _unitOfWork.Context.Set<T>();
            _unitOfWork = unitOfWork ?? new UnitOfWork();
        }

        public DbSet<T> Set { get; private set; }

        public void Insert(T entity)
        {
            Set.Add(entity);
        }

        public void Update(T entity)
        {
            Set.Attach(entity);
        }
        
        public void DeleteById(object[] keys)
        {
            var foundEntity = Set.Find(keys);
            Set.Remove(foundEntity);
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
        }
    }
}
