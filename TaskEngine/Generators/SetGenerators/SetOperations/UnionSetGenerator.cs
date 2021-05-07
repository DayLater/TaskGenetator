using System;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public class UnionSetGenerator<T>: OperationSetGenerator<T>
    {
        private readonly Random _random;

        public UnionSetGenerator(Random random) : base(random)
        {
            _random = random;
        }

        protected override (IMathSet<T>, IMathSet<T>) CreateSets(string firstName, string secondName, IMathSet<T> answerSet)
        {
            var elements = answerSet.GetElements().ToList();
            var firstSubset = elements.GetListWithRandomElements(elements.Count / 2, _random);
            
            var secondSubset = elements.GetListWithRandomElements(elements.Count / 2, _random);
            var leftElements = elements.Except(firstSubset);
            secondSubset.AddRange(leftElements);

            var first = new MathSet<T>(firstName, firstSubset);
            var second = new MathSet<T>(secondName, secondSubset);
            return ChangePosition(first, second);
        }

        private (IMathSet<T>, IMathSet<T>) ChangePosition(IMathSet<T> first, IMathSet<T> second)
        {
            var isMix = _random.GetBool();
            return isMix ? (second, first) : (first, second);
        }
    }
}