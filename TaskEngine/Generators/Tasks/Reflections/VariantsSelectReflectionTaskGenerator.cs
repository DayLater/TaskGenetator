using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models;
using TaskEngine.Models.Tasks;
using TaskEngine.Models.Values;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Reflections
{
    public class VariantsSelectReflectionTaskGenerator<T>: VariantsGenerator
    {
        private readonly ISetGenerator<T> _setGenerator;
        private readonly Random _random;
        private readonly IntValue _elementCount = new IntValue(ValuesIds.ElementsCount) {Value = 4, MinValue = 2};
        
        public VariantsSelectReflectionTaskGenerator(string id, int answerCount, ISetWriter setWriter, Random random, ISetGenerator<T> setGenerator) : base(id, answerCount, setWriter)
        {
            _random = random;
            _setGenerator = setGenerator;
        }

        public override ITask Generate()
        {
            var firstSet = _setGenerator.Generate(_random.GetRandomName());
            var secondSet = _setGenerator.Generate(_random.GetRandomName());

            var product = new CartesianProduct<T>(firstSet, secondSet);
            var elements = product.GetElements().ToArray();

            var elementAnswers = new List<List<(T, T)>>();
            while (elementAnswers.Count < AnswersCount)
            {
                var answer = GetAnswer(elements);
                if (!elementAnswers.Any(a => a.SetEquals(answer)))
                    elementAnswers.Add(answer);
            }

            var elementVariants = new List<List<(T, T)>>(elementAnswers);
            while (elementVariants.Count < VariantsCount)
            {
                var variant = GetVariant(elements);
                if (!elementVariants.Any(a => a.SetEquals(variant)))
                    elementVariants.Add(variant);
            }

            var variants = elementVariants.Select(e => new Accordance<T>(e, _random.GetRandomName())).ToList();
            var answers = elementAnswers.Select(a => elementVariants.IndexOf(a)).Select(index => variants[index]).ToList();
            var condition = GetCondition(answers);

            return new VariantsTask<Accordance<T>>(answers, condition, variants);
        }

        private string GetCondition(ICollection<Accordance<T>> answers)
        {
            return answers.Count == 1
                ? "Выберите соответствие, являющееся отображением"
                : "Выберите соответствия, являющиеся отображнием";
        }

        private List<(T, T)> GetVariant(IReadOnlyList<(T, T)> elements)
        {
            var randomIndex = _random.Next(0, elements.Count);
            var firstElement = elements[randomIndex];

            (T, T) second;
            do
            {
                var index = _random.Next(0, elements.Count);
                second = elements[index];
            } while (!second.Item1.Equals(firstElement.Item1));
            
            var result = new List<(T, T)> {firstElement, second};
            while (result.Count < _elementCount.Value)
            {
                var index = _random.Next(0, elements.Count);
                var element = elements[index];
                if (!result.Contains(element))
                    result.Add(element);
            }

            result.Shuffle(_random);
            return result;
        }

        private List<(T, T)> GetAnswer(IReadOnlyList<(T, T)> elements)
        {
            var randomIndex = _random.Next(0, elements.Count);
            var firstElement = elements[randomIndex];
            var result = new List<(T, T)> {firstElement};
            var suitableElements = elements.Where(e => !e.Item1.Equals(firstElement.Item1)).ToList();
            while (result.Count < _elementCount.Value)
            {
                var index = _random.Next(0, suitableElements.Count);
                var element = suitableElements[index];
                if (result.All(c => !c.Item1.Equals(element.Item1)))
                    result.Add(element);
            }

            return result;
        }
    }
}