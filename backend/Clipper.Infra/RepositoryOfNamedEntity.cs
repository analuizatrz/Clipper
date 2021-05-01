using System.Linq;
using Clipper.Domain.Base;
using Clipper.Services.Base;

namespace Clipper.Infra
{
    public class RepositoryOfNamedEntity<TEntity> :
        Repository<TEntity>,
        IRepositoryOfNamedEntity<TEntity>
        where TEntity : EntityWithName
    {
        public RepositoryOfNamedEntity(ApplicationDbContext context) : base(context) { }

        public TEntity ByName(string name)
        {
            var query = context.Set<TEntity>().Where(e => e.Name == name);
            if (query.Any())
                return query.First();
            return null;
        }
    }
}
