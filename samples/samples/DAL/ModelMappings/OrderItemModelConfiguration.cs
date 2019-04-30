using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using samples.DomainModels;

namespace samples.DAL.ModelMappings
{
    namespace DAL.StepsContext.EntityTypeConfigurations
    {
        internal class OrderItemModelConfiguration : EntityTypeConfiguration<OrderItem>
        {
            public OrderItemModelConfiguration()
            {
                ToTable("OrderItem");

                HasKey(oi => oi.Id);

                HasRequired(oi => oi.Order).WithMany(o => o.OrderItems);
            }
        }
    }

}
