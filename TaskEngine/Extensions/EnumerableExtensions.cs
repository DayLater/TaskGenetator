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

        public static bool IsContain<T>(this IEnumerable<IEnumerable<T>> enumerable, IEnumerable<T> item)
        {
            return enumerable.Any(e => new HashSet<T>(e).SetEquals(item));
        }

        public static bool SetEquals<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return new HashSet<T>(first).SetEquals(second);
        }
    }
}