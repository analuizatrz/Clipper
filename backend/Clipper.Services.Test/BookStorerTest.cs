using Clipper.Domain.Base;
using Clipper.Domain.Entities;
using Clipper.Domain.Test.Util;
using Clipper.Services;
using Xunit;
using Moq;
using Clipper.Services.Base;
using Clipper.Services.Dtos;
using Clipper.Domain.Test.Builders;

namespace Clipper.Domain.Test.Entities
{
    public class BookStorerTest
    {
        BookDto dto;
        Mock<IRepositoryOfNamedEntity<Book>> repository;
        Mock<IRepository<Author>> authors;
        BookStorer storer;
        Author savedAuthor;
        public BookStorerTest()
        {
            savedAuthor = new Author("J. K. Rowling");
            dto = new BookDto
            {
                Id = 0,
                Name = "Harry Potter",
                AuthorId = 0,
                Description = "The boy who lived",
                Edition = 2,
                Year = 1999
            };
            repository = new Mock<IRepositoryOfNamedEntity<Book>>();
            authors = new Mock<IRepository<Author>>();
            authors.Setup(r => r.Get(dto.AuthorId)).Returns(savedAuthor);
            storer = new BookStorer(repository.Object, authors.Object);
        }

        [Fact]
        public void ShouldStoreBook()
        {
            storer.Store(dto);

            repository.Verify(d => d.Save(It.Is<Book>(a => a.Name.Equals(dto.Name))));
        }
        
        [Fact]
        public void ShouldNotStoreBookWithSameNameAsOther()
        {
            dto.Id = 323;
            var savedBook = new Book(dto.Name, savedAuthor, dto.Description, dto.Edition, dto.Year);
            repository.Setup(c => c.ByName(dto.Name)).Returns(savedBook);

            Assert.Throws<DomainException>(() => storer.Store(dto))
                .WithErrorMessage(Resources.BookWithSameName);
        }
        [Fact]
        public void ShouldNotStoreBookWithNonExistingAuthor()
        {
            dto.AuthorId = 232;

            Assert.Throws<DomainException>(() => storer.Store(dto))
                .WithErrorMessage(Resources.AuthorDoesNotExists);
        }

        [Fact]
        public void ShouldChangeBookProperties()
        {
            dto.Id = 323;
            var savedBook = BookBuilder.Default().Build();
            repository.Setup(c => c.Get(dto.Id)).Returns(savedBook);

            storer.Store(dto);

            Assert.Equal(dto.Name, savedBook.Name);
            Assert.Equal(dto.AuthorId, savedBook.Author.Id);
            Assert.Equal(dto.Description, savedBook.Description);
            Assert.Equal(dto.Edition, savedBook.Edition);
            Assert.Equal(dto.Year, savedBook.Year);
        }
    }
}