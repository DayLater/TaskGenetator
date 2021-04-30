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
    public class BorderSetOperationTaskGenerator: ITaskGenerator<BorderSetOperationSetAnswerTask>
    {
        public int VariantCount { get; set; } = 4;

        private readonly IntBorderSetGenerator _generator;
        private readonly SetVariantsGeneratorByCorrect _variantsGenerator;
        private readonly Dictionary<SetOperation, IOperationSetGenerator> _setGenerators = new Dictionary<SetOperation, IOperationSetGenerator>();
        
        public BorderSetOperationTaskGenerator(SetVariantsGeneratorByCorrect variantsGenerator, IntBorderSetGenerator generator, Random random)
        {
            _variantsGenerator = variantsGenerator;
            _generator = generator;
            AddSetGenerator(SetOperation.Union, new UnionSetGenerator(random));
            AddSetGenerator(SetOperation.Intersect, new IntersectSetGenerator(random));
            AddSetGenerator(SetOperation.Except, new ExceptSetGenerator(random));
        }

        public BorderSetOperationSetAnswerTask Generate()
        {
            var answerSet = _generator.Generate();
            var operation = SetOperationHelper.GetRandomSetOperation();
            var (firstSet, secondSet) = _setGenerators[operation].Generate(answerSet);

            var variants = _variantsGenerator.Generate(answerSet, VariantCount).Cast<IMathSet<int>>().ToList();
            variants.Add(answerSet);
            variants = variants.ShuffleToList();
            return new BorderSetOperationSetAnswerTask(answerSet, variants, firstSet, secondSet,  operation);
        }

        private void AddSetGenerator(SetOperation operation, IOperationSetGenerator generator) => _setGenerators.Add(operation, generator);
    }
}