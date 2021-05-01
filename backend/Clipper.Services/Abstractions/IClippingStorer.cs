using Clipper.Services.Dtos;

namespace Clipper.Services.Abstractions
{
	public interface IClippingStorer
	{
		void Store(ClippingDto dto);
	}
}