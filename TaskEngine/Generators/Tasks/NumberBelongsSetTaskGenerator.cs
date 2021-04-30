﻿using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks.Elements;

namespace TaskEngine.Generators.Tasks
{
    public class NumberBelongsSetTaskGenerator: IVariantsTaskGenerator<NumberBelongsSetSetAnswerTask>
    {
        private readonly MathSetGenerator _mathSetGenerator = new MathSetGenerator();
        private readonly Random _random = new Random();

        public NumberBelongsSetSetAnswerTask Generate()
        {
            var set = _mathSetGenerator.Generate();
            var elements = set.GetElements().ToList();
            var elementIndex = _random.Next(0, elements.Count);
            var answer = elements[elementIndex];

            var variants = new List<int>() {answer};
            while (variants.Count < VariantCount)
            {
                var element = _random.Next(_mathSetGenerator.MinValue, _mathSetGenerator.MaxValue);
                if (!elements.Contains(element))
                    variants.Add(element);
            }

            return new NumberBelongsSetSetAnswerTask(answer, variants.ShuffleToList(), set);
        }

        public int VariantCount { get; set; } = 4;
    }
}