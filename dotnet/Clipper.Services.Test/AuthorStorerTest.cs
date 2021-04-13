using Clipper.Domain.Base;
using Clipper.Domain.Entities;
using Clipper.Domain.Test.Util;
using Clipper.Services;
using Xunit;
using Moq;
using Clipper.Services.Base;
using Clipper.Services.Dtos;

namespace Clipper.Domain.Test.Entities
{
    public class AuthorStorerTest
    {
        AuthorDto dto;
        Mock<IRepositoryOfNamedEntity<Author>> repository;
        AuthorStorer storer;
        public AuthorStorerTest()
        {
            dto = new AuthorDto
            {
                Id = 0,
                Name = "J. K. Rowling"
            };
            repository = new Mock<IRepositoryOfNamedEntity<Author>>();
            storer = new AuthorStorer(repository.Object);
        }

        [Fact]
        public void ShouldStoreAuthor()
        {
            storer.Store(dto);

            repository.Verify(d => d.Save(It.Is<Author>(a => a.Name.Equals(dto.Name))));
        }
        
        [Fact]
        public void ShouldNotStoreAuthorWithSameNameAsOther()
        {
            dto.Id = 323;
            var savedAuthor = new Author(dto.Name);

            repository.Setup(c => c.ByName(dto.Name)).Returns(savedAuthor);

            Assert.Throws<DomainException>(() => storer.Store(dto))
                .WithErrorMessage(Resources.AuthorWithSameName);
        }

        [Fact]
        public void ShouldChangeAuthorName()
        {
            dto.Id = 323;
            var savedAuthor = new Author("Default");
            repository.Setup(c => c.Get(dto.Id)).Returns(savedAuthor);

            storer.Store(dto);

            Assert.Equal(dto.Name, savedAuthor.Name);
        }
    }
}