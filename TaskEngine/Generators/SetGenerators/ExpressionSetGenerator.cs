using System;
using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators
{
    public class ExpressionSetGenerator
    {
        private readonly SetNames _setNames = new SetNames();
        private readonly Random _random = new Random();
        public int Min { get; set; } = -10;
        public int Max { get; set; } = 10;

        public List<IMathSet<int>> Generate(int count)
        {
            var result = new List<IMathSet<int>>();
            var containedItems = new HashSet<int>();
            var names = _setNames.Names;
            for (var i = 0; i < count; i++)
            {
                int coefficient;
                do
                {
                    coefficient = _random.Next(Min, Max);
                } while (containedItems.Contains(coefficient) || coefficient == 0 || coefficient == 1);
                
                containedItems.Add(coefficient);
                var name = names[i];
                var set = new ExpressionSet<int>(name, x => coefficient * x);
                result.Add(set);
            }

            return result;
        }
    }
}