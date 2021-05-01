using System.Threading.Tasks;

namespace Clipper.Infra
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}