using Clipper.Domain.Entities;
using Clipper.Services;
using Moq;
using Clipper.Services.Base;
using Clipper.Domain.Test.Builders;
using Xunit;
using Clipper.Services.Abstractions;
using Clipper.Domain.Abstractions;

namespace Clipper.Domain.Test.Entities
{
	public class ClippingParserStorerTest
    {
        ClippingModel model;
        Mock<IRepository<Clipping>> Repository;
        ClippingParserStorer Storer;
        public ClippingParserStorerTest()
        {
            model = new ClippingModel
            {
                Book = "Book",
                Author = "Author",
                Text = "Era uma vez..."               
            };

            var bookStorer = new Mock<IClippingParserBookStorer>();
            var parser = new Mock<IClippingParser>();
            Repository = new Mock<IRepository<Clipping>>();

            var savedBook = BookBuilder.Default().WithId(3).Build();
            bookStorer.Setup(r => r.Store(model.Book, model.Author)).Returns(savedBook);

            var clipping = ClippingBuilder.Default().WithBook(savedBook).WithText(model.Text).Build(); 
            parser.Setup(p => p.Parse(model, savedBook)).Returns(clipping);

            Storer = new ClippingParserStorer(Repository.Object, bookStorer.Object, parser.Object);
        }

        [Fact]
        public void ShouldStoreClipping()
        {
            Storer.Store(model);

            Repository.Verify(d => d.Save(It.Is<Clipping>(a => a.Text.Equals(model.Text))), Times.Exactly(1));
        }
    }
}