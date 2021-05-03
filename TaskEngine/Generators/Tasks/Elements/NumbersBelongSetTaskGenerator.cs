using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks.Elements;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class NumbersBelongSetTaskGenerator: IVariantsTaskGenerator<NumbersBelongSetTask>
    {
        public IntMathSetGenerator IntMathSetGenerator { get; } = new IntMathSetGenerator();
        private readonly Random _random = new Random();
        
        public NumbersBelongSetTask Generate()
        {
            var set = IntMathSetGenerator.Generate();
            var elements = set.GetElements().ToList();
            
            var answers = new List<int>();
            while (answers.Count < AnswerCount)
            {
                var elementIndex = _random.Next(0, elements.Count);
                var answer = elements[elementIndex];
                if (!answers.Contains(answer))
                    answers.Add(answer);
            }

            var variants = new List<int>(answers);
            while (variants.Count < VariantCount)
            {
                var element = _random.Next(IntMathSetGenerator.MinValue, IntMathSetGenerator.MaxValue);
                if (!variants.Contains(element) && !elements.Contains(element))
                    variants.Add(element);
            }

            return new NumbersBelongSetTask(answers, variants.ShuffleToList(), set);
        }

        public int VariantCount { get; set; } = 6;
        public int AnswerCount { get; set; } = 2;
    }
}