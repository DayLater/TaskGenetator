using System;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models.Tasks;
using TaskEngine.Models.Tasks.CharacteristicProperty;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.CharacteristicProperty
{
    public class VariantsCharacteristicPropertyTaskGenerator: VariantsGenerator
    {
        private readonly ExpressionSetGenerator _expressionSetGenerator;
        private readonly Random _random;

        public VariantsCharacteristicPropertyTaskGenerator(ExpressionSetGenerator expressionSetGenerator, Random random, ISetWriter setWriter)
            : base(TaskIds.VariantsCharacteristicPropertyTask, 1, setWriter)
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
            return new VariantsSelectCharacteristicPropertyTask(answer,  condition, variants); 
        }
    }
}