using Clipper.Services.Base;
using Clipper.Domain.Entities;
using Clipper.Services.Abstractions;

namespace Clipper.Services
{
	public class ClippingParserAuthorStorer : IClippingParserAuthorStorer
    {
        IRepositoryOfNamedEntity<Author> Repository { get; }
        public ClippingParserAuthorStorer(IRepositoryOfNamedEntity<Author> repository)
        {
            Repository = repository;
        }

        public virtual Author Store(string authorName)
        {
            var author = Repository.ByName(authorName);

            if(author == null)
            {
                author = new Author(authorName);
                Repository.Save(author);
            }

            return author;
        }
    }
}