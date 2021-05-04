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
            Add(new NumberBelongsSetTaskGenerator());
            Add(new NumbersBelongSetTaskGenerator());
            Add(new SymbolBelongsSetTaskGenerator());
            Add(new SymbolsBelongSetTaskGenerator());
            Add(new NumberBelongsBorderedSetTaskGenerator());
            Add(new NumbersBelongBorderedSetTaskGenerator());
            Add(new SetContainElementTaskGenerator(TaskIds.SetContainsElement));
            Add(new SetContainElementTaskGenerator(TaskIds.SetContainsElements, 6, 2, 3));
            
            Add(new CharacteristicPropertyTaskGenerator(new ExpressionSetGenerator(), random));
            Add(new VariantsSubSetTaskGenerator(new IntMathSetGenerator(), random)); 
            Add(new SubSetTaskGenerator(new IntMathSetGenerator()));

            var variantsGeneratorByCorrect = new SetVariantsGeneratorByCorrect(random, new BorderedSetComparer());
            Add(new BorderSetOperationTaskGenerator(variantsGeneratorByCorrect, new IntBorderSetGenerator(), random));
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