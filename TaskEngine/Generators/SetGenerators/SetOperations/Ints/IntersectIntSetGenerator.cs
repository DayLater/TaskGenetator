using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Models.Values;

namespace TaskEngine.Generators.SetGenerators.SetOperations.Ints
{
    public class IntersectIntSetGenerator: IntersectSetGenerator<int>
    {
        private readonly IntValue _delta = new IntValue(ValuesIds.BorderDelta) {Value = 5, MinValue = 1};
        
        public IntersectIntSetGenerator(Random random) : base(random)
        {
            Add(_delta);
        }

        protected override int CreateElement(Random random, IList<int> elements)
        {
            var max = elements.Max();
            var min = elements.Min();
            return random.GetNext(min, max, _delta.Value);
        }
    }
}