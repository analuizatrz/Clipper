using Clipper.Domain;

namespace Clipper.Services.Abstractions
{
    public interface IClippingParserStorer
    {
        void Store(string content);
        void Store(ClippingModel model);
    }
}