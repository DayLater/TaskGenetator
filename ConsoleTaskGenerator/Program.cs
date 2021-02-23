using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine;

namespace ConsoleTaskGenerator
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var firstArray = new[] {1, 2, 3, 4};
            var secondArray = new[] {2, 5};
            var setSolver = new SetSolver();
            var union = setSolver.Solve(firstArray, secondArray, SetOperation.Union).ToArray();
            var intersect = setSolver.Solve(firstArray, secondArray, SetOperation.Intersect).ToArray();
            var except = setSolver.Solve(firstArray, secondArray, SetOperation.Except).ToArray();

            WriteArray(union);
            WriteArray(intersect);
            WriteArray(except);
        }

        private static void WriteArray(IEnumerable<int> array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item}| ");
            }
            
            Console.WriteLine();
        }
    }
}