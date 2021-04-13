using Clipper.Domain.Entities;
using Clipper.Services;
using Xunit;
using Moq;
using Clipper.Services.Base;

namespace Clipper.Domain.Test.Entities
{
	public class ClippingParserAuthorStorerTest
    {
        ClippingModel model;
        Mock<IRepositoryOfNamedEntity<Author>> repository;
        ClippingParserAuthorStorer storer;
        public ClippingParserAuthorStorerTest()
        {
            model = new ClippingModel
            {
                Author = "J. K. Rowling"
            };
            repository = new Mock<IRepositoryOfNamedEntity<Author>>();
            storer = new ClippingParserAuthorStorer(repository.Object);
        }

        [Fact]
        public void ShouldReturnAuthorWhenStoreByName()
        {
            var author = storer.Store(model.Author);

            Assert.Equal(model.Author, author.Name);
        }

        [Fact]
        public void ShouldSaveAuthorByNameWhenDoesNotExist()
        {
            storer.Store(model.Author);

            repository.Verify(d => d.Save(It.Is<Author>(a => a.Name.Equals(model.Author))));
        }

        [Fact]
        public void ShouldNotSaveAuthorByNameWhenExists()
        {
            var savedAuthor = new Author(model.Author);
            repository.Setup(c => c.ByName(model.Author)).Returns(savedAuthor);

            storer.Store(model.Author);
            
            repository.Verify(d => d.Save(It.IsAny<Author>()), Times.Never);
        }
    }
}