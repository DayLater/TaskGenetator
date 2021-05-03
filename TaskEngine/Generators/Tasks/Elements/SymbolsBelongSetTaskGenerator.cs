using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks.Elements;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class SymbolsBelongSetTaskGenerator: IVariantsTaskGenerator
    {
        private readonly Random _random = new Random();
        public SymbolMathSetGenerator SetGenerator { get; } = new SymbolMathSetGenerator();
        
        public int VariantsCount { get; set; } = 6;
        public int AnswersCount { get; set; } = 2;

        public SymbolsBelongSetTask Generate()
        {
            var set = SetGenerator.Generate();
            var elements = set.GetElements().ToList();

            var answers = new List<string>();
            while (answers.Count < AnswersCount)
            {
                var elementIndex = _random.Next(0, elements.Count);
                var element = elements[elementIndex];
                if (!answers.Contains(element))
                    answers.Add(element);
            }

            var variants = new List<string>(answers);
            while (variants.Count < VariantsCount)
            {
                var element = Symbols.GetRandomElementSymbol(elements.ToArray());
                if (!variants.Contains(element))
                    variants.Add(element);
            }

            return new SymbolsBelongSetTask(variants.ShuffleToList(), answers, set);
        }
    }
}