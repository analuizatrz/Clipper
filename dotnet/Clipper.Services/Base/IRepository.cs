using System.Collections.Generic;
using Clipper.Domain.Base;

namespace Clipper.Services.Base
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> All();
        TEntity Get(long id);
        void Save(TEntity entity);
    }
}