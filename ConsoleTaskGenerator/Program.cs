using System;
using System.Linq.Expressions;

namespace ConsoleTaskGenerator
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var sort = new Sorter();
            
            sort.Sort(new []{4, 5}, new SuperComparer());
        }
    }
}