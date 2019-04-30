using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Reflection;
using DAL.StepsContext.EntityTypeConfigurations;
using POCO;

namespace DAL.StepsContext
{

    public class StepsContext : DbContext
    {
        #region Private Properties

        [ImportMany(typeof(IEntityConfiguration))]
        // ReSharper disable UnassignedField.Local
        private IEnumerable<IEntityConfiguration> _entityConfigurations;
        // ReSharper restore UnassignedField.Local

        #endregion

        private readonly ObjectContext _objectContext;

        public StepsContext(string connectionString) : base(connectionString)
        {
            _objectContext = ((IObjectContextAdapter) this).ObjectContext;
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> People { get; set; }


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


        //public bool IsAttached(object entity)
        //{
        //    return ChangeTracker.Entries().Any(x => Equals(x, entity));

        //        //.Any(o => _objectContext.CreateEntityKey(BaseEntitySet(o.Entity).Name, o.Entity)
        //        //          == _objectContext.CreateEntityKey(BaseEntitySet(entity).Name, entity));
        //}

        //public IEnumerable<DbMemberEntry> NavigationMemberEntriesOf(object entity)
        //{
        //    return ((EntityType) BaseEntitySet(entity).ElementType).NavigationProperties
        //        .Select(x => Entry(entity).Member(x.Name));
        //}

        

        //public void AddOrSet(object entity)
        //{
        //    var key = _objectContext.CreateEntityKey(BaseEntitySet(entity).Name, entity);

        //    //GetOriginalEntity will cause exception if there is no row found with the same key(id)
        //    //object originalEntity = _objectContext.GetOriginalEntity(key);
        //    object originalEntity;

        //    if (_objectContext.TryGetObjectByKey(key, out originalEntity))
        //    {
        //        Entry(originalEntity).CurrentValues.SetValues(entity);
        //    }
        //    else
        //    {
        //        var entityType = Type.GetType(
        //            string.Format("{0}, {1}", entity.GetType().FullName, entity.GetType().Assembly));

        //        // ReSharper disable AssignNullToNotNullAttribute
        //        var newEntity = Activator.CreateInstance(entityType);
        //        // ReSharper restore AssignNullToNotNullAttribute

        //        Set(newEntity.GetType()).Add(newEntity);

        //        Entry(newEntity).CurrentValues.SetValues(entity);

        //        // _objectContext.AddObject(key.EntitySetName, entity);
        //    }

        //    #region obsoleted codes

        //    ////add or attach current entity to DbSet will attach all entities of its NavigationProperties
        //    ////e.g.( var dbset = _unitOfWork.Context.Set(entity.GetType());
        //    ////      dbset.Add(entity);)
        //    //if (_objectContext.TryGetObjectByKey(key, out originalEntity))
        //    //{
        //    //    _objectContext.ApplyCurrentValues(key.EntitySetName, entity);
        //    //}
        //    //else
        //    //{
        //    //    _objectContext.AddObject(key.EntitySetName, entity);
        //    //}

        //    #endregion
        //}

       
        //private EntitySetBase BaseEntitySet(object entity)
        //{
        //    return EntityContainer.BaseEntitySets.Single(s => s.ElementType.Name == entity.GetType().Name);
        //}

        //private EntityContainer EntityContainer
        //{
        //    get
        //    {
        //        return _objectContext.MetadataWorkspace
        //            .GetEntityContainer(_objectContext.DefaultContainerName, DataSpace.CSpace);
        //    }
        //}
    }
}
