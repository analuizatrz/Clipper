using System.Collections.Generic;
using System.Linq;
using Clipper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clipper.Infra.Repositories
{
    public class Books : RepositoryOfNamedEntity<Book>
    {
        public Books(ApplicationDbContext context) : base(context) { }
        public override IEnumerable<Book> All()
        {
            return context.Set<Book>().Include(b => b.Author).AsEnumerable();
        }
    }
}
