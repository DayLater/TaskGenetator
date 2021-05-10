using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models.Tasks;
using TaskEngine.Models.Values;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.CharacteristicProperty
{
    public class VariantsCharacteristicPropertyElementsTaskGenerator: VariantsGenerator
    {
        private readonly ExpressionSetGenerator _setGenerator;
        private readonly Random _random;
        private readonly IntValue _elementCount = new IntValue(ValuesIds.ElementsCount) {Value = 5};
        private readonly IntValue _elementDeltaValue = new IntValue(ValuesIds.BorderDelta) {Value = 5};
        
        public VariantsCharacteristicPropertyElementsTaskGenerator(ISetWriter setWriter, Random random) : base(TaskIds.VariantsCharacteristicPropertyElementsTask, 1, setWriter)
        {
            _random = random;
            _setGenerator = new ExpressionSetGenerator(random);
            Add(_setGenerator);
            Add(_elementCount);
            Add(_elementDeltaValue);
        }

        public override ITask Generate()
        {
            var set = _setGenerator.Generate();
            var count = _elementCount.Value;
            var elements = set.GetElements().Take(count).ToList();
            var minElement = elements.Min();
            var maxElement = elements.Max();
            var elementDelta = _elementDeltaValue.Value;

            var variants = new List<List<int>> {elements};
            while (variants.Count < VariantsCount)
            {
                var variant = new List<int>();
                int elementsCount = 0;
                while (elementsCount < count)
                {
                    var element = _random.Next(minElement - elementDelta, maxElement + elementDelta + 1);
                    if (!variant.Contains(element))
                    {
                        variant.Add(element);
                        elementsCount++;
                    }
                }

                if (!IsContain(variants, variant))
                    variants.Add( variant.OrderBy(Math.Abs).ToList());
            }
            
            var condition = $"Выберите первые {count} элементов по его характеристическому свойству {WriteProperty(set)}";
            return new VariantsTask<List<int>>(elements, condition, variants);
        }

        private bool IsContain(IEnumerable<List<int>> variants, IReadOnlyCollection<int> variant)
        {
            return variants.Any(v => new HashSet<int>(v).SetEquals(variant));
        }
    }
}