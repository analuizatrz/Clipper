using Clipper.Domain.Base;
using Xunit;

namespace Clipper.Domain.Test.Util
{
    public static class AssertExtension
	{
		public static void WithErrorMessage(this DomainException exception, string message)
		{
			if (exception.ErrorMessages.Contains(message))
				Assert.True(true);
			else
				Assert.False(true, $"Expected message '{message}'");
		}
	}
}