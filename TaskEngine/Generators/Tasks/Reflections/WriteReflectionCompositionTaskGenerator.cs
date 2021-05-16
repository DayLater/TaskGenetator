using System;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Reflections
{
    public class WriteReflectionCompositionTaskGenerator: TaskGenerator
    {
        private readonly ISetGenerator<int> _setGenerator;
        private readonly ReflectionGenerator _reflectionGenerator;
        private readonly ReflectionWriter _reflectionWriter = new ReflectionWriter();
        private readonly Random _random;
        
        public WriteReflectionCompositionTaskGenerator(ISetWriter setWriter, ISetGenerator<int> setGenerator, Random random) : base(TaskIds.WriteReflectionComposition, setWriter)
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
            var answerSetElements = secondReflection.GetElements(firstReflection.GetElements(set.GetElements())).ToList();
            var condition = GetCondition(set, firstReflection, secondReflection);
            var answerSet = new MathSet<int>(_random.GetRandomName(), answerSetElements);
            return new AnswerTask<IMathSet<int>>(answerSet, condition);
        }

        private string GetCondition(IMathSet<int> set, Reflection first, Reflection second)
        {
            var firstReflection = _reflectionWriter.CreateReflectionString(first);
            var secondReflection = _reflectionWriter.CreateReflectionString(second, "g");
            return $"Дано множество {WriteSet(set)} и отображения {firstReflection} и {secondReflection}. " +
                   $"Найдите множество, полученное с помощью композиции f{Symbols.Composition}g";
        }
    }
}