using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Values;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.SubSets
{
    public class SelectNumbersSubSetTaskGenerator: SelectElementsSubsetTaskGenerator<int>
    {
        private readonly IntValue _elementDelta = new IntValue(ValuesIds.BorderDelta) {Value = 4};
        private readonly Random _random;
        
        public SelectNumbersSubSetTaskGenerator(int answerCount, ISetWriter setWriter, Random random, string id) 
            : base(id, answerCount, setWriter, new IntMathSetGenerator(random), random)
        {
            _random = random;
            Add(_elementDelta);
        }

        protected override int GetElement(IList<int> elements)
        {
            var min = elements.Min();
            var max = elements.Max();
            return _random.GetNext(min, max, _elementDelta.Value);
        }
    }
}