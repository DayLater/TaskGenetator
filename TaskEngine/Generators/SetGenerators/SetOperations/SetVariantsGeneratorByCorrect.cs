﻿using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Comparers;
using TaskEngine.Helpers;
using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public class SetVariantsGeneratorByCorrect
    {
        private readonly ISetComparer<int> _setComparer;
        private readonly Random _random;
        private readonly List<IntBorderedSet> _tempVariants = new List<IntBorderedSet>();

        public SetVariantsGeneratorByCorrect(Random random, ISetComparer<int> setComparer)
        {
            _setComparer = setComparer;
            _random = random;
        }

        public IEnumerable<IntBorderedSet> Generate(IntBorderedSet answerSet, int variantCount)
        {
            _tempVariants.Add(answerSet);
            
            for (var i = 0; i < variantCount - 1; i++)
            {
                IntBorderedSet variant;
                do
                {
                    variant = CreateVariant(answerSet);
                } while (ContainsSet(_tempVariants, variant));

                yield return variant;
                _tempVariants.Add(variant);
            }
            
            _tempVariants.Clear();
        }
        
        private IntBorderedSet CreateVariant(IntBorderedSet correct)
        {
            var startValue = correct.Start.Value;
            var startBorderType = correct.Start.BorderType;
            var endValue = correct.End.Value;
            var endBorderType = correct.End.BorderType;
            var changes = _random.Next(1, 3);

            for (int i = 0; i < changes; i++)
            {
                var value = _random.Next(0, 4);
                switch (value)
                {
                    case 0: startValue = GetNewRandomValue(startValue); break;
                    case 1: startBorderType = BorderHelper.GetAnotherBorder(startBorderType); break;
                    case 2: endValue = GetNewRandomValue(endValue); break;
                    case 3: endBorderType = BorderHelper.GetAnotherBorder(endBorderType); break;
                }
            }
            
            var name = Symbols.GetRandomName(_random);
            var startBorder = new SetBorder<int>(startValue, startBorderType);
            var endBorder = new SetBorder<int>(endValue, endBorderType); 
            return new IntBorderedSet(name, startBorder,endBorder);
        }

        private int GetNewRandomValue(int value)
        {
            int newStartValue;
            do
            {
                newStartValue = _random.Next(value - 5, value + 5);
            } while (newStartValue == value);
            return newStartValue;
        }
        
        private bool ContainsSet(IEnumerable<IntBorderedSet> variants, IntBorderedSet set)
        {
            return variants.Any(variant => _setComparer.IsEquals(set, variant));
        }
    }
}