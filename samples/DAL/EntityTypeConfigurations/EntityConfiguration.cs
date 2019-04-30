using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace DAL.EntityTypeConfigurations
{
    public class EntityConfiguration
    {
        [ImportMany(typeof(IEntityConfiguration))]
        public static IEnumerable<IEntityConfiguration> Configurations
        {
            get;
            set;
        }
    }
}
