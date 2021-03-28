using System;
using TaskEngine.Extensions;
using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public class UnionSetGenerator : IOperationSetGenerator
    {
        private readonly Random _random;

        public UnionSetGenerator(Random random)
        {
            _random = random;
        }
        
        public (IntBorderedSet, IntBorderedSet) Generate(IntBorderedSet answerSet)
        {
            var firstName = Symbols.GetRandomName();
            var secondName = Symbols.GetRandomName(firstName);

            var isOneInOther = _random.GetBool();

            return isOneInOther ? GenerateOneInOther(firstName, secondName, answerSet) 
                : GenerateOnIntersect(firstName, secondName, answerSet);
        }

        private (IntBorderedSet, IntBorderedSet) GenerateOneInOther(string firstName, string secondName, IntBorderedSet answerSet)
        {
            var firstSet = new IntBorderedSet(firstName, answerSet.Start.Clone(), answerSet.End.Clone());

            var length = answerSet.End.Value - answerSet.Start.Value;
            
            var startValue = _random.Next(answerSet.Start.Value, answerSet.Start.Value + length / 2);
            var startBorderType = BorderHelper.GetRandomBorderType();
            var startBorder = new SetBorder<int>(startValue, startBorderType);
            
            var endValue = _random.Next(answerSet.End.Value - length / 2 + 1, answerSet.End.Value);
            var endBorderType = BorderHelper.GetRandomBorderType();
            var endBorder = new SetBorder<int>(endValue, endBorderType);
            
            var secondSet = new IntBorderedSet(secondName, startBorder, endBorder);

            return (firstSet, secondSet);
        }

        private (IntBorderedSet, IntBorderedSet) GenerateOnIntersect(string firstName, string secondName,
            IntBorderedSet answerSet)
        {
            var start = answerSet.Start;
            var end = answerSet.End;
            var length = end.Value - start.Value;
            
            var firstSetStartBorder = start.Clone();
            var addedValue = _random.Next(2, length);
            var firstSetEndBorderValue = start.Value + addedValue;
            var firstSetEndBorderType = BorderHelper.GetRandomBorderType();
            var firstSetEndBorder = new SetBorder<int>(firstSetEndBorderValue, firstSetEndBorderType);
            var firstSet = new IntBorderedSet(firstName, firstSetStartBorder, firstSetEndBorder);

            var secondSetEndBorder = end.Clone();
            var secondSetStartBorderValue = _random.Next(start.Value + 1, firstSetEndBorderValue);
            var secondSetStartBorderType = BorderHelper.GetRandomBorderType();
            var secondSetStartBorder = new SetBorder<int>(secondSetStartBorderValue, secondSetStartBorderType);
            var secondSet = new IntBorderedSet(secondName, secondSetStartBorder, secondSetEndBorder);

            return (firstSet, secondSet);
        }
    }
}