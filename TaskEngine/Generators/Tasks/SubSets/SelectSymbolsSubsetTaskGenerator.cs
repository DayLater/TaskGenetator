using System;
using System.Collections.Generic;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.SubSets
{
    public class SelectSymbolsSubsetTaskGenerator: SelectElementsSubsetTaskGenerator<string>
    {
        private readonly Random _random;

        public SelectSymbolsSubsetTaskGenerator(int answerCount, ISetWriter setWriter, Random random, string id) 
            : base(id, answerCount, setWriter,  new SymbolMathSetGenerator(random), random)
        {
            _random = random;
        }

        protected override string GetElement(IList<string> elements)
        {
            return _random.GetRandomElementSymbol();
        }
    }
}