using System.Collections.Generic;
using Clipper.Domain;
using Clipper.Domain.Entities;

namespace Clipper.Domain.Abstractions
{
	public interface IClippingParser
	{
		ClippingModel Parse(string content);
		Clipping Parse(ClippingModel model, Book book);
		IEnumerable<ClippingModel> ParseAll(string content);
	}
}