namespace Clipper.Domain.Base
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object value)
        {
            return value == null;
        }
    }
}