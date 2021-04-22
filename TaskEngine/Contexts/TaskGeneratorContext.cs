﻿using System;
using TaskEngine.Comparers;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Generators.Tasks;

namespace TaskEngine.Contexts
{
    public class TaskGeneratorContext
    {
        public CharacteristicPropertyTaskGenerator CharacteristicPropertyTaskGenerator { get; }
        public VariantsSubSetTaskGenerator VariantsSubSetTaskGenerator { get; }
        public SubSetTaskGenerator SubSetTaskGenerator { get; }
        public IntBorderSetOperationTaskGenerator IntBorderSetOperationTaskGenerator { get; }

        public TaskGeneratorContext(Random random)
        {
            CharacteristicPropertyTaskGenerator = new CharacteristicPropertyTaskGenerator(new ExpressionSetGenerator(), random);
            VariantsSubSetTaskGenerator = new VariantsSubSetTaskGenerator(new MathSetGenerator(), random);
            SubSetTaskGenerator = new SubSetTaskGenerator(new MathSetGenerator());

            var variantsGeneratorByCorrect = new SetVariantsGeneratorByCorrect(random, new IntBorderedSetComparer());
            IntBorderSetOperationTaskGenerator = new IntBorderSetOperationTaskGenerator(variantsGeneratorByCorrect, new IntBorderSetGenerator(), random);
        }
    }
}