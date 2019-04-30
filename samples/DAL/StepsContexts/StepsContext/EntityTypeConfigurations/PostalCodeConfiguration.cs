using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using POCO;

namespace DAL.StepsContexts.StepsContext.EntityTypeConfigurations
{
    [Export(typeof(IEntityConfiguration))]
    internal class PostalCodeConfiguration : EntityTypeConfiguration<PostalCode>, IEntityConfiguration
    {
        public PostalCodeConfiguration()
        {
            Property(pc => pc.Code).HasMaxLength(30).IsRequired();

            HasRequired(pc => pc.State).WithMany(s => s.PostalCodes);
        }

        public void AddToConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
