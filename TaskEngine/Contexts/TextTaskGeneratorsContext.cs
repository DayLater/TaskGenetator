using System.Collections.Generic;
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
            Add(new NumberBelongsSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<NumberBelongsSetTask>(TaskIds.NumberBelongsSetTask)));
            Add(new NumbersBelongSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<NumbersBelongSetTask>(TaskIds.NumbersBelongSetTask)));
            Add(new SymbolBelongsSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<SymbolBelongsSetTask>(TaskIds.SymbolBelongsSetTask)));
            Add(new SymbolsBelongSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<SymbolsBelongSetTask>(TaskIds.SymbolsBelongSetTask)));
            Add(new NumberBelongsSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<NumberBelongsSetTask>(TaskIds.NumberBelongsBorderedSetTask)));
            Add(new NumbersBelongSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<NumbersBelongSetTask>(TaskIds.NumbersBelongBorderedSetTask)));
            Add(new SetContainsElementsTextTaskGenerator(setWriter, taskGeneratorContext.Get<SetContainElementsTask>(TaskIds.SetContainsElement)));
            Add(new SetContainsElementsTextTaskGenerator(setWriter, taskGeneratorContext.Get<SetContainElementsTask>(TaskIds.SetContainsElements)));

            Add(new CharacteristicPropertyTextTaskGenerator(setWriter, taskGeneratorContext.Get<CharacteristicPropertyTask>(TaskIds.CharacteristicPropertyTask)));
            Add(new VariantsSubSetSetAnswerTextTaskGenerator(setWriter, taskGeneratorContext.Get<VariantsSubSetTask>(TaskIds.VariantsSubSetTask)));
            Add(new SubSetTextTaskGenerator(setWriter, taskGeneratorContext.Get<SubSetTask>(TaskIds.SubSetTask)));
            Add(new BorderSetOperationTextTaskGenerator(setWriter, taskGeneratorContext.Get<VariantsBorderSetOperationTask>(TaskIds.BorderSetOperationTask)));
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