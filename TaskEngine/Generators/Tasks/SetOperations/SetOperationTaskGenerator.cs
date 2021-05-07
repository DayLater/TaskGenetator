using System;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Helpers;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.SetOperations
{
    public class SetOperationTaskGenerator<T> : TaskGenerator
    {
        private readonly Random _random;
        private readonly ISetGenerator<T> _setGenerator;
        private readonly IOperationSetGenerator<T> _operationSetGenerator;
        private readonly SetOperation _setOperation;
        
        public SetOperationTaskGenerator(string id, IOperationSetGenerator<T> operationSetGenerator, SetOperation setOperation, ISetWriter setWriter, Random random, ISetGenerator<T> setGenerator) : base(id, setWriter)
        {
            _random = random;
            _setGenerator = setGenerator;
            _operationSetGenerator = operationSetGenerator;
            _setOperation = setOperation;
            
            Add(_operationSetGenerator);
            Add(_setGenerator);
        }

        public override ITask Generate()
        {
            var name = _random.GetRandomName();
            var answerSet = _setGenerator.Generate(name);
            var (firstSet, secondSet) = _operationSetGenerator.Generate(answerSet);
            var condition = GetCondition(firstSet, secondSet, _setOperation);
            _random.ClearNames();
            return new AnswerTask<IMathSet<T>>(answerSet, condition);
        }

        private string GetCondition(IMathSet<T> first, IMathSet<T> second, SetOperation setOperation)
        {
            var firstSet = WriteSet(first);
            var secondSet = WriteSet(second);
            var operation = SetOperationHelper.GetString(setOperation);
            return $"Найдите {operation} множеств {firstSet} и {secondSet}";
        }
    }
}