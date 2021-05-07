using System;
using System.Collections.Generic;
using TaskEngine.Extensions;

namespace TaskEngine.Generators.SetGenerators.SetOperations.Symbols
{
    public class ExceptSymbolSetGenerator: ExceptSetGenerator<string>
    {
        public ExceptSymbolSetGenerator(Random random) : base(random)
        {
        }

        protected override string CreateElement(Random random, IList<string> firstList)
        {
            return random.GetRandomElementSymbol();
        }
    }
}