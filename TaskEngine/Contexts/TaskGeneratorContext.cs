﻿using System;
using System.Collections.Generic;
using TaskEngine.Comparers;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Generators.SetGenerators.SetOperations.Ints;
using TaskEngine.Generators.SetGenerators.SetOperations.Symbols;
using TaskEngine.Generators.Tasks;
using TaskEngine.Generators.Tasks.CartesianProducts;
using TaskEngine.Generators.Tasks.CharacteristicProperty;
using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Generators.Tasks.Reflections;
using TaskEngine.Generators.Tasks.Reflections.ReflectionTypes;
using TaskEngine.Generators.Tasks.SetOperations;
using TaskEngine.Generators.Tasks.SubSets;
using TaskEngine.Writers;

namespace TaskEngine.Contexts
{
    public class TaskGeneratorContext
    {
        private readonly Dictionary<string, ITaskGenerator> _idsAndGenerators = new Dictionary<string, ITaskGenerator>();
        
        public TaskGeneratorContext(Random random, ISetWriter setWriter)
        {
            Add(new NumbersBelongSetTaskGenerator(random, TaskIds.NumbersBelongSetTask, 2, setWriter));
            Add(new SymbolsBelongSetTaskGenerator(random, TaskIds.SymbolsBelongSetTask, 2, setWriter));
            Add(new NumbersBelongBorderedSetTaskGenerator(random, TaskIds.NumbersBelongBorderedSetTask, 2, setWriter));
            Add(new SetContainElementTaskGenerator(TaskIds.SetContainsElements, random, setWriter, 2, 3));

            Add(new CharacteristicPropertyTaskGenerator(setWriter, random));
            Add(new VariantsCharacteristicPropertyTaskGenerator(new ExpressionSetGenerator(random), random, setWriter));
            Add(new CharacteristicPropertyElementsTaskGenerator(setWriter, random));
            Add(new VariantsCharacteristicPropertyElementsTaskGenerator(setWriter, random));
            
            Add(new SelectNumbersSubSetTaskGenerator(2, setWriter, random, TaskIds.SelectSeveralNumbersSubSet));
            Add(new SelectSymbolsSubsetTaskGenerator(2, setWriter, random, TaskIds.SelectSeveralSymbolsSubSet));
            Add(new SelectSetBySubsetTaskGenerator<int>(TaskIds.SelectSeveralNumberSetBySubset, 2, setWriter, new IntMathSetGenerator(random), random, new MathSetComparer<int>()));
            Add(new SelectSetBySubsetTaskGenerator<string>(TaskIds.SelectSeveralSymbolSetBySubset, 2, setWriter, new SymbolMathSetGenerator(random), random, new MathSetComparer<string>()));
            Add(new VariantsSubSetTaskGenerator(new IntMathSetGenerator(random), random, setWriter)); 
            Add(new SubSetTaskGenerator(random, setWriter));
            
            Add(new SetEqualsTaskGenerator<int>(TaskIds.NumberSetsEquals, setWriter, new IntMathSetGenerator(random), random, new MathSetComparer<int>()));
            Add(new SetEqualsTaskGenerator<string>(TaskIds.SymbolSetsEquals, setWriter, new SymbolMathSetGenerator(random), random, new MathSetComparer<string>()));

            var intersectIntSetGenerator = new IntMathSetGenerator(random) {MinCount = 4, MaxCount = 6};
            Add(new VariantsSetOperationTaskGenerator<int>(TaskIds.VariantsNumbersSetIntersectOperationTask, SetOperation.Intersect, new IntersectIntSetGenerator(random),new SetVariantGenerator<int>(intersectIntSetGenerator, random), intersectIntSetGenerator, random, setWriter));
            var intersectSymbolSetGenerator = new SymbolMathSetGenerator(random) {MaxCount = 6, MinCount = 4};
            Add(new VariantsSetOperationTaskGenerator<string>(TaskIds.VariantsSymbolsSetIntersectOperationTask, SetOperation.Intersect, new IntersectSymbolSetGenerator(random),new SetVariantGenerator<string>(intersectSymbolSetGenerator, random), intersectSymbolSetGenerator, random, setWriter));
            Add(new VariantsSetOperationTaskGenerator<int>(TaskIds.VariantsBorderSetIntersectOperationTask, SetOperation.Intersect, new IntersectBorderedSetGenerator(random), new BorderedSetVariantsGenerator(random),  new IntBorderSetGenerator(random), random, setWriter));

            var unionIntSetGenerator = new IntMathSetGenerator(random);
            Add(new VariantsSetOperationTaskGenerator<int>(TaskIds.VariantsNumbersSetUnionOperationTask, SetOperation.Union, new UnionSetGenerator<int>(random),new SetVariantGenerator<int>(unionIntSetGenerator, random), unionIntSetGenerator, random, setWriter));
            var unionSymbolSetGenerator = new SymbolMathSetGenerator(random);
            Add(new VariantsSetOperationTaskGenerator<string>(TaskIds.VariantsSymbolsSetUnionOperationTask, SetOperation.Union, new UnionSetGenerator<string>(random),new SetVariantGenerator<string>(unionSymbolSetGenerator, random), unionSymbolSetGenerator, random, setWriter));
            Add(new VariantsSetOperationTaskGenerator<int>(TaskIds.VariantsBorderSetUnionOperationTask, SetOperation.Union, new UnionBorderedSetGenerator(random), new BorderedSetVariantsGenerator(random),  new IntBorderSetGenerator(random), random, setWriter));

            var exceptIntSetGenerator = new IntMathSetGenerator(random) {MinCount = 4, MaxCount = 6};
            Add(new VariantsSetOperationTaskGenerator<int>(TaskIds.VariantsNumbersSetExceptOperationTask, SetOperation.Except, new ExceptIntSetGenerator(random),new SetVariantGenerator<int>(exceptIntSetGenerator, random), exceptIntSetGenerator, random, setWriter));
            var exceptSymbolSetGenerator = new SymbolMathSetGenerator(random) {MaxCount = 6, MinCount = 4};
            Add(new VariantsSetOperationTaskGenerator<string>(TaskIds.VariantsSymbolsSetExceptOperationTask, SetOperation.Except, new ExceptSymbolSetGenerator(random),new SetVariantGenerator<string>(exceptSymbolSetGenerator, random), exceptSymbolSetGenerator, random, setWriter));
            Add(new VariantsSetOperationTaskGenerator<int>(TaskIds.VariantsBorderSetExceptOperationTask, SetOperation.Except, new ExceptBorderedSetGenerator(random), new BorderedSetVariantsGenerator(random),  new IntBorderSetGenerator(random), random, setWriter));

            Add(new SetOperationTaskGenerator<int>(TaskIds.NumbersSetIntersectOperationTask, new IntersectIntSetGenerator(random), SetOperation.Intersect, setWriter, random, new IntMathSetGenerator(random) {MaxCount = 6, MinCount = 4}));
            Add(new SetOperationTaskGenerator<string>(TaskIds.SymbolsSetIntersectOperationTask, new IntersectSymbolSetGenerator(random), SetOperation.Intersect, setWriter, random, new SymbolMathSetGenerator(random) {MaxCount = 6, MinCount = 4}));
            Add(new SetOperationTaskGenerator<int>(TaskIds.BorderSetIntersectOperationTask, new IntersectBorderedSetGenerator(random), SetOperation.Intersect, setWriter, random, new IntBorderSetGenerator(random)));
            Add(new SetOperationTaskGenerator<int>(TaskIds.NumbersSetUnionOperationTask, new UnionSetGenerator<int>(random), SetOperation.Union, setWriter, random, new IntMathSetGenerator(random)));
            Add(new SetOperationTaskGenerator<string>(TaskIds.SymbolsSetUnionOperationTask, new UnionSetGenerator<string>(random), SetOperation.Union, setWriter, random, new SymbolMathSetGenerator(random)));
            Add(new SetOperationTaskGenerator<int>(TaskIds.BorderSetUnionOperationTask, new UnionBorderedSetGenerator(random), SetOperation.Union, setWriter, random, new IntBorderSetGenerator(random)));

            Add(new SetOperationTaskGenerator<int>(TaskIds.NumbersSetExceptOperationTask, new ExceptIntSetGenerator(random), SetOperation.Except, setWriter, random, new IntMathSetGenerator(random) {MaxCount = 6, MinCount = 4}));
            Add(new SetOperationTaskGenerator<string>(TaskIds.SymbolsSetExceptOperationTask, new ExceptSymbolSetGenerator(random), SetOperation.Except, setWriter, random, new SymbolMathSetGenerator(random) {MaxCount = 6, MinCount = 4}));
            Add(new SetOperationTaskGenerator<int>(TaskIds.BorderSetExceptOperationTask, new ExceptBorderedSetGenerator(random), SetOperation.Except, setWriter, random, new IntBorderSetGenerator(random)));
            
            Add(new CartesianProductElementsTaskGenerator<int>(TaskIds.IntCartesianProductElementsTask, setWriter, random, new IntMathSetGenerator(random) {MaxCount = 4, MinCount = 2}));
            Add(new CartesianProductElementsTaskGenerator<string>(TaskIds.SymbolCartesianProductElementsTask, setWriter, random, new SymbolMathSetGenerator(random) {MaxCount = 4, MinCount = 2}));
            
            Add(new VariantsSelectReflectionTaskGenerator<int>(TaskIds.SelectSeveralNumbersReflectionFromAccordance, setWriter, random, new IntMathSetGenerator(random) {Count = 5}));
            Add(new VariantsSelectReflectionTaskGenerator<string>(TaskIds.SelectSeveralSymbolsReflectionFromAccordance, setWriter, random, new SymbolMathSetGenerator(random) {Count = 5}));
            
            Add(new VariantsSelectInjectionTaskGenerator<int, string>(TaskIds.SelectReflectionInjectionNumToSymbol, setWriter, random, new IntMathSetGenerator(random) {Count = 4, IsZeroNecessary = false}, new SymbolMathSetGenerator(random) {Count = 5}));
            Add(new VariantsSelectInjectionTaskGenerator<string, int>(TaskIds.SelectReflectionInjectionSymbolToNum, setWriter, random, new SymbolMathSetGenerator(random) {Count = 4}, new IntMathSetGenerator(random) {Count = 5, IsZeroNecessary = false}));
            Add(new VariantsSelectSurjectiveTaskGenerator<int, string>(TaskIds.SelectReflectionSurjectiveNumToSymbol, setWriter, new IntMathSetGenerator(random) {Count = 5, IsZeroNecessary = false}, new SymbolMathSetGenerator(random) {Count = 4}, random));
            Add(new VariantsSelectSurjectiveTaskGenerator<string, int>(TaskIds.SelectReflectionSurjectiveSymbolToNum, setWriter, new SymbolMathSetGenerator(random) {Count = 5},new IntMathSetGenerator(random) {Count = 4, IsZeroNecessary = false},  random));
            Add(new VariantBijectiveTaskGenerator<int, string>(TaskIds.SelectReflectionBijectiveNumToSymbol, setWriter, new IntMathSetGenerator(random) {Count = 5, IsZeroNecessary = false}, new SymbolMathSetGenerator(random) {Count = 5}, random));
            Add(new VariantBijectiveTaskGenerator<string, int>(TaskIds.SelectReflectionBijectiveSymbolsToNum, setWriter, new SymbolMathSetGenerator(random) {Count = 5}, new IntMathSetGenerator(random) {Count = 5, IsZeroNecessary = false}, random));
            Add(new SelectReflectionTypeTaskGenerator<int, string>(TaskIds.SelectReflectionTypeNumToSym, setWriter, new IntMathSetGenerator(random) {Count = 5, IsZeroNecessary = false}, new SymbolMathSetGenerator(random) {Count = 5}, random));
            Add(new SelectReflectionTypeTaskGenerator<string, int>(TaskIds.SelectReflectionTypeSymToNum, setWriter, new SymbolMathSetGenerator(random) {Count = 5}, new IntMathSetGenerator(random) {Count = 5, IsZeroNecessary = false},random));


            Add(new VariantsSelectFuncReflectionTaskGenerator(TaskIds.VariantSelectFuncReflection, setWriter, new IntMathSetGenerator(random) {MaxCount = 6}, random, false));
            Add(new VariantsSelectFuncReflectionTaskGenerator(TaskIds.VariantSelectReversedFuncReflection, setWriter, new IntMathSetGenerator(random) {MaxCount = 6}, random, true));
            Add(new SelectReflectionCompositionTaskGenerator(setWriter, new IntMathSetGenerator(random) {MaxCount = 6, IsZeroNecessary = false}, random));
            Add(new SelectReflectionFormTaskGenerator(setWriter, new IntMathSetGenerator(random){MaxCount = 6, IsZeroNecessary = false}, random));
            Add(new SelectPrototypeByReflectionTaskGenerator(setWriter, random, new IntMathSetGenerator(random){MaxCount = 6, IsZeroNecessary = false}));
            
            Add(new WriteFuncReflectionTaskGenerator(TaskIds.SelectFuncReflection, setWriter, new IntMathSetGenerator(random) {MaxCount = 6}, random, false));
            Add(new WriteFuncReflectionTaskGenerator(TaskIds.SelectReversedReflection, setWriter, new IntMathSetGenerator(random) {MaxCount = 6}, random, true));
            Add(new WriteReflectionCompositionTaskGenerator(setWriter, new IntMathSetGenerator(random) {MaxCount = 6, IsZeroNecessary = false}, random));
            Add(new WriteReflectionFormTaskGenerator(setWriter, new IntMathSetGenerator(random){MaxCount = 6, IsZeroNecessary = false}, random));
            Add(new WritePrototypeByReflectionTaskGenerator(setWriter, random, new IntMathSetGenerator(random){MaxCount = 6, IsZeroNecessary = false}));
        }

        public IEnumerable<ITaskGenerator> TaskGenerators => _idsAndGenerators.Values;
        public ITaskGenerator Get(string id) => _idsAndGenerators[id];

        private void Add(ITaskGenerator generator)
        { 
            _idsAndGenerators.Add(generator.Id, generator);
        }
    }
}