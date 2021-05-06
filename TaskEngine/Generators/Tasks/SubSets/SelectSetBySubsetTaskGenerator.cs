using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Comparers;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Values;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.SubSets
{
    public class SelectSetBySubsetTaskGenerator<T>: VariantsGenerator
    {
        private readonly ISetGenerator<T> _setGenerator;
        private readonly ISetComparer<T> _setComparer;
        private readonly IntValue _elementCount = new IntValue(ValuesIds.ElementsCount) {Value = 4};
        private readonly Random _random;
        
        public SelectSetBySubsetTaskGenerator(string id, int answerCount, ISetWriter setWriter, ISetGenerator<T> setGenerator, Random random, ISetComparer<T> setComparer) 
            : base(id, answerCount, setWriter)
        {
            _setGenerator = setGenerator;
            _random = random;
            _setComparer = setComparer;
            Add(_elementCount);
            Add(_setGenerator);
        }

        public override ITask Generate()
        {
            var name = Symbols.GetRandomName(_random);
            var names = new List<string> {name};
            var answerSet = _setGenerator.Generate(name);
            var subsetElements = answerSet.GetElements().ToList().GetListWithRandomElements(_elementCount.Value, _random);

            var subsetName = Symbols.GetRandomName(_random, names.ToArray());
            var subset = new MathSet<T>(subsetName, subsetElements);

            var answers = new List<IMathSet<T>> {answerSet};
            while (answers.Count < AnswersCount)
            {
                var answerName = Symbols.GetRandomName(_random, names.ToArray());
                var set = _setGenerator.Generate(answerName, subsetElements.ToArray());
                if (!IsContain(answers, set))
                    answers.Add(set);
            }
            
            var variants = new List<IMathSet<T>>(answers);
            while (variants.Count < VariantsCount)
            {
                var variantName = Symbols.GetRandomName(_random, names.ToArray());
                var variant = _setGenerator.Generate(variantName);
                if (!IsContain(variants, variant) && !IsContainsAllElements(variant, subsetElements))
                    variants.Add(variant);
            }

            var condition = GetCondition(answers, subset);
            return new VariantsTask<IMathSet<T>>(answers, condition, variants);
        }

        private string GetCondition(ICollection<IMathSet<T>> answers, IMathSet<T> subset)
        {
            var set = answers.Count == 1 ? "множество, включающее" : "множества, включающие";
            return $"Выберите {set} данное подмножество {WriteSet(subset)}";
        }
        
        private bool IsContain(IEnumerable<IMathSet<T>> variants, IMathSet<T> variant)
        {
            return variants.Any(v => _setComparer.IsEquals(v, variant));
        }

        private bool IsContainsAllElements(IMathSet<T> set, IEnumerable<T> elements)
        {
            var setElements = set.GetElements().ToList();
            return elements.All(e => setElements.Contains(e));
        }
    }
}