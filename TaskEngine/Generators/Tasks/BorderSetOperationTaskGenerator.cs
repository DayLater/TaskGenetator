using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Helpers;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks
{
    public class BorderSetOperationTaskGenerator: VariantsGenerator
    {
        private readonly IntBorderSetGenerator _setGenerator;
        private readonly SetVariantsGeneratorByCorrect _variantsGenerator;
        private readonly Dictionary<SetOperation, IOperationSetGenerator> _setGenerators = new Dictionary<SetOperation, IOperationSetGenerator>();
        
        public BorderSetOperationTaskGenerator(SetVariantsGeneratorByCorrect variantsGenerator, IntBorderSetGenerator setGenerator, Random random, ISetWriter setWriter) 
            : base(TaskIds.BorderSetOperationTask, 1, setWriter)
        {
            _variantsGenerator = variantsGenerator;
            _setGenerator = setGenerator;
            Add(_setGenerator);
            
            AddSetGenerator(SetOperation.Union, new UnionSetGenerator(random));
            AddSetGenerator(SetOperation.Intersect, new IntersectSetGenerator(random));
            AddSetGenerator(SetOperation.Except, new ExceptSetGenerator(random));
        }

        public override ITask Generate()
        {
            var answerSet = _setGenerator.Generate();
            var operation = SetOperationHelper.GetRandomSetOperation();
            var (firstSet, secondSet) = _setGenerators[operation].Generate(answerSet);

            var variants = _variantsGenerator.Generate(answerSet, VariantsCount).Cast<IMathSet<int>>().ToList();
            variants.Add(answerSet);
            var condition = GetCondition(firstSet, secondSet, operation);
            return new VariantsBorderSetOperationTask(answerSet, condition, variants, firstSet, secondSet, operation);
        }

        private string GetCondition<T>(IMathSet<T> first, IMathSet<T> second, SetOperation setOperation)
        {
            var firstSet = WriteSet(first);
            var secondSet = WriteSet(second);
            var operation = SetOperationHelper.GetString(setOperation);
            return $"Найдите {operation} множеств {firstSet} и {secondSet}";
        }

        private void AddSetGenerator(SetOperation operation, IOperationSetGenerator generator) => _setGenerators.Add(operation, generator);
    }
}