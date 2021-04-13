using Clipper.Domain.Base;
using Clipper.Domain.Entities;
using Clipper.Domain.Test.Util;
using Xunit;

namespace Clipper.Domain.Test.Entities
{
    public class AuthorTest
    {
        [
            Theory,
            InlineData("Ferreira, Leila"),
            InlineData("Yuval Noah Harari"),
        ]
        public void AuthorShouldHaveName(string expected)
        {
            var actual = new Author(expected).Name;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void AuthorShouldNotHaveInvalidName(string InvalidName)
        {
            Author CreateWithInvalidName() => new Author(InvalidName);

            Assert
                .Throws<DomainException>(CreateWithInvalidName)
                .WithErrorMessage(Resources.NameShouldntBeEmpty);
        }
    }
}