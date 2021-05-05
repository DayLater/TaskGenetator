using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks.Elements;
using TaskEngine.Values;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class SymbolsBelongSetTaskGenerator: VariantsGenerator<SymbolsBelongSetTask>
    {
        private readonly Random _random;
        private readonly SymbolMathSetGenerator _setGenerator;

        public SymbolsBelongSetTaskGenerator(Random random, string id, int answerCount) : base(id, answerCount)
        {
            _random = random;
            _setGenerator = new SymbolMathSetGenerator(random);
            Add(_setGenerator);
        }
        
        public override SymbolsBelongSetTask Generate()
        {
            var set = _setGenerator.Generate();
            var elements = set.GetElements().ToList();

            var answers = new List<string>();
            while (answers.Count < AnswersCount)
            {
                var elementIndex = _random.Next(0, elements.Count);
                var element = elements[elementIndex];
                if (!answers.Contains(element))
                    answers.Add(element);
            }

            var variants = new List<string>(answers);
            while (variants.Count < VariantsCount)
            {
                var element = Symbols.GetRandomElementSymbol(_random, elements.ToArray());
                if (!variants.Contains(element))
                    variants.Add(element);
            }

            return new SymbolsBelongSetTask(answers, variants,  set);
        }
    }
}