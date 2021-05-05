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
        private readonly Dictionary<string, IConditionTaskGenerator> _generators = new Dictionary<string, IConditionTaskGenerator>();

        public TextTaskGeneratorsContext(ISetWriter setWriter, TaskGeneratorContext taskGeneratorContext)
        {
            Add(new ElementsBelongsSetConditionTaskGenerator<NumbersBelongSetTask, int>(setWriter, taskGeneratorContext.Get<NumbersBelongSetTask>(TaskIds.NumberBelongsSetTask)));
            Add(new ElementsBelongsSetConditionTaskGenerator<NumbersBelongSetTask, int>(setWriter, taskGeneratorContext.Get<NumbersBelongSetTask>(TaskIds.NumbersBelongSetTask)));
            Add(new ElementsBelongsSetConditionTaskGenerator<SymbolsBelongSetTask, string>(setWriter, taskGeneratorContext.Get<SymbolsBelongSetTask>(TaskIds.SymbolBelongsSetTask)));
            Add(new ElementsBelongsSetConditionTaskGenerator<SymbolsBelongSetTask, string>(setWriter, taskGeneratorContext.Get<SymbolsBelongSetTask>(TaskIds.SymbolsBelongSetTask)));
            Add(new ElementsBelongsSetConditionTaskGenerator<NumbersBelongSetTask, int>(setWriter, taskGeneratorContext.Get<NumbersBelongSetTask>(TaskIds.NumberBelongsBorderedSetTask)));
            Add(new ElementsBelongsSetConditionTaskGenerator<NumbersBelongSetTask, int>(setWriter, taskGeneratorContext.Get<NumbersBelongSetTask>(TaskIds.NumbersBelongBorderedSetTask)));
            
            Add(new SetContainsElementsConditionTaskGenerator(setWriter, taskGeneratorContext.Get<SetContainElementsTask>(TaskIds.SetContainsElement)));
            Add(new SetContainsElementsConditionTaskGenerator(setWriter, taskGeneratorContext.Get<SetContainElementsTask>(TaskIds.SetContainsElements)));

            Add(new CharacteristicPropertyConditionTaskGenerator(setWriter, taskGeneratorContext.Get<VariantsCharacteristicPropertyTask>(TaskIds.CharacteristicPropertyTask)));
            Add(new VariantsSubSetConditionTaskGenerator(setWriter, taskGeneratorContext.Get<VariantsSubSetTask>(TaskIds.VariantsSubSetTask)));
            Add(new SubSetConditionTaskGenerator(setWriter, taskGeneratorContext.Get<SubSetTask>(TaskIds.SubSetTask)));
            Add(new BorderSetOperationConditionTaskGenerator(setWriter, taskGeneratorContext.Get<VariantsBorderSetOperationTask>(TaskIds.BorderSetOperationTask)));
        }

        public IEnumerable<IConditionTaskGenerator> Generators => _generators.Values;

        public IConditionTaskGenerator Get(string generatorId) => _generators[generatorId];

        private void Add<TGenerator>(TGenerator generator)
            where TGenerator: IConditionTaskGenerator
        {
            _generators.Add(generator.Id, generator);
        }
    }
}