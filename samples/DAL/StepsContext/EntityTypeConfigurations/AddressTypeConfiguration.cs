using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using POCO;

namespace DAL.StepsContext.EntityTypeConfigurations
{
    [Export(typeof(IEntityConfiguration))]
    internal class AddressTypeConfiguration : EntityTypeConfiguration<Address>, IEntityConfiguration
    {
        public AddressTypeConfiguration()
        {
            ToTable("Address");
            
            Property(a => a.Line1).IsRequired().HasMaxLength(100);

            HasRequired(a => a.PostalCode).WithMany(pc => pc.Addresses);
        }
        
        public void AddToConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
