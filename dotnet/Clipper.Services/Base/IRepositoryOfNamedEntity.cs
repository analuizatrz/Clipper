using Clipper.Domain.Base;

namespace Clipper.Services.Base
{
    public interface IRepositoryOfNamedEntity<TEntity> : IRepository<TEntity> where TEntity : EntityWithName
    {
        TEntity ByName(string name);
    }
}