using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using POCO;

namespace DAL.StepsContexts.StepsContext.EntityTypeConfigurations
{
    [Export(typeof(IEntityConfiguration))]
    internal class CountryConfiguration : EntityTypeConfiguration<Country>, IEntityConfiguration
    {
        public CountryConfiguration()
        {
            Property(c => c.CountryCode).HasMaxLength(10).IsRequired();

            Property(c => c.Name).HasMaxLength(50).IsRequired();

            HasMany(c => c.States).WithRequired(s => s.Country);
        }

        public void AddToConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
