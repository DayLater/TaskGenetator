using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks.Elements;
using TaskEngine.Values;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class SymbolsBelongSetTaskGenerator: Generator, IVariantsTaskGenerator
    {
        private readonly Random _random = new Random();
        private readonly SymbolMathSetGenerator _setGenerator = new SymbolMathSetGenerator();

        public SymbolsBelongSetTaskGenerator()
        {
            Add(new IntValue(ValuesIds.VariantsCount) {Value = 6});
            Add(new IntValue(ValuesIds.AnswersCount) {Value = 2});

            foreach (var value in _setGenerator.Values)
                Add(value);
        }
        
        public SymbolsBelongSetTask Generate()
        {
            var set = _setGenerator.Generate();
            var elements = set.GetElements().ToList();

            var answers = new List<string>();
            var answersCount = Get<IntValue>(ValuesIds.AnswersCount).Value;
            while (answers.Count < answersCount)
            {
                var elementIndex = _random.Next(0, elements.Count);
                var element = elements[elementIndex];
                if (!answers.Contains(element))
                    answers.Add(element);
            }

            var variants = new List<string>(answers);
            var variantsCount = Get<IntValue>(ValuesIds.VariantsCount).Value;
            while (variants.Count < variantsCount)
            {
                var element = Symbols.GetRandomElementSymbol(elements.ToArray());
                if (!variants.Contains(element))
                    variants.Add(element);
            }

            return new SymbolsBelongSetTask(variants.ShuffleToList(), answers, set);
        }
    }
}