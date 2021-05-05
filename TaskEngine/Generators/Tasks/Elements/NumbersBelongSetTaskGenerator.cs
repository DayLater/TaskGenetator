using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks.Elements;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class NumbersBelongSetTaskGenerator: VariantsGenerator<NumbersBelongSetTask>
    {
        private readonly IntMathSetGenerator _intMathSetGenerator;
        private readonly Random _random;

        public NumbersBelongSetTaskGenerator(Random random, string id, int answerCount) : base(id, answerCount)
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
            while (answers.Count < AnswersCount)
            {
                var elementIndex = _random.Next(0, elements.Count);
                var answer = elements[elementIndex];
                if (!answers.Contains(answer))
                    answers.Add(answer);
            }

            var variants = new List<int>(answers);
            while (variants.Count < VariantsCount)
            {
                var element = _random.Next(_intMathSetGenerator.MinValue, _intMathSetGenerator.MaxValue);
                if (!variants.Contains(element) && !elements.Contains(element))
                    variants.Add(element);
            }

            return new NumbersBelongSetTask(answers, variants, set);
        }
    }
}