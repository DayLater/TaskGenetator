using System;
using System.Collections.Generic;
using TaskEngine.Comparers;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Generators.Tasks;
using TaskEngine.Generators.Tasks.Elements;

namespace TaskEngine.Contexts
{
    public class TaskGeneratorContext
    {
        private readonly Dictionary<Type, ITaskGenerator> _generators = new Dictionary<Type, ITaskGenerator>();
        
        public TaskGeneratorContext(Random random)
        {
            Add(new NumberBelongsSetTaskGenerator());
            Add(new NumbersBelongSetTaskGenerator());
            Add(new SymbolBelongsSetTaskGenerator());
            Add(new SymbolsBelongSetTaskGenerator());
            
            Add(new CharacteristicPropertyTaskGenerator(new ExpressionSetGenerator(), random));
            Add(new VariantsSubSetTaskGenerator(new IntMathSetGenerator(), random)); 
            Add(new SubSetTaskGenerator(new IntMathSetGenerator()));

            var variantsGeneratorByCorrect = new SetVariantsGeneratorByCorrect(random, new BorderedSetComparer());
            Add(new BorderSetOperationTaskGenerator(variantsGeneratorByCorrect, new IntBorderSetGenerator(), random));
        }

        public TGenerator Get<TGenerator>()
            where TGenerator : ITaskGenerator
        {
            return (TGenerator) _generators[typeof(TGenerator)];
        }

        private void Add<TGenerator>(TGenerator generator) where TGenerator: ITaskGenerator
        {
            _generators.Add(generator.GetType(), generator);
        }
    }
}