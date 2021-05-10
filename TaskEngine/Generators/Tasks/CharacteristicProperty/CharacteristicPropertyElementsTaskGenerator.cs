using System;
using System.Linq;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models.Tasks;
using TaskEngine.Models.Values;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.CharacteristicProperty
{
    public class CharacteristicPropertyElementsTaskGenerator: TaskGenerator
    {
        private readonly ExpressionSetGenerator _setGenerator;
        private readonly IntValue _elementCount = new IntValue(ValuesIds.ElementsCount) {Value = 5, MinValue = 2};
        
        public CharacteristicPropertyElementsTaskGenerator(ISetWriter setWriter, Random random) : base(TaskIds.CharacteristicPropertyElementsTask, setWriter)
        {
            _setGenerator = new ExpressionSetGenerator(random);
            Add(_setGenerator);
            Add(_elementCount);
        }

        public override ITask Generate()
        {
            var set = _setGenerator.Generate(1).First();
            var elements = set.GetElements().Take(_elementCount.Value).ToList();
            var condition = $"Укажите первые {_elementCount.Value} элементов по его характеристическому свойству {WriteProperty(set)}";
            return new AnswerTask<int>(elements, condition);
        }
    }
}