using System.Collections;
using System.Data.Entity.Infrastructure;

namespace DAL.StepsContext.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? new UnitOfWork();
        }

        public virtual int AddOrUpdate(object entity)
        {
            var recordsAffected = 0;

            if (entity == null || _unitOfWork.Context.IsAttached(entity))
            {
                return recordsAffected;
            }

            _unitOfWork.Context.AddOrAttach(entity);

            recordsAffected++;

            foreach(var dbMemberEntry in  _unitOfWork.Context.NavigationMemberEntries(entity))
            {
                if (dbMemberEntry.CurrentValue == null)
                {
                    continue;
                }

                switch (dbMemberEntry)
                {
                    case DbReferenceEntry _:
                    {
                        var model = dbMemberEntry.CurrentValue;

                        if (_unitOfWork.Context.IsAttached(model)) continue;

                        ////determine to use an existing repository of this entity.
                        ////currently use only naming conversion for finding out specific repository.
                        ////todo: use the entity type to find a repository.
                        //var type = Type.GetType($"{GetType().Namespace}.{model.GetType().Name}Repository");
                        //if (type != null)
                        //{
                        //    ((IBaseRepository) Activator.CreateInstance(type, _unitOfWork)).AddOrUpdate(model);
                        //}
                        //else
                        //{
                          
                        //}

                        recordsAffected += AddOrUpdate(dbMemberEntry.CurrentValue);
                        break;
                    }
                    case DbCollectionEntry _:
                    {
                        var entities = (IEnumerable) dbMemberEntry.CurrentValue;

                        if (entities == null) continue;

                        foreach (var entityItem in entities)
                        {
                            if (!_unitOfWork.Context.IsAttached(entityItem))
                            {
                                recordsAffected += AddOrUpdate(entityItem);
                            }
                        }
                        break;
                    }
                }
            }

            return recordsAffected;
        }
    }

    #region obsoleted codes
    //public void Update(T entity)
    //{
    //    _dbSet.Attach(entity);
    //}
        
    //public void DeleteById(object[] keys)
    //{
    //    var foundEntity = _dbSet.Find(keys);
    //    _dbSet.Remove(foundEntity);
    //}

    //public void Delete(T entity)
    //{
    //    _dbSet.Remove(entity);
    //}

    //public IQueryable<T> Queryable
    //{
    //    get { return _dbSet; }
    //}
    #endregion

    public interface IBaseRepository
    {
       int AddOrUpdate(object entity);
    }
    //public interface IBaseRepository<T>
    //{
    //    T ByIds(object[] keys);

    //    void Insert(T entity);

    //    void Update(T entity);

    //    void DeleteById(object[] keys);

    //    void Delete(T entity);

    //    IQueryable<T> Queryable { get; }
    //}
}
