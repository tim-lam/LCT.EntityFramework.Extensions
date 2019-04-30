using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using samples.DomainModels;

namespace samples.DAL.ModelMappings
{
    namespace DAL.StepsContext.EntityTypeConfigurations
    {
        internal class OrderModelConfiguration : EntityTypeConfiguration<Order>
        {
            public OrderModelConfiguration()
            {
                ToTable("Order");

                HasKey(o => o.Id);
            }
        }
    }

}
