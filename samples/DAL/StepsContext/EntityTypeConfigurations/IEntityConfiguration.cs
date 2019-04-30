using System.Data.Entity.ModelConfiguration.Configuration;

namespace DAL.StepsContext.EntityTypeConfigurations
{
    public interface IEntityConfiguration
    {
        void AddToConfiguration(ConfigurationRegistrar registrar);
    }
}
