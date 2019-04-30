using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DAL.StepsContexts.StepsContext
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork()
        {
            var localDbConnectionFactory = (LocalDbConnectionFactory)ConfigurationManager.GetSection("entityFramework/defaultConnectionFactory");

            _context = new DbContext(localDbConnectionFactory.BaseConnectionString);    
        }

        public DbContext Context
        {
            get { return _context; }
        }

        public int Save()
        {
            throw new System.NotImplementedException();
        }
    }
}