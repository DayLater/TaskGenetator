using System;
using System.Collections.Generic;
using TaskEngine.Extensions;

namespace TaskEngine.Generators.SetGenerators.SetOperations.Symbols
{
    public class IntersectSymbolSetGenerator: IntersectSetGenerator<string>
    {
        public IntersectSymbolSetGenerator(Random random) : base(random)
        {
        }

        protected override string CreateElement(Random random, IList<string> elements)
        {
            return random.GetRandomElementSymbol();
        }
    }
}