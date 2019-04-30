using System.Data.Entity.ModelConfiguration.Configuration;

namespace DAL.StepsContexts.StepsContext.EntityTypeConfigurations
{
    public interface IEntityConfiguration
    {
        void AddToConfiguration(ConfigurationRegistrar registrar);
    }
}
