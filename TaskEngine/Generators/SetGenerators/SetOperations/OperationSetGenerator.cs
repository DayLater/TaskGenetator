using System;
using TaskEngine.Extensions;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Values;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public abstract class OperationSetGenerator<T>: Valued, IOperationSetGenerator<T>
    {
        private readonly Random _random;

        protected OperationSetGenerator(Random random)
        {
            _random = random;
        }

        public (IMathSet<T>, IMathSet<T>) Generate(IMathSet<T> answerSet)
        {
            var firstName = _random.GetRandomName();
            var secondName = _random.GetRandomName();
            return CreateSets(firstName, secondName, answerSet);
        }

        protected abstract (IMathSet<T>, IMathSet<T>) CreateSets(string firstName, string secondName, IMathSet<T> answerSet);
    }
}