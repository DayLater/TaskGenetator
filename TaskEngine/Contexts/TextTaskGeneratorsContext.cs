using System.Collections.Generic;
using TaskEngine.Generators.Tasks;
using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Generators.TextTasks;
using TaskEngine.Generators.TextTasks.Elements;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Writers;

namespace TaskEngine.Contexts
{
    public class TextTaskGeneratorsContext
    {
        private readonly Dictionary<string, ITextTaskGenerator> _generators = new Dictionary<string, ITextTaskGenerator>();

        public TextTaskGeneratorsContext(ISetWriter setWriter, TaskGeneratorContext taskGeneratorContext)
        {
            Add(new NumberBelongsSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<NumberBelongsSetTaskGenerator, NumberBelongsSetTask>()));
            Add(new NumbersBelongSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<NumbersBelongSetTaskGenerator, NumbersBelongSetTask>()));
            Add(new SymbolBelongsSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<SymbolBelongsSetTaskGenerator, SymbolBelongsSetTask>()));
            Add(new SymbolsBelongSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<SymbolsBelongSetTaskGenerator, SymbolsBelongSetTask>()));
            Add(new NumberBelongsSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<NumberBelongsBorderedSetTaskGenerator, NumberBelongsSetTask>()));
            

            Add(new CharacteristicPropertyTextTaskGenerator(setWriter, taskGeneratorContext.Get<CharacteristicPropertyTaskGenerator, CharacteristicPropertySetAnswerTask>()));
            Add(new VariantsSubSetSetAnswerTextTaskGenerator(setWriter, taskGeneratorContext.Get<VariantsSubSetTaskGenerator, VariantsSetAnswerSubSetTask>()));
            Add(new SubSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<SubSetTaskGenerator, SubSetSetAnswerTask>()));
            Add(new BorderSetOperationTextTaskGenerator(setWriter, taskGeneratorContext.Get<BorderSetOperationTaskGenerator, BorderSetOperationSetAnswerTask>()));
        }

        public IEnumerable<ITextTaskGenerator> Generators => _generators.Values;
        public ITextTaskGenerator Get(string generatorId) => _generators[generatorId];

        private void Add<TGenerator>(TGenerator generator)
            where TGenerator: ITextTaskGenerator
        {
            _generators.Add(generator.Id, generator);
        }
    }
}