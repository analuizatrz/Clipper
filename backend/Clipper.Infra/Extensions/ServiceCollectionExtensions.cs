using Clipper.Domain.Entities;
using Clipper.Infra.Repositories;
using Clipper.Services.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clipper.Infra.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, string dataBaseName)
        {
            return services
                    .AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(dataBaseName))
                    .AddScoped<Clippings>()
                    .AddScoped<Books>()
                    .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                    .AddScoped(typeof(IRepositoryOfNamedEntity<>), typeof(RepositoryOfNamedEntity<>))
                    .AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
