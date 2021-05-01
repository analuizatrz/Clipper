using Clipper.Services.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Clipper.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services
                .AddScoped<AuthorStorer>()
                .AddScoped<BookStorer>()
                .AddScoped<ClippingStorer>();
        }
    }
}
