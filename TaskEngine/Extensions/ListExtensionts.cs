using System;
using System.Collections.Generic;

namespace TaskEngine.Extensions
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> data, Random random)
        {
            for (int i = data.Count - 1; i >= 1; i--)
            {
                var j = random.Next(i + 1);
                var temp = data[j];
                data[j] = data[i];
                data[i] = temp;
            }
        }

        public static List<T> GetListWithRandomElements<T>(this IList<T> list, int count, Random random)
        {
            if (count > list.Count)
                throw new ArgumentOutOfRangeException("Количество элементов не может быть больше списка");
            
            var resultList = new List<T>();
            while (resultList.Count < count)
            {
                var elementIndex = random.Next(0, list.Count);
                var element = list[elementIndex];
                if (!resultList.Contains(element))
                    resultList.Add(element);
            }

            return resultList;
        }
    }
}