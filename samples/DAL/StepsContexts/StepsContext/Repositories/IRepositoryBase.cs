namespace DAL.StepsContexts.StepsContext.Repositories
{
    interface IRepositoryBase<T>
    {
        void Insert(T entity);

        void Update(T entity);

        void DeleteById(object[] keys);

        void Delete(T entity);
    }
}