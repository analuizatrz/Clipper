using Clipper.Domain.Entities;

namespace Clipper.Services.Abstractions
{
	public interface IClippingParserAuthorStorer
	{
		Author Store(string authorName);
	}
}