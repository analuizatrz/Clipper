using Clipper.Domain.Entities;

namespace Clipper.Services.Abstractions
{
	public interface IClippingParserBookStorer
	{
		Book Store(string bookName, string authorName);
	}
}