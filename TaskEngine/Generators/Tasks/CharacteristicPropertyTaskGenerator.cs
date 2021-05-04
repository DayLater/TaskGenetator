using System;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public class CharacteristicPropertyTaskGenerator: VariantsGenerator<CharacteristicPropertySetAnswerTask>
    {
        private readonly ExpressionSetGenerator _expressionSetGenerator;
        private readonly Random _random;

        public CharacteristicPropertyTaskGenerator(ExpressionSetGenerator expressionSetGenerator, Random random) : base(TaskIds.CharacteristicPropertyTask)
        {
            _expressionSetGenerator = expressionSetGenerator;
            _random = random;
            Add(_expressionSetGenerator);
        }

        public override CharacteristicPropertySetAnswerTask Generate()
        {
            var variants = _expressionSetGenerator.Generate(VariantsCount);
            var rightAnswerIndex = _random.Next(0, variants.Count);
            var rightAnswer = variants[rightAnswerIndex];
            return new CharacteristicPropertySetAnswerTask(rightAnswer, variants); 
        }
    }
}