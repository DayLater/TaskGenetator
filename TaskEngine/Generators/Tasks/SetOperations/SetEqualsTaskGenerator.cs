using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Comparers;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.SetOperations
{
    public class SetEqualsTaskGenerator<T>: VariantsGenerator
    {
        private readonly ISetGenerator<T> _setGenerator;
        private readonly ISetComparer<T> _setComparer;
        private readonly Random _random;
        
        public SetEqualsTaskGenerator(string id, ISetWriter setWriter, ISetGenerator<T> setGenerator, Random random, ISetComparer<T> setComparer) : base(id, 1, setWriter)
        {
            _setGenerator = setGenerator;
            _random = random;
            _setComparer = setComparer;
            Add(_setGenerator);
        }

        public override ITask Generate()
        {
            var name = _random.GetRandomName(); 
            var set = _setGenerator.Generate(name);
            var elements = set.GetElements().ToList();
            elements.Shuffle(_random);
            
            var secondSetName = _random.GetRandomName();
            var equalsSet = new MathSet<T>(secondSetName, elements);
            
            var variants = new List<IMathSet<T>> {equalsSet};
            while (variants.Count < VariantsCount)
            {
                var variantName = _random.GetRandomName();
                var variantSet = _setGenerator.Generate(variantName);
                if (!IsContain(variants, variantSet))
                    variants.Add(variantSet);
            }
            
            var condition = $"Дано множество {WriteSet(set)}. Выберите из списка вариантов равное ему множество";
            return new VariantsTask<IMathSet<T>>(equalsSet, condition, variants);
        }
        
        private bool IsContain(IEnumerable<IMathSet<T>> variants, IMathSet<T> variant)
        {
            return variants.Any(v => _setComparer.IsEquals(v, variant));
        }
    }
}