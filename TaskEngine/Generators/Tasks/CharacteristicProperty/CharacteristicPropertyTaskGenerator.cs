using System;
using System.Linq;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.CharacteristicProperty
{
    public class CharacteristicPropertyTaskGenerator: TaskGenerator
    {
        private readonly ExpressionSetGenerator _setGenerator;

        public CharacteristicPropertyTaskGenerator(ISetWriter setWriter, Random random) : base(TaskIds.CharacteristicPropertyTask, setWriter)
        {
            _setGenerator = new ExpressionSetGenerator(random);
            Add(_setGenerator);
        }

        public override ITask Generate()
        {
            var set = _setGenerator.Generate(1).First();
            var condition = $"Дано множество {WriteSet(set)}.\nУкажите его характеристическое свойство.";
            return new AnswerTask<ExpressionSet>(set, condition);
        }
    }
}