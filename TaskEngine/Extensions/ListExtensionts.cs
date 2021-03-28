using System;
using System.Collections.Generic;

namespace TaskEngine.Extensions
{
    public static class ListExtensions
    {
        public static List<T> ShuffleToList<T>(this IEnumerable<T> data)
        {
            var list = new List<T>(data);
            var random = new Random();
            
            for (int i = list.Count - 1; i >= 1; i--)
            {
                var j = random.Next(i + 1);
                var temp = list[j];
                list[j] = list[i];
                list[i] = temp;
            }

            return list;
        }
    }
}