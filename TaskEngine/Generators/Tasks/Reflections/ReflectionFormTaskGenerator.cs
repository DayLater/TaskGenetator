using System;
using System.Collections.Generic;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Values;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Reflections
{
    public class ReflectionFormTaskGenerator: Valued
    {
        private readonly ISetWriter _setWriter;
        private readonly ReflectionWriter _reflectionWriter = new ReflectionWriter();
        private readonly ISetGenerator<int> _setGenerator;
        private readonly ReflectionGenerator _reflectionGenerator;
        private readonly Random _random;

        public ReflectionFormTaskGenerator(ISetWriter setWriter, ISetGenerator<int> setGenerator, Random random)
        {
            _setWriter = setWriter;
            _setGenerator = setGenerator;
            _random = random;
            _reflectionGenerator = new ReflectionGenerator(random);
            Add(_reflectionGenerator);
        }

        public (IMathSet<int> set, Reflection reflection, IMathSet<int> answer) Generate()
        {
            var set = _setGenerator.Generate(_random.GetRandomName());
            var reflection = _reflectionGenerator.Generate();
            var answer = reflection.GetElements(set.GetElements());
            return (set, reflection, new MathSet<int>(_random.GetRandomName(), answer));
        }

        public string GetCondition(bool isVariants, IMathSet<int> set, Reflection reflection)
        {
            var condition = $"Дано множество {_setWriter.Write(set)} и отображение {_reflectionWriter.CreateReflectionString(reflection)}. ";
            var action = isVariants ? "Выберите" : "Укажите";
            return condition + action + " образ данного множества при данном отображении";
        }
    }
}