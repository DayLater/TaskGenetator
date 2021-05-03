using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks.Elements;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class SymbolBelongToSetTaskGenerator: IVariantsTaskGenerator
    {
        private readonly Random _random = new Random();
        public SymbolMathSetGenerator SetGenerator { get; }= new SymbolMathSetGenerator();
        public int VariantsCount { get; set; }

        public SymbolBelongToSetTask Generate()
        {
            var set = SetGenerator.Generate();
            var elements = set.GetElements().ToList();
            
            var answerIndex = _random.Next(0, elements.Count);
            var answer = elements[answerIndex];

            var variants = new List<string> {answer};
            while (variants.Count < VariantsCount)
            {
                var element = Symbols.GetRandomElementSymbol(elements.ToArray());
                if (!variants.Contains(element))
                    variants.Add(element);
            }

            return new SymbolBelongToSetTask(variants.ShuffleToList(), answer, set);
        }
    }
}