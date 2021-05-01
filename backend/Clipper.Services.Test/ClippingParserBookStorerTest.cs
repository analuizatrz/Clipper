using Clipper.Domain.Entities;
using Clipper.Services;
using Xunit;
using Moq;
using Clipper.Services.Base;
using Clipper.Domain.Test.Builders;

namespace Clipper.Domain.Test.Entities
{
	public class ClippingParserBookStorerTest
    {
        ClippingModel Model;
        Mock<IRepositoryOfNamedEntity<Book>> Repository;
        ClippingParserBookStorer Storer;
        public ClippingParserBookStorerTest()
        {
            Model = new ClippingModel
            {
                Author = "J. K. Rowling",
                Book = "Harry Potter"
            };

            ClippingParserAuthorStorer authorStorer;
            Mock<IRepositoryOfNamedEntity<Author>> authors;
            authors = new Mock<IRepositoryOfNamedEntity<Author>>();
            authorStorer = new ClippingParserAuthorStorer(authors.Object);

            Repository = new Mock<IRepositoryOfNamedEntity<Book>>();
            Storer = new ClippingParserBookStorer(Repository.Object, authorStorer);
        }

        [Fact]
        public void ShouldReturnBookWhenStoreByName()
        {
            var Book = Storer.Store(Model.Book, Model.Author);

            Assert.Equal(Model.Book, Book.Name);
        }

        [Fact]
        public void ShouldSaveBookByNameWhenDoesNotExist()
        {
            Storer.Store(Model.Book, Model.Author);

            Repository.Verify(d => d.Save(It.Is<Book>(a => a.Name.Equals(Model.Book))));
        }

        [Fact]
        public void ShouldNotSaveBookByNameWhenExists()
        {
            var savedBook = BookBuilder.Default().WithName(Model.Book).Build();
            Repository.Setup(c => c.ByName(Model.Book)).Returns(savedBook);

            Storer.Store(Model.Book, Model.Author);
            
            Repository.Verify(d => d.Save(It.IsAny<Book>()), Times.Never);
        }
    }
}