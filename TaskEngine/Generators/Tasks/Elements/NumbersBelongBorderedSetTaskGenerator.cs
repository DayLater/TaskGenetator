using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class NumbersBelongBorderedSetTaskGenerator: ElementBelongSetTaskGenerator
    {
        private readonly IntBorderSetGenerator _setGenerator;
        private readonly Random _random;

        public NumbersBelongBorderedSetTaskGenerator(Random random, string id, int answerCount, ISetWriter setWriter)
            : base(id, answerCount, setWriter)
        {
            _random = random;
            _setGenerator = new IntBorderSetGenerator(random);
            Add(_setGenerator);
        }

        public override ITask Generate()
        {
            var set = _setGenerator.Generate();
            var elements = set.GetElements().ToList();
            var startValue = set.Start.BorderType == BorderType.Close? set.Start.Value: set.Start.Value + 1;
            var endValue = set.End.BorderType == BorderType.Close? set.End.Value + 1: set.End.Value;

            var answers = new List<int>();
            while (answers.Count < AnswersCount)
            {
                var answer = _random.Next(startValue, endValue);
                if (!answers.Contains(answer))
                    answers.Add(answer);
            }

            var variants = new List<int>(answers);
            while (variants.Count < VariantsCount)
            {
                var variant = _random.Next(startValue - elements.Count - VariantsCount, endValue + elements.Count + VariantsCount);
                if (!elements.Contains(variant) && !variants.Contains(variant))
                    variants.Add(variant);
            }

            var condition = GetCondition(answers, set);
            return new NumbersBelongSetTask(answers, condition, variants, set);
        }
    }
}