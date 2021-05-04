using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Comparers;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Sets;
using TaskEngine.Tasks.Elements;
using TaskEngine.Values;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class SetContainElementTaskGenerator: SeveralAnswersGenerator<SetContainElementsTask>
    {
        private readonly IntMathSetGenerator _setGenerator = new IntMathSetGenerator();
        private readonly ISetComparer<IMathSet<int>> _setComparer = new IntMathSetComparer();
        private readonly Random _random = new Random();
        
        public SetContainElementTaskGenerator(string id, int variantCount = 4, int answerCount = 1, int elementsCount = 1) : base(id, variantCount, answerCount)
        {
            Add(new ImmutableIntValue(ValuesIds.ElementsCount, elementsCount));
        }

        public override SetContainElementsTask Generate()
        {
            var set = _setGenerator.Generate();
            var elements = set.GetElements().ToList();
            
            var taskElements = new List<int>();
            var elementCount = Get<ImmutableIntValue>(ValuesIds.ElementsCount).Value;
            while (taskElements.Count < elementCount)
            {
                var elementIndex = _random.Next(0, elements.Count);
                var element = elements[elementIndex];
                if (!taskElements.Contains(element))
                    taskElements.Add(element);
            }

            var answers = new List<IMathSet<int>> {set};
            while (answers.Count < AnswersCount - 1)
            {
                var answerSet = _setGenerator.Generate(new List<int>(), taskElements.ToArray());
                if (!answers.Any(s => _setComparer.IsEquals(s, answerSet)))
                    answers.Add(answerSet);
            }

            var variants = new List<IMathSet<int>>(answers);
            while (variants.Count < VariantsCount)
            {
                var variantSet = _setGenerator.Generate(taskElements);
                if (!variants.Any(v => _setComparer.IsEquals(v, variantSet)))
                    variants.Add(variantSet);
            }

            return new SetContainElementsTask(taskElements, variants, answers);
        }
    }
}