using Clipper.Services.Dtos;

namespace Clipper.Services.Abstractions
{
	public interface IBookStorer
	{
		void Store(BookDto dto);
	}
}