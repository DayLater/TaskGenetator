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

        public static List<T> GetListWithRandomElements<T>(this List<T> list, int count, Random random)
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