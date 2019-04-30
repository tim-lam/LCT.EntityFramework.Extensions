using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Reflection;
using DAL.StepsContexts.StepsContext.EntityTypeConfigurations;
using POCO;

namespace DAL.StepsContexts.StepsContext
{
    public class StepsContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> People { get; set; }

        [ImportMany(typeof (IEntityConfiguration))] 
// ReSharper disable UnassignedField.Local
        private IEnumerable<IEntityConfiguration> _entityConfigurations;
// ReSharper restore UnassignedField.Local

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            foreach (var configuration in _entityConfigurations)
            {
                configuration.AddToConfiguration(modelBuilder.Configurations);
            }

            #region obsoleted codes

            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Configurations.Add(new CountryTypeConfiguration());

            //modelBuilder.Configurations.Add(new StateTypeConfiguration());

            //modelBuilder.Configurations.Add(new PostalCodeTypeConfiguration());

            //modelBuilder.Configurations.Add(new AddressTypeConfiguration());

            #endregion
        }
    }
}
