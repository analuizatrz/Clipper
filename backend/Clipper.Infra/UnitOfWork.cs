using System.Threading.Tasks;

namespace Clipper.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }
        public async Task Commit()
        {
            await Context.SaveChangesAsync();
        }
    }
}
