using System;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Helpers;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.SetOperations
{
    public class VariantsSetOperationTaskGenerator<T>: VariantsGenerator
    {
        private readonly ISetGenerator<T> _setGenerator;
        private readonly Random _random;
        private readonly ISetVariantGenerator<T> _variantsGenerator;
        
        private readonly SetOperation _setOperation;
        private readonly IOperationSetGenerator<T> _operationSetGenerator;
        
        public VariantsSetOperationTaskGenerator(string id, SetOperation setOperation, IOperationSetGenerator<T> operationSetGenerator, ISetVariantGenerator<T> variantsGenerator, ISetGenerator<T> setGenerator, Random random, ISetWriter setWriter)
            : base(id, 1, setWriter)
        {
            _variantsGenerator = variantsGenerator;
            _setGenerator = setGenerator;
            _random = random;
            _setOperation = setOperation;
            _operationSetGenerator = operationSetGenerator;
            Add(_operationSetGenerator);
            Add(_variantsGenerator);
            Add(_setGenerator);
        }

        public override ITask Generate()
        {
            var name = _random.GetRandomName();
            var answerSet = _setGenerator.Generate(name);
            var (firstSet, secondSet) = _operationSetGenerator.Generate(answerSet);

            var variants = _variantsGenerator.Generate(answerSet, VariantsCount - 1).ToList();
            variants.Add(answerSet);
            
            var condition = GetCondition(firstSet, secondSet, _setOperation);
            return new VariantsTask<IMathSet<T>>(answerSet, condition, variants);
        }

        private string GetCondition(IMathSet<T> first, IMathSet<T> second, SetOperation setOperation)
        {
            var firstSet = WriteSet(first);
            var secondSet = WriteSet(second);
            var operation = SetOperationHelper.GetString(setOperation);
            return $"Выберите из списка вариантов {operation} множеств {firstSet} и {secondSet}";
        }
    }
}