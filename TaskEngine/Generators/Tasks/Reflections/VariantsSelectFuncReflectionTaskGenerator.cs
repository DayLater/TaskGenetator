using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Reflections
{
    public class VariantsSelectFuncReflectionTaskGenerator: VariantsGenerator
    {
        private readonly ReflectionGenerator _reflectionGenerator;
        private readonly ISetGenerator<int> _setGenerator;
        private readonly Random _random;
        private readonly bool _isReversed;
        
        public VariantsSelectFuncReflectionTaskGenerator(string id, ISetWriter setWriter, ISetGenerator<int> setGenerator, Random random, bool isReversed) : base(id, 1, setWriter)
        {
            _setGenerator = setGenerator;
            _random = random;
            _isReversed = isReversed;
            _reflectionGenerator = new ReflectionGenerator(random);
            Add(_reflectionGenerator);
        }

        public override ITask Generate()
        {
            var firstSet = _setGenerator.Generate(_random.GetRandomName());
            var reflection = _reflectionGenerator.Generate();
            var reflectedElements = reflection.GetElements(firstSet.GetElements()).ToList();
            var secondSet = new MathSet<int>(_random.GetRandomName(), reflectedElements);

            var variants = new List<Reflection> {reflection};
            while (variants.Count < VariantsCount)
            {
                var variantReflection = _reflectionGenerator.Generate();
                if (!variants.Any(v => v.IsEquals(variantReflection)))
                    variants.Add(variantReflection);
            }

            var condition = _isReversed? CreateCondition(secondSet, firstSet): CreateCondition(firstSet, secondSet);
            return new VariantsTask<Reflection>(reflection, condition, variants);
        }

        private string CreateCondition(IMathSet<int> firstSet, IMathSet<int> secondSet)
        {
            var condition = $"Дано отображение f: {firstSet.Name} -> {secondSet.Name}, где {WriteSet(firstSet)} и {WriteSet(secondSet)}.\n"; 
            return _isReversed? condition + "Выберите из списка вариантов формульный вид отображения, обратного данному"
                : condition + "Выберите из списка вариантов формульный вид данного отображения.";
        }
    }
}