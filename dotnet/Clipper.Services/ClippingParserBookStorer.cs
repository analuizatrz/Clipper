using Clipper.Services.Base;
using Clipper.Domain.Entities;
using Clipper.Services.Abstractions;

namespace Clipper.Services
{
    public class ClippingParserBookStorer : IClippingParserBookStorer
    {
        IRepositoryOfNamedEntity<Book> Repository { get; }
        IClippingParserAuthorStorer AuthorStorer { get; }

        public ClippingParserBookStorer(
            IRepositoryOfNamedEntity<Book> repository,
            IClippingParserAuthorStorer authorStorer)
        {
            AuthorStorer = authorStorer;
            Repository = repository;
        }

        public Book Store(string bookName, string authorName)
        {
            var book = Repository.ByName(bookName);

            if(book == null)
            {
                var author = AuthorStorer.Store(authorName);

                book = new Book(bookName, author, null, null, null);
                Repository.Save(book);
            }

            return book;
        }
    }
}