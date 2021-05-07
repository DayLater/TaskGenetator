using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Comparers;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Generators.SetGenerators.SetOperations.Ints;
using TaskEngine.Generators.SetGenerators.SetOperations.Symbols;
using TaskEngine.Generators.Tasks;
using TaskEngine.Generators.Tasks.CharacteristicProperty;
using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Generators.Tasks.SetOperations;
using TaskEngine.Generators.Tasks.SubSets;
using TaskEngine.Tasks;
using TaskEngine.Values;
using TaskEngine.Writers;

namespace TaskEngine.Factories
{
    public class TaskGeneratorFactory
    {
        private readonly Dictionary<string, ITaskGenerator> _idsAndGenerators = new Dictionary<string, ITaskGenerator>();
        
        public TaskGeneratorFactory(Random random, ISetWriter setWriter)
        {
            Add(new NumbersBelongSetTaskGenerator(random, TaskIds.NumberBelongsSetTask, 1, setWriter));
            Add(new NumbersBelongSetTaskGenerator(random, TaskIds.NumbersBelongSetTask, 2, setWriter));
            Add(new SymbolsBelongSetTaskGenerator(random, TaskIds.SymbolBelongsSetTask, 1, setWriter));
            Add(new SymbolsBelongSetTaskGenerator(random, TaskIds.SymbolsBelongSetTask, 2, setWriter));
            Add(new NumbersBelongBorderedSetTaskGenerator(random, TaskIds.NumberBelongsBorderedSetTask, 1, setWriter));
            Add(new NumbersBelongBorderedSetTaskGenerator(random, TaskIds.NumbersBelongBorderedSetTask, 2, setWriter));
            Add(new SetContainElementTaskGenerator(TaskIds.SetContainsElements, random, setWriter, 2, 3));

            Add(new CharacteristicPropertyTaskGenerator(setWriter, random));
            Add(new VariantsCharacteristicPropertyTaskGenerator(new ExpressionSetGenerator(random), random, setWriter));
            Add(new CharacteristicPropertyElementsTaskGenerator(setWriter, random));
            Add(new VariantsCharacteristicPropertyElementsTaskGenerator(setWriter, random));
            
            Add(new SelectNumbersSubSetTaskGenerator(1, setWriter, random, TaskIds.SelectOneNumbersSubSet));
            Add(new SelectNumbersSubSetTaskGenerator(2, setWriter, random, TaskIds.SelectSeveralNumbersSubSet));
            Add(new SelectSymbolsSubsetTaskGenerator(1, setWriter, random, TaskIds.SelectOneSymbolsSubSet));
            Add(new SelectSymbolsSubsetTaskGenerator(2, setWriter, random, TaskIds.SelectSeveralSymbolsSubSet));
            Add(new SelectSetBySubsetTaskGenerator<int>(TaskIds.SelectOneNumberSetBySubset, 1, setWriter, new IntMathSetGenerator(random), random, new MathSetComparer<int>()));
            Add(new SelectSetBySubsetTaskGenerator<int>(TaskIds.SelectSeveralNumberSetBySubset, 2, setWriter, new IntMathSetGenerator(random), random, new MathSetComparer<int>()));
            Add(new SelectSetBySubsetTaskGenerator<int>(TaskIds.SelectOneBorderedSetBySubset, 1, setWriter, new IntBorderSetGenerator(random), random, new BorderedSetComparer()));
            Add(new SelectSetBySubsetTaskGenerator<int>(TaskIds.SelectSeveralBorderedSetBySubset, 2, setWriter, new IntBorderSetGenerator(random), random, new BorderedSetComparer()));
            Add(new SelectSetBySubsetTaskGenerator<string>(TaskIds.SelectOneSymbolSetBySubset, 1, setWriter, new SymbolMathSetGenerator(random), random, new MathSetComparer<string>()));
            Add(new SelectSetBySubsetTaskGenerator<string>(TaskIds.SelectSeveralSymbolSetBySubset, 2, setWriter, new SymbolMathSetGenerator(random), random, new MathSetComparer<string>()));
            Add(new VariantsSubSetTaskGenerator(new IntMathSetGenerator(random), random, setWriter)); 
            Add(new SubSetTaskGenerator(random, setWriter));
            
            Add(new SetEqualsTaskGenerator<int>(TaskIds.NumberSetsEquals, setWriter, new IntMathSetGenerator(random), random, new MathSetComparer<int>()));
            Add(new SetEqualsTaskGenerator<string>(TaskIds.SymbolSetsEquals, setWriter, new SymbolMathSetGenerator(random), random, new MathSetComparer<string>()));
            
            Add(new VariantsSetOperationTaskGenerator<int>(TaskIds.BorderSetExceptOperationTask, SetOperation.Except, new ExceptBorderedSetGenerator(random), new BorderedSetVariantsGenerator(random),  new IntBorderSetGenerator(random), random, setWriter));
            Add(new VariantsSetOperationTaskGenerator<int>(TaskIds.BorderSetIntersectOperationTask, SetOperation.Intersect, new IntersectBorderedSetGenerator(random), new BorderedSetVariantsGenerator(random),  new IntBorderSetGenerator(random), random, setWriter));
            Add(new VariantsSetOperationTaskGenerator<int>(TaskIds.BorderSetUnionOperationTask, SetOperation.Union, new UnionBorderedSetGenerator(random), new BorderedSetVariantsGenerator(random),  new IntBorderSetGenerator(random), random, setWriter));

            var exceptIntSetGenerator = new IntMathSetGenerator(random) {MinCount = 4, MaxCount = 6};
            Add(new VariantsSetOperationTaskGenerator<int>(TaskIds.NumbersSetExceptOperationTask, SetOperation.Except, new ExceptIntSetGenerator(random),new SetVariantGenerator<int>(exceptIntSetGenerator, random, new MathSetComparer<int>()), exceptIntSetGenerator, random, setWriter));
            var intersectIntSetGenerator = new IntMathSetGenerator(random) {MinCount = 4, MaxCount = 6};
            Add(new VariantsSetOperationTaskGenerator<int>(TaskIds.NumbersSetIntersectOperationTask, SetOperation.Intersect, new IntersectIntSetGenerator(random),new SetVariantGenerator<int>(intersectIntSetGenerator, random, new MathSetComparer<int>()), intersectIntSetGenerator, random, setWriter));
            var unionIntSetGenerator = new IntMathSetGenerator(random);
            Add(new VariantsSetOperationTaskGenerator<int>(TaskIds.NumbersSetUnionOperationTask, SetOperation.Union, new UnionSetGenerator<int>(random),new SetVariantGenerator<int>(unionIntSetGenerator, random, new MathSetComparer<int>()), unionIntSetGenerator, random, setWriter));

            var exceptSymbolSetGenerator = new SymbolMathSetGenerator(random);
            exceptSymbolSetGenerator.Get<IntValue>(ValuesIds.ElementMinCount).Value = 4;
            exceptSymbolSetGenerator.Get<IntValue>(ValuesIds.ElementMaxCount).Value = 6;
            Add(new VariantsSetOperationTaskGenerator<string>(TaskIds.SymbolsSetExceptOperationTask, SetOperation.Except, new ExceptSymbolSetGenerator(random),new SetVariantGenerator<string>(exceptSymbolSetGenerator, random, new MathSetComparer<string>()), exceptSymbolSetGenerator, random, setWriter));
            
            var intersectSymbolSetGenerator = new SymbolMathSetGenerator(random);
            intersectSymbolSetGenerator.Get<IntValue>(ValuesIds.ElementMinCount).Value = 4;
            intersectSymbolSetGenerator.Get<IntValue>(ValuesIds.ElementMaxCount).Value = 6;
            Add(new VariantsSetOperationTaskGenerator<string>(TaskIds.SymbolsSetIntersectOperationTask, SetOperation.Intersect, new IntersectSymbolSetGenerator(random),new SetVariantGenerator<string>(intersectSymbolSetGenerator, random, new MathSetComparer<string>()), intersectSymbolSetGenerator, random, setWriter));
            
            var unionSymbolSetGenerator = new SymbolMathSetGenerator(random);
            Add(new VariantsSetOperationTaskGenerator<string>(TaskIds.SymbolsSetUnionOperationTask, SetOperation.Union, new UnionSetGenerator<string>(random),new SetVariantGenerator<string>(unionSymbolSetGenerator, random, new MathSetComparer<string>()), unionSymbolSetGenerator, random, setWriter));
        }

        public IEnumerable<ITaskGenerator> TaskGenerators => _idsAndGenerators.Values;
        public ITaskGenerator Get(string id) => _idsAndGenerators[id];

        private void Add(ITaskGenerator generator)
        {
            if (_idsAndGenerators != null) _idsAndGenerators.Add(generator.Id, generator);
        }
    }
}