using System.Collections.Generic;
using System.Linq;
using Clipper.Domain.Base;
using Clipper.Services.Base;

namespace Clipper.Infra
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext context;
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public virtual IEnumerable<TEntity> All()
        {
            return context.Set<TEntity>().ToList();
        }

        public virtual TEntity Get(long id)
        {
            var query = context.Set<TEntity>().Where(e => e.Id == id);
            if (query.Any())
                return query.First();
            return null;
        }

        public void Save(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }
    }
}
