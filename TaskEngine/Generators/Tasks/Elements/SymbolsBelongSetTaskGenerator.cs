using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class SymbolsBelongSetTaskGenerator: ElementBelongSetTaskGenerator
    {
        private readonly Random _random;
        private readonly SymbolMathSetGenerator _setGenerator;

        public SymbolsBelongSetTaskGenerator(Random random, string id, int answerCount, ISetWriter setWriter) 
            : base(id, answerCount, setWriter)
        {
            _random = random;
            _setGenerator = new SymbolMathSetGenerator(random);
            Add(_setGenerator);
        }
        
        public override ITask Generate()
        {
            var name = Symbols.GetRandomName(_random);
            var set = _setGenerator.Generate(name);
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

            var condition = GetCondition(answers, set);
            return new SymbolsBelongSetTask(answers, condition, variants,  set);
        }
    }
}