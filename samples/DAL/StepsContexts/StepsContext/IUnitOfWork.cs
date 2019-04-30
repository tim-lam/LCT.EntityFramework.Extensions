using System.Data.Entity;

namespace DAL.StepsContexts.StepsContext
{
    internal interface IUnitOfWork
    {
        DbContext Context { get; }
        int Save();
    }
}
