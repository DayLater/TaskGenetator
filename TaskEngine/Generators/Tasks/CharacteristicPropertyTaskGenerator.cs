using System;
using System.Collections.Generic;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Sets;
using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public class CharacteristicPropertyTaskGenerator: VariantsGenerator<VariantsCharacteristicPropertyTask>
    {
        private readonly ExpressionSetGenerator _expressionSetGenerator;
        private readonly Random _random;

        public CharacteristicPropertyTaskGenerator(ExpressionSetGenerator expressionSetGenerator, Random random) : base(TaskIds.CharacteristicPropertyTask, 1)
        {
            _expressionSetGenerator = expressionSetGenerator;
            _random = random;
            Add(_expressionSetGenerator);
        }

        public override VariantsCharacteristicPropertyTask Generate()
        {
            var variants = _expressionSetGenerator.Generate(VariantsCount);
            var rightAnswerIndex = _random.Next(0, variants.Count);
            var rightAnswer = variants[rightAnswerIndex];
            return new VariantsCharacteristicPropertyTask(new List<IMathSet<int>> {rightAnswer}, variants); 
        }
    }
}