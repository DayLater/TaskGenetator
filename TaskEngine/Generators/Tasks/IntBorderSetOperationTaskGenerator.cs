using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Sets;
using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public class IntBorderSetOperationTaskGenerator: ITaskGenerator<BorderSetOperationTask>
    {
        public int VariantCount { get; set; } = 4;

        private readonly IntBorderSetGenerator _generator;
        private readonly SetVariantsGeneratorByCorrect _variantsGenerator;
        private readonly Dictionary<SetOperation, IOperationSetGenerator> _setGenerators = new Dictionary<SetOperation, IOperationSetGenerator>();
        
        public IntBorderSetOperationTaskGenerator(SetVariantsGeneratorByCorrect variantsGenerator, IntBorderSetGenerator generator)
        {
            _variantsGenerator = variantsGenerator;
            _generator = generator;
        }

        public BorderSetOperationTask Generate()
        {
            var answerSet = _generator.Generate();
            var operation = SetOperationHelper.GetRandomSetOperation();
            var (firstSet, secondSet) = _setGenerators[operation].Generate(answerSet);

            var variants = _variantsGenerator.Generate(answerSet, VariantCount).Cast<IMathSet<int>>().ToList();
            variants.Add(answerSet);
            variants = variants.ShuffleToList();
            return new BorderSetOperationTask(answerSet, variants, firstSet, secondSet,  operation);
        }
        
        public void AddSetGenerator(SetOperation operation, IOperationSetGenerator generator) =>
            _setGenerators.Add(operation, generator);
    }
}