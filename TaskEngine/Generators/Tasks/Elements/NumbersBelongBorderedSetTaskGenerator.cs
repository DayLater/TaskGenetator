using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Values;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class NumbersBelongBorderedSetTaskGenerator: SeveralAnswersGenerator<NumbersBelongSetTask>
    {
        private readonly IntBorderSetGenerator _setGenerator = new IntBorderSetGenerator();
        private readonly Random _random = new Random();

        public NumbersBelongBorderedSetTaskGenerator() : base(TaskIds.NumbersBelongBorderedSetTask)
        {
            Add(_setGenerator);
        }

        public override NumbersBelongSetTask Generate()
        {
            var set = _setGenerator.Generate();
            var elements = set.GetElements().ToList();
            var startValue = set.Start.BorderType == BorderType.Close? set.Start.Value: set.Start.Value + 1;
            var endValue = set.End.BorderType == BorderType.Close? set.End.Value + 1: set.End.Value;

            var answers = new List<int>();
            var answerCount = Get<IntValue>(ValuesIds.AnswersCount).Value;
            while (answers.Count < answerCount)
            {
                var answer = _random.Next(startValue, endValue);
                if (!answers.Contains(answer))
                    answers.Add(answer);
            }

            var variants = new List<int>(answers);
            var variantsCount = Get<IntValue>(ValuesIds.VariantsCount).Value;
            while (variants.Count < variantsCount)
            {
                var variant = _random.Next(startValue - elements.Count - variantsCount, endValue + elements.Count + variantsCount);
                if (!elements.Contains(variant) && !variants.Contains(variant))
                    variants.Add(variant);
            }

            return new NumbersBelongSetTask(answers, variants, set);
        }
    }
}