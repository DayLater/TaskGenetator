﻿using TaskEngine.Generators.Tasks;
using TaskEngine.Values;

namespace TaskEngine.Generators
{
    public abstract class VariantsGenerator: Generator, ITaskGenerator
    {
        protected VariantsGenerator(int variantCount = 4)
        {
            Add(new IntValue(ValuesIds.VariantsCount) {Value = variantCount});
        }
    }
}