using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Comparers;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Reflections
{
    public class SelectReflectionCompositionTaskGenerator: VariantsGenerator
    {
        private readonly ISetGenerator<int> _setGenerator;
        private readonly ISetComparer<int> _setComparer = new MathSetComparer<int>();
        private readonly ReflectionGenerator _reflectionGenerator;
        private readonly ReflectionWriter _reflectionWriter = new ReflectionWriter();
        private readonly Random _random;
        
        public SelectReflectionCompositionTaskGenerator(ISetWriter setWriter, ISetGenerator<int> setGenerator, Random random) : base(TaskIds.SelectReflectionComposition, 1, setWriter)
        {
            _setGenerator = setGenerator;
            _random = random;
            _reflectionGenerator = new ReflectionGenerator(random) {MaxCoefficientValue = 5, MinCoefficientValue = -5, MaxFreeCoefficientValue = 10, MinFreeCoefficientValue = -10};
            Add(_reflectionGenerator);
        }

        public override ITask Generate()
        {
            var set = _setGenerator.Generate(_random.GetRandomName());
            var firstReflection = _reflectionGenerator.Generate();
            var secondReflection = _reflectionGenerator.Generate();
            var answerSetElements =
                secondReflection.GetElements(firstReflection.GetElements(set.GetElements())).ToList();
            var condition = GetCondition(set, firstReflection, secondReflection);
            var answerSet = new MathSet<int>(_random.GetRandomName(), answerSetElements);

            var variants = new List<IMathSet<int>> {answerSet};

            while (variants.Count < VariantsCount)
            {
                var firstRef = _reflectionGenerator.Generate();
                var secondRef = _reflectionGenerator.Generate();
                var elements = secondRef.GetElements(firstRef.GetElements(set.GetElements())).ToList();
                var variantSet = new MathSet<int>(_random.GetRandomName(), elements);
                if (!variants.Any(v => _setComparer.IsEquals(variantSet, v)))
                    variants.Add(variantSet);
            }
            
            return new VariantsTask<IMathSet<int>>(answerSet, condition, variants);
        }

        private string GetCondition(IMathSet<int> set, Reflection first, Reflection second)
        {
            var firstReflection = _reflectionWriter.CreateReflectionString(first);
            var secondReflection = _reflectionWriter.CreateReflectionString(second, "g");
            return $"Дано множество {WriteSet(set)} и отображения {firstReflection} и {secondReflection}. " +
                   $"Выберите из списка вариантов образ множества {set.Name}, полученное с помощью композиции f{Symbols.Composition}g";
        }
    }
}