using System;
using System.Collections.Generic;
using System.Linq;
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
            Add(TaskIds.NumberBelongsSetTask, new NumberBelongsSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<NumberBelongsSetTaskGenerator>()));
            Add(TaskIds.NumbersBelongSetTask, new NumbersBelongSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<NumbersBelongSetTaskGenerator>()));
            Add(TaskIds.CharacteristicPropertyTask, new CharacteristicPropertySetAnswerTextTaskGenerator(setWriter, taskGeneratorContext.Get<CharacteristicPropertyTaskGenerator>()));
            Add(TaskIds.VariantsSubSetTask, new VariantsSubSetSetAnswerTextTaskGenerator(setWriter, taskGeneratorContext.Get<VariantsSubSetTaskGenerator>()));
            Add(TaskIds.SubSetTask, new SubSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<SubSetTaskGenerator>()));
            Add(TaskIds.BorderSetOperationTask, new BorderSetOperationTextTaskGenerator(setWriter, taskGeneratorContext.Get<BorderSetOperationTaskGenerator>()));
        }

        public IEnumerable<(string, ITextTaskGenerator)> Generators => _generators.Select(pair => (pair.Key, pair.Value));
        public ITextTaskGenerator Get(string generatorId) => _generators[generatorId];
        public TGenerator Get<TGenerator>() where TGenerator: ITextTaskGenerator => (TGenerator) _typeGenerators[typeof(TGenerator)];
        
        private void Add<TGenerator>(string id, TGenerator generator)
            where TGenerator: ITextTaskGenerator
        {
            _generators.Add(id, generator);
            _typeGenerators.Add(generator.GetType(), generator);
        }
    }
}