using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks.Elements;
using TaskEngine.Values;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class SymbolBelongsSetTaskGenerator: Generator, IVariantsTaskGenerator
    {
        private readonly Random _random = new Random();
        private SymbolMathSetGenerator SetGenerator { get; }= new SymbolMathSetGenerator();

        public SymbolBelongsSetTaskGenerator()
        {
            Add(new IntValue(ValuesIds.VariantsCount) {Value = 4});

            foreach (var value in SetGenerator.Values)
                Add(value);
        }

        public SymbolBelongToSetTask Generate()
        {
            var set = SetGenerator.Generate();
            var elements = set.GetElements().ToList();
            
            var answerIndex = _random.Next(0, elements.Count);
            var answer = elements[answerIndex];

            var variants = new List<string> {answer};
            var variantsCount = Get<IntValue>(ValuesIds.VariantsCount).Value;
            while (variants.Count < variantsCount)
            {
                var element = Symbols.GetRandomElementSymbol(elements.ToArray());
                if (!variants.Contains(element))
                    variants.Add(element);
            }

            return new SymbolBelongToSetTask(variants.ShuffleToList(), answer, set);
        }
    }
}