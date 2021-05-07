using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Comparers;
using TaskEngine.Extensions;
using TaskEngine.Sets;
using TaskEngine.Values;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public class SetVariantGenerator<T>: Valued, ISetVariantGenerator<T>
    {
        private readonly ISetComparer<T> _setComparer = new MathSetComparer<T>();
        private readonly ISetGenerator<T> _setGenerator;
        private readonly Random _random;
        
        private readonly IntValue _sameElementsCountInVariant = new IntValue(ValuesIds.CountSameElementsInVariant) {Value = 2};

        public SetVariantGenerator(ISetGenerator<T> setGenerator, Random random)
        {
            _setGenerator = setGenerator;
            _random = random;
            Add(_sameElementsCountInVariant);
        }

        public IEnumerable<IMathSet<T>> Generate(IMathSet<T> answerSet, int variantCount)
        {
            var elements = answerSet.GetElements().ToList();
            var subsetElements = elements.GetListWithRandomElements(_sameElementsCountInVariant.Value, _random);
            var variants = new List<IMathSet<T>>();
            
            while (variants.Count < variantCount)
            {
                var name = _random.GetRandomName();
                var variant = _setGenerator.Generate(name, subsetElements.ToArray());
                if (!IsContain(variants, variant) && !_setComparer.IsEquals(answerSet, variant))
                    variants.Add(variant);
            }

            return variants;
        }

        private bool IsContain(IEnumerable<IMathSet<T>> variants, IMathSet<T> variant)
        {
            return variants.Any(v => _setComparer.IsEquals(variant, v));
        }
    }
}