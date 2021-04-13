using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Clipper.Domain.Test
{
	public class ClippingParserTest
    {
        public IReadOnlyDictionary<string, string> clippings = new Dictionary<string, string>()
        { 
            ["SingleClippingHighlight"] = 
@"A arte de ser leve (Ferreira, Leila)
- Seu destaque ou posição 1896-1897 | Adicionado: terça-feira, 29 de maio de 2018 10:37:11
“Namore muito, mas não se case não”.",

            ["SingleClippingBookmark"] =
@"Homo Deus (Yuval Noah Harari)
- Seu marcador ou posição 2278 | Adicionado: sexta-feira, 23 de novembro de 2018 00:32:29

",
            ["MultipleClippingBookmark"] =
@"Homo Deus (Yuval Noah Harari)
- Seu marcador ou posição 2278 | Adicionado: sexta-feira, 23 de novembro de 2018 00:32:29

==========

A arte de ser leve (Ferreira, Leila)
- Seu destaque ou posição 1896-1897 | Adicionado: terça-feira, 29 de maio de 2018 10:37:11
“Namore muito, mas não se case não”.
"
        };

        [
            Theory(),
            InlineData("SingleClippingHighlight", "Ferreira, Leila"),
            InlineData("SingleClippingBookmark", "Yuval Noah Harari"),
        ]
        public void ShouldParseAuthorCorrectly(string clipping, string expected)
        {
            var source = clippings[clipping];
            var actual = new ClippingParser().Parse(source).Author;
            Assert.Equal(expected, actual);
        }
        [
            Theory(),
            InlineData("SingleClippingHighlight", "A arte de ser leve"),
            InlineData("SingleClippingBookmark", "Homo Deus"),
        ]
        public void ShouldParseBookCorrectly(string clipping, string expected)
        {
            var source = clippings[clipping];
            var actual = new ClippingParser().Parse(source).Book;
            Assert.Equal(expected, actual);
        }
        [
            Theory(),
            InlineData("SingleClippingHighlight", ClippingType.Highlight),
            InlineData("SingleClippingBookmark", ClippingType.Bookmark),
        ]
        public void ShouldParseTypeCorrectly(string clipping, ClippingType expected)
        {
            var source = clippings[clipping];
            var actual = new ClippingParser().Parse(source).Type;
            Assert.Equal(expected, actual);
        }
        [
            Theory(),
            InlineData("SingleClippingHighlight", 0, "1896"),
            InlineData("SingleClippingHighlight", 1, "1897"),
            InlineData("SingleClippingBookmark", 0, "2278"),
        ]
        public void ShouldParsePositionCorrectly(string clipping, int index, string expected)
        {
            var source = clippings[clipping];
            var actual = new ClippingParser().Parse(source).Position[index];
            Assert.Equal(expected, actual);
        }

        [
            Theory(),
            InlineData("SingleClippingHighlight", "29 de maio de 2018 10:37:11"),
            InlineData("SingleClippingBookmark", "23 de novembro de 2018 00:32:29"),
        ]
        public void ShouldParseDateCorrectly(string clipping, string expected)
        {
            var source = clippings[clipping];
            var actual = new ClippingParser().Parse(source).Date;
            Assert.Equal(expected, actual);
        }

        [
            Theory(),
            InlineData("SingleClippingHighlight", "“Namore muito, mas não se case não”."),
            InlineData("SingleClippingBookmark", ""),
        ]
        public void ShouldParseTextCorrectly(string clipping, string expected)
        {
            var source = clippings[clipping];
            var actual = new ClippingParser().Parse(source).Text;
            Assert.Equal(expected, actual);
        }

        [
            Theory(),
            InlineData("MultipleClippingBookmark", 0, "Yuval Noah Harari"),
            InlineData("MultipleClippingBookmark", 1, "Ferreira, Leila"),
        ]
        public void WhenPasringAllShouldParseAuthorOfEveryClippingCorrectly(string clipping, int index, string expected)
        {
            var source = clippings[clipping];
            var actual = new ClippingParser().ParseAll(source).ToList()[index].Author;
            Assert.Equal(expected, actual);
        }
    }
}