using System;
using TaskEngine.Generators;

namespace TaskEngine.Tasks
{
    public class CharacteristicPropertyTaskGenerator
    {
        private readonly ExpressionSetGenerator _expressionSetGenerator = new ExpressionSetGenerator();
        private readonly Random _random = new Random();
        
        public int Min
        {
            get => _expressionSetGenerator.Min;
            set => _expressionSetGenerator.Min = value;
        }

        public int Max
        {
            get => _expressionSetGenerator.Max;
            set => _expressionSetGenerator.Max = value;
        }

        public int CountToGenerate { get; set; } = 4;
        
        public CharacteristicPropertyTask Generate()
        {
            var sets = _expressionSetGenerator.Generate<int>(CountToGenerate);
            var rightAnswerIndex = _random.Next(0, sets.Count);

            return new CharacteristicPropertyTask(sets, rightAnswerIndex); 
        }
    }
}