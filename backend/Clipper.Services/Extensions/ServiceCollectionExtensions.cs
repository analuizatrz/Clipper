using Clipper.Domain;
using Clipper.Domain.Abstractions;
using Clipper.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Clipper.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services
                .AddScoped<IAuthorStorer, AuthorStorer>()
                .AddScoped<IBookStorer, BookStorer>()
                .AddScoped<IClippingParser, ClippingParser>()
                .AddScoped<IClippingStorer, ClippingStorer>()
                .AddScoped<IClippingParserStorer, ClippingParserStorer>()
                .AddScoped<IClippingParserBookStorer, ClippingParserBookStorer>()
                .AddScoped<IClippingParserAuthorStorer, ClippingParserAuthorStorer>();
        }
    }
}
