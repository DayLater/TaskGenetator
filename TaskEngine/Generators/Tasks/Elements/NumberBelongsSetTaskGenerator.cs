using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks.Elements;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class NumberBelongsSetTaskGenerator: IVariantsTaskGenerator
    {
        public IntMathSetGenerator IntMathSetGenerator { get; } = new IntMathSetGenerator();
        private readonly Random _random = new Random();

        public NumberBelongsSetTask Generate()
        {
            var set = IntMathSetGenerator.Generate();
            var elements = set.GetElements().ToList();
            var elementIndex = _random.Next(0, elements.Count);
            var answer = elements[elementIndex];

            var variants = new List<int> {answer};
            while (variants.Count < VariantsCount)
            {
                var element = _random.Next(IntMathSetGenerator.MinValue, IntMathSetGenerator.MaxValue);
                if (!variants.Contains(element) && !elements.Contains(element))
                    variants.Add(element);
            }

            return new NumberBelongsSetTask(answer, variants.ShuffleToList(), set);
        }

        public int VariantsCount { get; set; } = 4;
    }
}