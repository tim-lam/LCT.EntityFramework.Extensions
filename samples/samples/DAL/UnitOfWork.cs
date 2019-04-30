using System;
using System.Threading.Tasks;
using System.Configuration;
using LCT.EntityFramework.Extensions;

namespace samples.DAL
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly OrderDbContext _context;

        public UnitOfWork()
        {
            _context = new OrderDbContext(ConfigurationManager.ConnectionStrings["OrderDbContext"].ConnectionString);
        }

        public async Task AddOrUpdateAsync(object entity)
        {
            await _context.AddOrUpdateAsync(entity);
        }

        public void AddOrUpdate(object entity)
        {
            _context.AddOrUpdate(entity);
        }

        public async Task DeleteAsync(object entity)
        {
            await _context.DeleteAsync(entity);
        }


        public void Delete(object entity)
        {
            _context.Delete(entity);
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
        void AddOrUpdate(object entity);

        void Delete(object entity);

        int Save();

        Task AddOrUpdateAsync(object entity);

        Task DeleteAsync(object entity);

        Task<int> SaveAsync();
    }
}
