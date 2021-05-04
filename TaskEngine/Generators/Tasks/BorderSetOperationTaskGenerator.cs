using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Helpers;
using TaskEngine.Sets;
using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public class BorderSetOperationTaskGenerator: VariantsGenerator<VariantsBorderSetOperationTask>
    {
        private readonly IntBorderSetGenerator _setGenerator;
        private readonly SetVariantsGeneratorByCorrect _variantsGenerator;
        private readonly Dictionary<SetOperation, IOperationSetGenerator> _setGenerators = new Dictionary<SetOperation, IOperationSetGenerator>();
        
        public BorderSetOperationTaskGenerator(SetVariantsGeneratorByCorrect variantsGenerator, IntBorderSetGenerator setGenerator, Random random) : base(TaskIds.BorderSetOperationTask)
        {
            _variantsGenerator = variantsGenerator;
            _setGenerator = setGenerator;
            Add(_setGenerator);
            
            AddSetGenerator(SetOperation.Union, new UnionSetGenerator(random));
            AddSetGenerator(SetOperation.Intersect, new IntersectSetGenerator(random));
            AddSetGenerator(SetOperation.Except, new ExceptSetGenerator(random));
        }

        public override VariantsBorderSetOperationTask Generate()
        {
            var answerSet = _setGenerator.Generate();
            var operation = SetOperationHelper.GetRandomSetOperation();
            var (firstSet, secondSet) = _setGenerators[operation].Generate(answerSet);

            var variants = _variantsGenerator.Generate(answerSet, VariantsCount).Cast<IMathSet<int>>().ToList();
            variants.Add(answerSet);
            return new VariantsBorderSetOperationTask(answerSet, variants.ShuffleToList(), firstSet, secondSet, operation);
        }

        private void AddSetGenerator(SetOperation operation, IOperationSetGenerator generator) => _setGenerators.Add(operation, generator);
    }
}