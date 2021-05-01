using System.Collections.Generic;
using System.Linq;
using TaskEngine.Generators.Tasks.TextTasks;
using TaskEngine.Generators.Tasks.TextTasks.Elements;
using TaskEngine.Writers;

namespace TaskEngine.Contexts
{
    public class TextTaskGeneratorsContext
    {
        public NumberBelongsSetTextTextTaskGenerator NumberBelongsSetTextTextTaskGenerator { get; }
        public CharacteristicPropertySetAnswerTextTaskGenerator CharacteristicPropertySetAnswerTextTaskGenerator { get; }
        public VariantsSubSetSetAnswerTextTaskGenerator VariantsSubSetSetAnswerTextTaskGenerator { get; }
        public SubSetTextTaskGenerator SubSetTextTaskGenerator { get; }
        public BorderSetOperationTextTaskGenerator BorderSetOperationTextTaskGenerator { get; }

        public TextTaskGeneratorsContext(ISetWriter setWriter, TaskGeneratorContext taskGeneratorContext)
        {
            NumberBelongsSetTextTextTaskGenerator = new NumberBelongsSetTextTextTaskGenerator(setWriter, taskGeneratorContext.NumberBelongsSetTaskGenerator);
            Add(TaskIds.NumberBelongsSetTask, NumberBelongsSetTextTextTaskGenerator);
            
            CharacteristicPropertySetAnswerTextTaskGenerator = new CharacteristicPropertySetAnswerTextTaskGenerator(setWriter, taskGeneratorContext.CharacteristicPropertyTaskGenerator);
            Add(TaskIds.CharacteristicPropertyTask, CharacteristicPropertySetAnswerTextTaskGenerator);

            VariantsSubSetSetAnswerTextTaskGenerator = new VariantsSubSetSetAnswerTextTaskGenerator(setWriter, taskGeneratorContext.VariantsSubSetTaskGenerator);
            Add(TaskIds.VariantsSubSetTask, VariantsSubSetSetAnswerTextTaskGenerator);
            
            SubSetTextTaskGenerator = new SubSetTextTaskGenerator(setWriter, taskGeneratorContext.SubSetTaskGenerator);
            Add(TaskIds.SubSetTask, SubSetTextTaskGenerator);
            
            BorderSetOperationTextTaskGenerator = new BorderSetOperationTextTaskGenerator(setWriter, taskGeneratorContext.BorderSetOperationTaskGenerator);
            Add(TaskIds.BorderSetOperationTask, BorderSetOperationTextTaskGenerator);
        }

        private readonly Dictionary<string, ITextTaskGenerator> _generators = new Dictionary<string, ITextTaskGenerator>();
        
        public IEnumerable<(string, ITextTaskGenerator)> Generators => _generators.Select(pair => (pair.Key, pair.Value));

        public ITextTaskGenerator Get(string generatorId) => _generators[generatorId];

        private void Add(string id, ITextTaskGenerator generator) => _generators.Add(id, generator);
    }
}