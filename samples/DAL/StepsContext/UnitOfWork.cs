using System;
using System.Configuration;
using System.Data.Entity;
using System.Threading.Tasks;
using LCT.EntityFramework.Extensions;

namespace DAL.StepsContext
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StepsContext _context;

        public UnitOfWork()
        {
            _context = new StepsContext(ConfigurationManager.ConnectionStrings["StepsContext"].ConnectionString);
        }

        public DbSet<T> Set<T>() where T : class
        {
            return _context.Set<T>();
        }

        //public T ByKey<T>(params object[] keyValues) where T : class
        //{
        //    return _context.Set<T>().Find(keyValues);
        //}

        //public IQueryable<T> Where<T>(Expression<Func<T,bool>> predicate) where  T: class
        //{
        //   return _context.Set<T>().Where(predicate);
        //}

        
        public void AddOrUpdate(object entity)
        {
           _context.AddOrUpdate(entity);
        }

        public void Delete(object entity)
        {
            _context.Delete(entity);
        }

        public async Task AddOrUpdateAsync(object entity)
        {
            await _context.AddOrUpdateAsync(entity);
        }

        public async Task DeleteAsync(object entity)
        {
            await _context.DeleteAsync(entity);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }

    public interface IUnitOfWork
    {
        DbSet<T> Set<T>() where T : class;

        void AddOrUpdate(object entity);

        void Delete(object entity);

        int Save();

        Task AddOrUpdateAsync(object entity);

        Task DeleteAsync(object entity);

        Task<int> SaveAsync();
    }
}