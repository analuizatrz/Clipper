using Clipper.Services.Base;
using Clipper.Services.Dtos;
using Clipper.Domain.Base;
using Clipper.Domain.Entities;
using Clipper.Domain;

namespace Clipper.Services
{
    public class AuthorStorer
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
                var aluno = Repository.Get(dto.Id);
                aluno.ChangeName(dto.Name);
            }

            if (dto.Id == 0)
            {
                var aluno = new Author(dto.Name);
                Repository.Save(aluno);
            }
        }
    }
}