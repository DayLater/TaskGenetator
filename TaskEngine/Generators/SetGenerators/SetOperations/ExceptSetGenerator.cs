using System;
using System.Security.Cryptography;
using TaskEngine.Extensions;
using TaskEngine.Helpers;
using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public class ExceptSetGenerator: OperationSetGenerator
    {
        private readonly Random _random;

        public ExceptSetGenerator(Random random) : base(random)
        {
            _random = random;
        }
        
        private (IntBorderedSet, IntBorderedSet) GenerateFromStart(IntBorderedSet answerSet)
        {
            var startBorder = answerSet.Start;
            var exceptEndBorderType = BorderHelper.GetAnotherBorder(startBorder.BorderType);
            var exceptEndBorder = new SetBorder<int>(startBorder.Value, exceptEndBorderType);

            var exceptStartBorderValue = _random.Next(startBorder.Value - 20, startBorder.Value);
            var exceptStartBorderType = _random.GetRandomBorderType();
            var exceptStartBorder = new SetBorder<int>(exceptStartBorderValue, exceptStartBorderType);

            var exceptName =_random.GetRandomName();
            var exceptSet = new IntBorderedSet(exceptName, exceptStartBorder, exceptEndBorder);

            var firstSetEndBorder = answerSet.End.Clone();
            var firstSetStartBorderValue = _random.Next(exceptStartBorderValue + 1, startBorder.Value);
            var firstSetStartBorderType = _random.GetRandomBorderType();
            var firstSetStartBorder = new SetBorder<int>(firstSetStartBorderValue, firstSetStartBorderType);
            var firstName = _random.GetRandomName();
            var firstSet = new IntBorderedSet(firstName, firstSetStartBorder, firstSetEndBorder);

            return (firstSet, exceptSet);
        }
        
        private (IntBorderedSet, IntBorderedSet) GenerateFromEnd(IntBorderedSet answerSet)
        {
            var endBorder = answerSet.End;
            var exceptStartBorderType = BorderHelper.GetAnotherBorder(endBorder.BorderType);
            var exceptStartBorder = new SetBorder<int>(endBorder.Value, exceptStartBorderType);

            var exceptEndBorderValue = _random.Next(endBorder.Value + 1, endBorder.Value + 20);
            var exceptEndBorderType = _random.GetRandomBorderType();
            var exceptEndBorder = new SetBorder<int>(exceptEndBorderValue, exceptEndBorderType);
            
            var exceptName = _random.GetRandomName();
            var exceptSet = new IntBorderedSet(exceptName, exceptStartBorder, exceptEndBorder);

            var firstSetStartBorder = answerSet.Start.Clone();
            var firstSetEndBorderValue = _random.Next(endBorder.Value + 1, exceptEndBorderValue);
            var firstSetEndBorderType = _random.GetRandomBorderType();
            var firstSetEndBorder = new SetBorder<int>(firstSetEndBorderValue, firstSetEndBorderType);
            var firstName = _random.GetRandomName();
            var firstSet = new IntBorderedSet(firstName, firstSetStartBorder,  firstSetEndBorder);
            
            return (firstSet, exceptSet);
        }

        protected override (IMathSet<T>, IMathSet<T>) CreateSets<T>(string firstName, string secondName, IMathSet<T> answerSet)
        {
            var set = (IntBorderedSet) answerSet;
            var isFromStart = _random.GetBool();
            var (firstSet, secondSet) =  isFromStart ? GenerateFromStart(set) : GenerateFromEnd(set);
            _random.ClearNames();
            return ((IMathSet<T>) firstSet, (IMathSet<T>) secondSet);
        }
    }
}