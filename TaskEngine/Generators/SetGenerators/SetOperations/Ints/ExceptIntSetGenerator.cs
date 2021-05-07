﻿using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Values;

namespace TaskEngine.Generators.SetGenerators.SetOperations.Ints
{
    public class ExceptIntSetGenerator: ExceptSetGenerator<int>
    {
        private readonly IntValue _delta = new IntValue(ValuesIds.BorderDelta) {Value = 5};
        
        public ExceptIntSetGenerator(Random random) : base(random)
        {
            Add(_delta);
        }

        protected override int CreateElement(Random random, IList<int> firstList)
        {
            var max = firstList.Max();
            var min = firstList.Min();
            return random.GetNext(min, max, _delta.Value);
        }
    }
}