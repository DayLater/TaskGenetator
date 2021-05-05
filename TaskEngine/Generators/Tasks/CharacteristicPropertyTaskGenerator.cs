using System;
using System.Collections.Generic;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks
{
    public class CharacteristicPropertyTaskGenerator: VariantsGenerator
    {
        private readonly ExpressionSetGenerator _expressionSetGenerator;
        private readonly Random _random;

        public CharacteristicPropertyTaskGenerator(ExpressionSetGenerator expressionSetGenerator, Random random, ISetWriter setWriter)
            : base(TaskIds.CharacteristicPropertyTask, 1, setWriter)
        {
            _expressionSetGenerator = expressionSetGenerator;
            _random = random;
            Add(_expressionSetGenerator);
        }

        public override ITask Generate()
        {
            var variants = _expressionSetGenerator.Generate(VariantsCount);
            var rightAnswerIndex = _random.Next(0, variants.Count);
            var answer = variants[rightAnswerIndex];
            var condition = $"Дано множество {WriteSet(answer)}.\nУкажите его характеристическое свойство.";
            return new VariantsCharacteristicPropertyTask(answer,  condition, variants); 
        }
    }
}