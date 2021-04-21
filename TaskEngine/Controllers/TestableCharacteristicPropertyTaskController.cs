using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers.Tasks;

namespace TaskEngine.Controllers
{
    public class TestableCharacteristicPropertyTaskController: ITaskController
    {
        private readonly CharacteristicPropertyTaskGenerator _generator;
        private readonly CharacteristicPropertyTaskWriter _writer;

        public string Id => TaskIds.CharacteristicPropertyTask;

        public TestableCharacteristicPropertyTaskController(CharacteristicPropertyTaskGenerator generator, CharacteristicPropertyTaskWriter writer)
        {
            _generator = generator;
            _writer = writer;
        }

        public ITextTask Generate()
        {
            var task = _generator.Generate();
            return _writer.WriteTask(task);
        }
    }
}