using System;
using System.Linq;

namespace ConsoleTaskGenerator
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var firstArray = new[] {1, 2, 3, 4};
            var secondArray = new[] {2, 5};
            var result = firstArray.Union(secondArray);
                Console.Write(result.Count());
        }
    }
}