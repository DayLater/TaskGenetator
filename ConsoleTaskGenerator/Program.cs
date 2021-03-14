using System;
using System.Linq.Expressions;

namespace ConsoleTaskGenerator
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Expression<Func<int, int>> func = (i) => 2 * i;
            func.Compile().Invoke(2);
            Console.Write(func.ToString());
        }
    }
}