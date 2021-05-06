using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Comparers;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Values;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class SetContainElementTaskGenerator: VariantsGenerator
    {
        private readonly IntMathSetGenerator _setGenerator;
        private readonly ISetComparer<IMathSet<int>> _setComparer = new IntMathSetComparer();
        private readonly Random _random;
        
        public SetContainElementTaskGenerator(string id, Random random, ISetWriter setWriter, int answerCount = 1, int elementsCount = 1) 
            : base(id, answerCount, setWriter)
        {
            _random = random;
            _setGenerator = new IntMathSetGenerator(random);
            Add(new IntValue(ValuesIds.ElementsCount) {Value = elementsCount});
        }

        public override ITask Generate()
        {
            var set = _setGenerator.Generate();
            var elementCount = Get<IntValue>(ValuesIds.ElementsCount).Value;
            var taskElements =  set.GetElements().ToList().GetListWithRandomElements(elementCount, _random);

            var answers = new List<IMathSet<int>> {set};
            while (answers.Count < AnswersCount)
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

            var condition = GetCondition(taskElements, answers);
            return new SetContainElementsTask(answers, condition, variants, taskElements);
        }

        private string GetCondition(ICollection<int> elements, ICollection<IMathSet<int>> sets)
        {
            var writtenSets = sets.Count == 1 ? "множество" : "множества";
            var writtenElements = elements.Count == 1 ? "присутсвует элемент" : "присутствуют элементы";
            return $"Выберите {writtenSets}, в котором {writtenElements} {elements.GetStringRepresentation()}";
        }
    }
}