using System;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Values;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Reflections
{
    public class PrototypeByReflectionTaskGenerator: Valued
    {
        private readonly ISetGenerator<int> _setGenerator;
        private readonly ISetWriter _setWriter;
        private readonly ReflectionGenerator _reflectionGenerator;
        private readonly ReflectionWriter _reflectionWriter = new ReflectionWriter();
        private readonly Random _random;

        public PrototypeByReflectionTaskGenerator(Random random, ISetGenerator<int> setGenerator, ISetWriter setWriter)
        {
            _random = random;
            _setGenerator = setGenerator;
            _setWriter = setWriter;
            _reflectionGenerator = new ReflectionGenerator(random);
            Add(_reflectionGenerator);
        }

        public (IMathSet<int> startSet, Reflection reflection, IMathSet<int> endSet) Generate()
        {
            var set = _setGenerator.Generate(_random.GetRandomName());
            var reflection = _reflectionGenerator.Generate();
            var endSetElements = reflection.GetElements(set.GetElements()).ToList();
            var endSet = new MathSet<int>(_random.GetRandomName(), endSetElements);
            return (set, reflection, endSet);
        }

        public string CreateCondition(IMathSet<int> endSet, Reflection reflection, bool isVariants)
        {
            var action = isVariants ? "Выберите из списка вариантов" : "Укажите";
            return action + $" полный прообраз множества {_setWriter.Write(endSet)} при отображении {_reflectionWriter.CreateReflectionString(reflection)}";
        }
    }
}