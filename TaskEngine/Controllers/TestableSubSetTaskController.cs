using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Views;
using TaskEngine.Writers.Tasks;

namespace TaskEngine.Controllers
{
    public class TestableSubSetTaskController: ITaskController
    {
        private readonly TestableSubSetTaskGenerator _generator;
        private readonly TestableSubSetTaskWriter _writer;

        public TestableSubSetTaskController(TestableSubSetTaskGenerator generator, TestableSubSetTaskWriter writer, IView generatorView)
        {
            _generator = generator;
            _writer = writer;
            GeneratorView = generatorView;
        }

        public string Id => TaskIds.TestableSubSetTask;
        
        public ITextTask Generate()
        {
            var task = _generator.Generate();
            return _writer.WriteTask(task);
        }

        public IView GeneratorView { get; }
    }
}