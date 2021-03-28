﻿using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public class IntBorderSetOperationTaskGenerator: ITaskGenerator<BorderSetOperationTask>
    {
        public int VariantCount { get; set; } = 4;
        
        private readonly IntBorderSetGenerator _generator = new IntBorderSetGenerator();
        private readonly SetVariantsGeneratorByCorrect _variantsGenerator;
        private readonly Dictionary<SetOperation, IOperationSetGenerator> _setGenerators = new Dictionary<SetOperation, IOperationSetGenerator>();
        
        public IntBorderSetOperationTaskGenerator(SetVariantsGeneratorByCorrect variantsGenerator)
        {
            _variantsGenerator = variantsGenerator;
        }

        public BorderSetOperationTask Generate()
        {
            var answerSet = _generator.Generate();
            var operation = SetOperationHelper.GetRandomSetOperation();

            var (firstSet, secondSet) = _setGenerators[operation].Generate(answerSet);

            var variants = _variantsGenerator.Generate(answerSet, VariantCount).ToList();
            variants.Add(answerSet);
            variants = variants.ShuffleToList();
            return new BorderSetOperationTask(firstSet, secondSet, answerSet, variants, operation);
        }
        
        public void AddSetGenerator(SetOperation operation, IOperationSetGenerator generator) =>
            _setGenerators.Add(operation, generator);
    }
}