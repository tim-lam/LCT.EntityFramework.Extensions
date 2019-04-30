using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using POCO;

namespace DAL.StepsContext.EntityTypeConfigurations
{
    [Export(typeof(IEntityConfiguration))]
    internal class StateConfiguration : EntityTypeConfiguration<State>, IEntityConfiguration
    {
        public StateConfiguration()
        {
            ToTable("State");
            HasKey(s => new {s.Id, s.StateCode});

            Property(s => s.StateCode).HasMaxLength(2).IsRequired();

            Property(s => s.Name).HasMaxLength(50).IsRequired();

            HasRequired(s => s.Country).WithMany(c => c.States);

            HasMany(s => s.PostalCodes).WithRequired(pc => pc.State);
        }

        public void AddToConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
