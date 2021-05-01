using System.Collections.Generic;
using System.Linq;
using Clipper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clipper.Infra.Repositories
{
    public class Clippings : Repository<Clipping>
    {
        public Clippings(ApplicationDbContext context) : base(context) { }
        public override IEnumerable<Clipping> All()
        {
            return context
                    .Set<Clipping>()
                    .Include(c => c.Book)
                    .ThenInclude(b => b.Author)
                    .AsEnumerable();
        }
    }
}
