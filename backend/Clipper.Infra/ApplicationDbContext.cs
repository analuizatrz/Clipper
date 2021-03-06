using Clipper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clipper.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Clipping> Clippings { get; set; }
    }
}
