using System;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;

namespace TaskEngine.Generators.Tasks
{
    public class TaskGenerators
    {
        public CharacteristicPropertyTaskGenerator CharacteristicPropertyTaskGenerator { get; }
        public TestableSubSetTaskGenerator TestableSubSetTaskGenerator { get; }
        public SubSetTaskGenerator SubSetTaskGenerator { get; }
        public IntBorderSetOperationTaskGenerator IntBorderSetOperationTaskGenerator { get; }

        public TaskGenerators(Random random, ExpressionSetGenerator expressionSetGenerator, MathSetGenerator mathSetGenerator, 
            SetVariantsGeneratorByCorrect variantsGeneratorByCorrect, IntBorderSetGenerator intBorderSetGenerator)
        {
            CharacteristicPropertyTaskGenerator = new CharacteristicPropertyTaskGenerator(expressionSetGenerator, random);
            TestableSubSetTaskGenerator = new TestableSubSetTaskGenerator(mathSetGenerator, random);
            SubSetTaskGenerator = new SubSetTaskGenerator(mathSetGenerator);
            
            IntBorderSetOperationTaskGenerator = new IntBorderSetOperationTaskGenerator(variantsGeneratorByCorrect, intBorderSetGenerator);
            IntBorderSetOperationTaskGenerator.AddSetGenerator(SetOperation.Union, new UnionSetGenerator(random));
            IntBorderSetOperationTaskGenerator.AddSetGenerator(SetOperation.Intersect, new IntersectSetGenerator(random));
            IntBorderSetOperationTaskGenerator.AddSetGenerator(SetOperation.Except, new ExceptSetGenerator(random));
        }
    }
}