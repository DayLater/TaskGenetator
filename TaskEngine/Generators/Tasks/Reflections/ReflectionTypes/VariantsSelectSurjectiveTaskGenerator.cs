﻿using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.Accordances;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Reflections.ReflectionTypes
{
    public class VariantsSelectSurjectiveTaskGenerator<T1, T2>: VariantsGenerator
    {
        private readonly ISetGenerator<T1> _firstSetGenerator;
        private readonly ISetGenerator<T2> _secondSetGenerator;
        private readonly SurjectiveGenerator<T1, T2> _surjectiveGenerator;
        private readonly Random _random;
        
        public VariantsSelectSurjectiveTaskGenerator(string id, ISetWriter setWriter, ISetGenerator<T1> firstSetGenerator, ISetGenerator<T2> secondSetGenerator, Random random) : base(id, 1, setWriter)
        {
            _firstSetGenerator = firstSetGenerator;
            _secondSetGenerator = secondSetGenerator;
            _random = random;
            _surjectiveGenerator = new SurjectiveGenerator<T1, T2>(random);
        }
        
        public IMathSet<T1> FirstLastMathSet { get; set; }
        public IMathSet<T2> SecondLastSet { get; set; }
        
        public override ITask Generate()
        {
            FirstLastMathSet = _firstSetGenerator.Generate( _random.GetRandomName());
            SecondLastSet = _secondSetGenerator.Generate(_random.GetRandomName());
            
            var condition = GetCondition(FirstLastMathSet, SecondLastSet);
            
            var firstSetElements = FirstLastMathSet.GetElements().ToList();
            var secondSetElements = SecondLastSet.GetElements().ToList();

            var answer = _surjectiveGenerator.Generate(firstSetElements, secondSetElements);
            var variants = CreateVariants(firstSetElements, secondSetElements);
            variants.Add(answer);

            return new VariantsTask<Accordance<T1, T2>>(answer, condition, variants);
        }

        private List<Accordance<T1, T2>> CreateVariants(IReadOnlyList<T1> firstElements, IReadOnlyList<T2> secondElements)
        {
            var variants = new List<List<(T1, T2)>>();
            while (variants.Count < VariantsCount - 1)
            {
                var variant = new List<(T1, T2)>();
                
                var missedElement = secondElements[_random.Next(0, secondElements.Count)];
                var seconds = new List<T2>(secondElements.Except(new [] {missedElement}));

                foreach (var firstElement in firstElements)
                {
                    var secondElement = seconds[_random.Next(0, seconds.Count)];
                    variant.Add((firstElement, secondElement));
                }
                
                variant.Shuffle(_random);
                
                if (!variants.IsContain(variant))
                    variants.Add(variant);
            }

            return variants.Select(v => new Accordance<T1, T2>(v, _random.GetRandomName())).ToList();
        }

        private string GetCondition(IMathSet<T1> firstSet, IMathSet<T2> secondSet)
        {
            return $"Даны множества {WriteSet(firstSet)} и {WriteSet(secondSet)}. Укажите соответствие, являющееся сюръекцией";
        }
    }
}