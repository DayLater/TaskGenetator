using System;
using System.Collections.Generic;
using TaskEngine.Comparers;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Generators.Tasks;
using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Tasks;
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
            
            Add(new CharacteristicPropertyTaskGenerator(new ExpressionSetGenerator(random), random, setWriter));
            Add(new VariantsSubSetTaskGenerator(new IntMathSetGenerator(random), random, setWriter)); 
            Add(new SubSetTaskGenerator(random, setWriter));

            var variantsGeneratorByCorrect = new SetVariantsGeneratorByCorrect(random, new BorderedSetComparer());
            Add(new BorderSetOperationTaskGenerator(variantsGeneratorByCorrect, new IntBorderSetGenerator(random), random, setWriter));
        }

        public IEnumerable<ITaskGenerator> TaskGenerators => _idsAndGenerators.Values;
        public ITaskGenerator Get(string id) => _idsAndGenerators[id];

        private void Add(ITaskGenerator generator)
        {
            if (_idsAndGenerators != null) _idsAndGenerators.Add(generator.Id, generator);
        }
    }
}