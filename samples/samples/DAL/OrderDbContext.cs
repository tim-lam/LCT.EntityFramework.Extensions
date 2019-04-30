using System.Data.Entity;
using samples.DAL.ModelMappings.DAL.StepsContext.EntityTypeConfigurations;
using samples.DomainModels;

namespace samples.DAL
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        
        public OrderDbContext(string connectionString) : base(connectionString){}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {  
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new OrderModelConfiguration());

            modelBuilder.Configurations.Add(new OrderItemModelConfiguration());
        }
    }
}
