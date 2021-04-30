using System;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public class CharacteristicPropertyTaskGenerator: ITaskGenerator<CharacteristicPropertySetAnswerTask>
    {
        private readonly ExpressionSetGenerator _expressionSetGenerator;
        private readonly Random _random;

        public CharacteristicPropertyTaskGenerator(ExpressionSetGenerator expressionSetGenerator, Random random)
        {
            _expressionSetGenerator = expressionSetGenerator;
            _random = random;
        }

        public int MinCoefficientValue
        {
            get => _expressionSetGenerator.Min;
            set => _expressionSetGenerator.Min = value;
        }

        public int MaxCoefficientValue
        {
            get => _expressionSetGenerator.Max;
            set => _expressionSetGenerator.Max = value;
        }

        public int VariantsCount { get; set; } = 4;
        
        public CharacteristicPropertySetAnswerTask Generate()
        {
            var variants = _expressionSetGenerator.Generate(VariantsCount);
            var rightAnswerIndex = _random.Next(0, variants.Count);
            var rightAnswer = variants[rightAnswerIndex];
            return new CharacteristicPropertySetAnswerTask(rightAnswer, variants); 
        }
    }
}