using Clipper.Services.Base;
using Clipper.Domain.Entities;
using Clipper.Domain;
using Clipper.Services.Abstractions;
using Clipper.Domain.Abstractions;

namespace Clipper.Services
{
	public class ClippingParserStorer
    {
        IRepository<Clipping> Repository { get; }
        IClippingParserBookStorer BookStorer { get; }
        IClippingParser Parser { get; }

        public ClippingParserStorer(
            IRepository<Clipping> repository,
            IClippingParserBookStorer bookStorer,
            IClippingParser parser)
        {
            Repository = repository;
            BookStorer = bookStorer;
            Parser = parser;
        }
        public void Store(string content)
        {
            foreach (var clipping in Parser.ParseAll(content))
                Store(clipping);
        }

        public void Store(ClippingModel model)
        {
            var book = BookStorer.Store(model.Book, model.Author);
            var clipping = Parser.Parse(model, book);
            Repository.Save(clipping);
        }
    }
}