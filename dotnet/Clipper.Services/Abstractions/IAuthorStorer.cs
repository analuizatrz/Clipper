using Clipper.Services.Dtos;

namespace Clipper.Services.Abstractions
{
	public interface IAuthorStorer
	{
		void Store(AuthorDto dto);
	}
}