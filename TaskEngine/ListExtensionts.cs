using System;
using System.Collections.Generic;

namespace TaskEngine
{
    public static class ListExtensions
    {
        public static List<T>  Shuffle<T>(this List<T> data)
        {
            var random = new Random();
            
            for (int i = data.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = data[j];
                data[j] = data[i];
                data[i] = temp;
            }

            return data;
        }
    }
}