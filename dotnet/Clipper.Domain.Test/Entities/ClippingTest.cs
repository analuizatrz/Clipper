using Clipper.Domain.Base;
using Clipper.Domain;
using Clipper.Domain.Entities;
using Clipper.Domain.Test.Builders;
using Clipper.Domain.Test.Util;
using Xunit;

namespace Clipper.Domain.Test.Entities
{
    public class ClippingTest
    {
        [Fact]
        public void ClippingShouldBeHighlightOrBookmark()
        {
            var clippingBuilder = ClippingBuilder
                            .Default()
                            .WithType(ClippingType.None);
            
            Clipping CreateWithInvalidType() => clippingBuilder.Build();

            Assert
                .Throws<DomainException>(CreateWithInvalidType)
                .WithErrorMessage(Resources.ClippingShouldBeHighlightOrBookmark);
        }

        [Theory,
        InlineData(""),
        InlineData(null)]
        public void ClippingHighlightShouldHaveValidText(string invalidText)
        {
            var clippingBuilder = ClippingBuilder
                            .Default()
                            .WithType(ClippingType.Highlight)
                            .WithText(invalidText);
            
            Clipping CreateWithInvalidType() => clippingBuilder.Build();

            Assert
                .Throws<DomainException>(CreateWithInvalidType)
                .WithErrorMessage(Resources.HighlightShouldHaveANonNullOrEmptyText);
        }

        [Fact]
        public void ClippingShouldNotHaveNoBook()
        {
            var clippingBuilder = ClippingBuilder
                            .Default()
                            .WithBook(null);
            
            Clipping CreateWithInvalidName() => clippingBuilder.Build();

            Assert
                .Throws<DomainException>(CreateWithInvalidName)
                .WithErrorMessage(Resources.BookShouldntBeEmpty);
        }
    }
}