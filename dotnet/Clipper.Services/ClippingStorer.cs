using Clipper.Services.Base;
using Clipper.Services.Dtos;
using Clipper.Domain.Base;
using Clipper.Domain.Entities;
using Clipper.Domain;

namespace Clipper.Services
{
    public class ClippingStorer
    {
        IRepository<Clipping> Repository { get; }
        private readonly IRepository<Book> Books;
        public ClippingStorer(IRepository<Clipping> repository, IRepository<Book> books)
        {
            this.Books = books;
            Repository = repository;
        }
        public void Store(ClippingDto dto)
        {
            var book = Books.Get(dto.BookId);

            DomainValidator
                .Create()
                .When(book == null, Resources.BookDoesNotExists)
                .ThrowExceptionIfAnyErrors();

            if (dto.Id > 0)
            {
                var Clipping = Repository.Get(dto.Id);
                Clipping.Change(book, dto.Type, dto.Page, dto.LocationStart, dto.LocationEnd, dto.Date, dto.Text);
            }

            if (dto.Id == 0)
            {
                var Clipping = new Clipping(book, dto.Type, dto.Page, dto.LocationStart, dto.LocationEnd, dto.Date, dto.Text);
                Repository.Save(Clipping);
            }
        }
    }
}