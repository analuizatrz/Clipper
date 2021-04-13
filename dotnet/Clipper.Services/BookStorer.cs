using Clipper.Services.Base;
using Clipper.Services.Dtos;
using Clipper.Domain.Base;
using Clipper.Domain.Entities;
using Clipper.Domain;

namespace Clipper.Services
{
    public class BookStorer
    {
        IRepositoryOfNamedEntity<Book> Repository { get; }
        private readonly IRepository<Author> authors;
        public BookStorer(IRepositoryOfNamedEntity<Book> repository, IRepository<Author> authors)
        {
            this.authors = authors;
            Repository = repository;
        }
        public void Store(BookDto dto)
        {
            var bookWithSameName = Repository.ByName(dto.Name);
            var author = authors.Get(dto.AuthorId);

            DomainValidator
                .Create()
                .When(bookWithSameName != null && dto.Id != bookWithSameName.Id, Resources.BookWithSameName)
                .When(author == null, Resources.AuthorDoesNotExists)
                .ThrowExceptionIfAnyErrors();

            if (dto.Id > 0)
            {
                var book = Repository.Get(dto.Id);
                book.Change(dto.Name, author, dto.Description, dto.Edition, dto.Year);
            }

            if (dto.Id == 0)
            {
                var book = new Book(dto.Name, author, dto.Description, dto.Edition, dto.Year);
                Repository.Save(book);
            }
        }
    }
}