﻿using System;
using TaskEngine.Extensions;
using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public class ExceptSetGenerator: IOperationSetGenerator
    {
        private readonly Random _random;

        public ExceptSetGenerator(Random random)
        {
            _random = random;
        }

        public (IntBorderedSet, IntBorderedSet) Generate(IntBorderedSet answerSet)
        {
            var isFromStart = _random.GetBool();
            return isFromStart ? GenerateFromStart(answerSet) : GenerateFromEnd(answerSet);
        }

        private (IntBorderedSet, IntBorderedSet) GenerateFromStart(IntBorderedSet answerSet)
        {
            var startBorder = answerSet.Start;
            var exceptEndBorderType = BorderHelper.GetAnotherBorder(startBorder.BorderType);
            var exceptEndBorder = new SetBorder<int>(startBorder.Value, exceptEndBorderType);

            var exceptStartBorderValue = _random.Next(startBorder.Value - 20, startBorder.Value);
            var exceptStartBorderType = BorderHelper.GetRandomBorderType();
            var exceptStartBorder = new SetBorder<int>(exceptStartBorderValue, exceptStartBorderType);

            var exceptName = Symbols.GetRandomName();
            var exceptSet = new IntBorderedSet(exceptName, exceptStartBorder, exceptEndBorder);

            var firstSetEndBorder = answerSet.End.Clone();
            var firstSetStartBorderValue = _random.Next(exceptStartBorderValue + 1, startBorder.Value);
            var firstSetStartBorderType = BorderHelper.GetRandomBorderType();
            var firstSetStartBorder = new SetBorder<int>(firstSetStartBorderValue, firstSetStartBorderType);
            var firstName = Symbols.GetRandomName(exceptName);
            var firstSet = new IntBorderedSet(firstName, firstSetStartBorder, firstSetEndBorder);

            return (firstSet, exceptSet);
        }
        
        private (IntBorderedSet, IntBorderedSet) GenerateFromEnd(IntBorderedSet answerSet)
        {
            var endBorder = answerSet.End;
            var exceptStartBorderType = BorderHelper.GetAnotherBorder(endBorder.BorderType);
            var exceptStartBorder = new SetBorder<int>(endBorder.Value, exceptStartBorderType);

            var exceptEndBorderValue = _random.Next(endBorder.Value + 1, endBorder.Value + 20);
            var exceptEndBorderType = BorderHelper.GetRandomBorderType();
            var exceptEndBorder = new SetBorder<int>(exceptEndBorderValue, exceptEndBorderType);
            
            var exceptName = Symbols.GetRandomName();
            var exceptSet = new IntBorderedSet(exceptName, exceptStartBorder, exceptEndBorder);

            var firstSetStartBorder = answerSet.Start.Clone();
            var firstSetEndBorderValue = _random.Next(endBorder.Value + 1, exceptEndBorderValue);
            var firstSetEndBorderType = BorderHelper.GetRandomBorderType();
            var firstSetEndBorder = new SetBorder<int>(firstSetEndBorderValue, firstSetEndBorderType);
            var firstName = Symbols.GetRandomName(exceptName);
            var firstSet = new IntBorderedSet(firstName, firstSetStartBorder,  firstSetEndBorder);

            return (firstSet, exceptSet);
        }
    }
}