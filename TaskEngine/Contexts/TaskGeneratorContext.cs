using System;
using System.Collections.Generic;
using TaskEngine.Comparers;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Generators.Tasks;
using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Tasks;

namespace TaskEngine.Contexts
{
    public class TaskGeneratorContext
    {
        private readonly Dictionary<string, object> _idsAndGenerators = new Dictionary<string, object>();
        
        public TaskGeneratorContext(Random random)
        {
            Add(new NumberBelongsSetTaskGenerator(random));
            Add(new NumbersBelongSetTaskGenerator(random));
            Add(new SymbolBelongsSetTaskGenerator(random));
            Add(new SymbolsBelongSetTaskGenerator(random));
            Add(new NumberBelongsBorderedSetTaskGenerator(random));
            Add(new NumbersBelongBorderedSetTaskGenerator(random));
            Add(new SetContainElementTaskGenerator(TaskIds.SetContainsElement, random));
            Add(new SetContainElementTaskGenerator(TaskIds.SetContainsElements, random,6, 2, 5));
            
            Add(new CharacteristicPropertyTaskGenerator(new ExpressionSetGenerator(random), random));
            Add(new VariantsSubSetTaskGenerator(new IntMathSetGenerator(random), random)); 
            Add(new SubSetTaskGenerator(random));

            var variantsGeneratorByCorrect = new SetVariantsGeneratorByCorrect(random, new BorderedSetComparer());
            Add(new BorderSetOperationTaskGenerator(variantsGeneratorByCorrect, new IntBorderSetGenerator(random), random));
        }

        public ITaskGenerator<TTask> Get<TTask>(string id)
            where TTask: ITask
        {
            return (ITaskGenerator<TTask>) _idsAndGenerators[id];
        }

        private void Add<TTask>(ITaskGenerator<TTask> generator) 
            where TTask: ITask
        {
            _idsAndGenerators.Add(generator.Id, generator);
        }
    }
}