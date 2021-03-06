using Clipper.Services.Base;
using Clipper.Services.Dtos;
using Clipper.Domain.Base;
using Clipper.Domain.Entities;
using Clipper.Domain;
using Clipper.Services.Abstractions;

namespace Clipper.Services
{
    public class AuthorStorer : IAuthorStorer
    {
        IRepositoryOfNamedEntity<Author> Repository { get; }
        public AuthorStorer(IRepositoryOfNamedEntity<Author> repository)
        {
            Repository = repository;
        }
        public void Store(AuthorDto dto)
        {
            var authorWithSameName = Repository.ByName(dto.Name);

            DomainValidator
                .Create()
                .When(authorWithSameName != null && dto.Id != authorWithSameName.Id, Resources.AuthorWithSameName)
                .ThrowExceptionIfAnyErrors();

            if (dto.Id > 0)
            {
                var author = Repository.Get(dto.Id);
                author.ChangeName(dto.Name);
            }

            if (dto.Id == 0)
            {
                var author = new Author(dto.Name);
                Repository.Save(author);
            }
        }
    }
}