﻿using System;
using TaskEngine.Extensions;
using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public class UnionSetGenerator : OperationSetGenerator
    {
        private readonly Random _random;

        public UnionSetGenerator(Random random) : base(random)
        {
            _random = random;
        }

        private (IntBorderedSet, IntBorderedSet) GenerateOneInOther(string firstName, string secondName, IntBorderedSet answerSet)
        {
            var firstSet = new IntBorderedSet(firstName, answerSet.Start.Clone(), answerSet.End.Clone());

            var length = answerSet.End.Value - answerSet.Start.Value;
            
            var startValue = _random.Next(answerSet.Start.Value, answerSet.Start.Value + length / 2);
            var startBorderType = _random.GetRandomBorderType();
            var startBorder = new SetBorder<int>(startValue, startBorderType);
            
            var endValue = _random.Next(answerSet.End.Value - length / 2 + 1, answerSet.End.Value);
            var endBorderType = _random.GetRandomBorderType();
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
            var firstSetEndBorderType = _random.GetRandomBorderType();
            var firstSetEndBorder = new SetBorder<int>(firstSetEndBorderValue, firstSetEndBorderType);
            var firstSet = new IntBorderedSet(firstName, firstSetStartBorder, firstSetEndBorder);

            var secondSetEndBorder = end.Clone();
            var secondSetStartBorderValue = _random.Next(start.Value + 1, firstSetEndBorderValue);
            var secondSetStartBorderType = _random.GetRandomBorderType();
            var secondSetStartBorder = new SetBorder<int>(secondSetStartBorderValue, secondSetStartBorderType);
            var secondSet = new IntBorderedSet(secondName, secondSetStartBorder, secondSetEndBorder);

            return (firstSet, secondSet);
        }

        protected override (IMathSet<T>, IMathSet<T>) CreateSets<T>(string firstName, string secondName, IMathSet<T> answerSet)
        {
            var set = (IntBorderedSet) answerSet;
            var isOneInOther = _random.GetBool();
            var (firstIntSet, secondIntSet) = isOneInOther ? GenerateOneInOther(firstName, secondName, set) 
                : GenerateOnIntersect(firstName, secondName, set);
            
            return ((IMathSet<T>) firstIntSet, (IMathSet<T>) secondIntSet);
        }
    }
}