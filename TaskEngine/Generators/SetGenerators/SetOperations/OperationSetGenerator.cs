using System;
using TaskEngine.Extensions;
using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public abstract class OperationSetGenerator: IOperationSetGenerator
    {
        private readonly Random _random;

        protected OperationSetGenerator(Random random)
        {
            _random = random;
        }

        public (IMathSet<T>, IMathSet<T>) Generate<T>(IMathSet<T> answerSet)
        {
            var firstName = _random.GetRandomName();
            var secondName = _random.GetRandomName();
            
            _random.ClearNames();
            return CreateSets(firstName, secondName, answerSet);
        }

        protected abstract (IMathSet<T>, IMathSet<T>) CreateSets<T>(string firstName, string secondName, IMathSet<T> answerSet);
    }
}