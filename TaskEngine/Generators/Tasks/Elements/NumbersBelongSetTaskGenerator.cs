using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Values;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class NumbersBelongSetTaskGenerator: SeveralAnswersGenerator<NumbersBelongSetTask>
    {
        private readonly IntMathSetGenerator _intMathSetGenerator;
        private readonly Random _random;

        public NumbersBelongSetTaskGenerator(Random random) : base(TaskIds.NumbersBelongSetTask)
        {
            _random = random;
            _intMathSetGenerator = new IntMathSetGenerator(random);
            Add(_intMathSetGenerator);
        }
        
        public override NumbersBelongSetTask Generate()
        {
            var set = _intMathSetGenerator.Generate();
            var elements = set.GetElements().ToList();
            
            var answers = new List<int>();
            var answerCount = Get<IntValue>(ValuesIds.AnswersCount).Value;
            while (answers.Count < answerCount)
            {
                var elementIndex = _random.Next(0, elements.Count);
                var answer = elements[elementIndex];
                if (!answers.Contains(answer))
                    answers.Add(answer);
            }

            var variants = new List<int>(answers);
            var variantsCount = Get<IntValue>(ValuesIds.VariantsCount).Value;
            while (variants.Count < variantsCount)
            {
                var element = _random.Next(_intMathSetGenerator.MinValue, _intMathSetGenerator.MaxValue);
                if (!variants.Contains(element) && !elements.Contains(element))
                    variants.Add(element);
            }

            return new NumbersBelongSetTask(answers, variants, set);
        }
    }
}