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
        private readonly Dictionary<Type, object> _generators = new Dictionary<Type, object>();
        
        public TaskGeneratorContext(Random random)
        {
            Add(new NumberBelongsSetTaskGenerator());
            Add(new NumbersBelongSetTaskGenerator());
            Add(new SymbolBelongsSetTaskGenerator());
            Add(new SymbolsBelongSetTaskGenerator());
            Add(new NumberBelongsBorderedSetTaskGenerator());
            
            Add(new CharacteristicPropertyTaskGenerator(new ExpressionSetGenerator(), random));
            Add(new VariantsSubSetTaskGenerator(new IntMathSetGenerator(), random)); 
            Add(new SubSetTaskGenerator(new IntMathSetGenerator()));

            var variantsGeneratorByCorrect = new SetVariantsGeneratorByCorrect(random, new BorderedSetComparer());
            Add(new BorderSetOperationTaskGenerator(variantsGeneratorByCorrect, new IntBorderSetGenerator(), random));
        }

        public TGenerator Get<TGenerator, TTask>()
            where TGenerator : ITaskGenerator<TTask>
            where TTask: ITask
        {
            return (TGenerator) _generators[typeof(TGenerator)];
        }

        private void Add<TTask>(ITaskGenerator<TTask> generator) 
            where TTask: ITask
        {
            _generators.Add(generator.GetType(), generator);
        }
    }
}