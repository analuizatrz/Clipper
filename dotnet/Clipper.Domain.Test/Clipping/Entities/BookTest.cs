using Clipper.Domain.Base;
using Clipper.Domain.Clipping.Entities;
using Clipper.Domain.Test.Builders;
using Clipper.Domain.Test.Util;
using Xunit;

namespace Clipper.Domain.Test.Clipping.Entities
{
    public class BookTest
    {
        [Fact]
        public void BookShouldHaveName()
        {
            var expected = "A arte de ser leve";
            var book = BookBuilder
                            .Default()
                            .WithName(expected)
                            .Build();

            var actual = book.Name;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void BookShouldNotHaveInvalidName(string InvalidName)
        {
            var bookBuilder = BookBuilder
                            .Default()
                            .WithName(InvalidName);
            
            Book CreateWithInvalidName() => bookBuilder.Build();

            Assert
                .Throws<DomainException>(CreateWithInvalidName)
                .WithErrorMessage(Resources.NameShouldntBeEmpty);
        }

        [Fact]
        public void BookShouldNotHaveNoAuthor()
        {
            var bookBuilder = BookBuilder
                            .Default()
                            .WithAuthor(null);
            
            Book CreateWithInvalidName() => bookBuilder.Build();

            Assert
                .Throws<DomainException>(CreateWithInvalidName)
                .WithErrorMessage(Resources.AuthorShouldntBeEmpty);
        }
    }
}