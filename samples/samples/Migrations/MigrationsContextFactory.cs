using System.Configuration;
using System.Data.Entity.Infrastructure;
using samples.DAL;

namespace samples.Migrations
{
    public class MigrationsContextFactory : IDbContextFactory<OrderDbContext>
    {
        public OrderDbContext Create()
        {
            return new OrderDbContext(ConfigurationManager.ConnectionStrings["OrderDbContext"].ConnectionString);
        }
    }
}
