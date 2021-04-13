using System.Collections.Generic;
using Clipper.Domain;

namespace Clipper.Domain.Abstractions
{
	public interface IClippingParser
	{
		ClippingModel Parse(string content);
		IEnumerable<ClippingModel> ParseAll(string content);
	}
}