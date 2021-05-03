using System;
using System.Collections.Generic;
using TaskEngine.Generators.Tasks;
using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Generators.TextTasks;
using TaskEngine.Generators.TextTasks.Elements;
using TaskEngine.Writers;

namespace TaskEngine.Contexts
{
    public class TextTaskGeneratorsContext
    {
        private readonly Dictionary<string, ITextTaskGenerator> _generators = new Dictionary<string, ITextTaskGenerator>();

        private readonly Dictionary<Type, ITextTaskGenerator> _typeGenerators = new Dictionary<Type, ITextTaskGenerator>();

        public TextTaskGeneratorsContext(ISetWriter setWriter, TaskGeneratorContext taskGeneratorContext)
        {
            Add(new NumberBelongsSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<NumberBelongsSetTaskGenerator>()));
            Add(new NumbersBelongSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<NumbersBelongSetTaskGenerator>()));
            Add(new SymbolBelongsSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<SymbolBelongsSetTaskGenerator>()));
            Add(new SymbolsBelongSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<SymbolsBelongSetTaskGenerator>()));
            Add(new NumberBelongBorderedSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<NumberBelongBorderedSetTaskGenerator>()));
            
            Add(new CharacteristicPropertyTextTaskGenerator(setWriter, taskGeneratorContext.Get<CharacteristicPropertyTaskGenerator>()));
            Add(new VariantsSubSetSetAnswerTextTaskGenerator(setWriter, taskGeneratorContext.Get<VariantsSubSetTaskGenerator>()));
            Add(new SubSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<SubSetTaskGenerator>()));
            Add(new BorderSetOperationTextTaskGenerator(setWriter, taskGeneratorContext.Get<BorderSetOperationTaskGenerator>()));
        }

        public IEnumerable<ITextTaskGenerator> Generators => _generators.Values;
        public ITextTaskGenerator Get(string generatorId) => _generators[generatorId];
        public TGenerator Get<TGenerator>() where TGenerator: ITextTaskGenerator => (TGenerator) _typeGenerators[typeof(TGenerator)];
        
        private void Add<TGenerator>(TGenerator generator)
            where TGenerator: ITextTaskGenerator
        {
            _generators.Add(generator.Id, generator);
            _typeGenerators.Add(generator.GetType(), generator);
        }
    }
}