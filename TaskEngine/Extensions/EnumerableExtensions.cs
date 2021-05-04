using System.Collections.Generic;
using System.Linq;

namespace TaskEngine.Extensions
{
    public static class EnumerableExtensions
    {
        public static string GetStringRepresentation<T>(this IEnumerable<T> enumerable)
        {
            var result = enumerable.Aggregate("", (s, arg2) => s + $"{arg2.ToString()}, ");
            return result.Remove(result.Length - 2, 2);
        }
    }
}