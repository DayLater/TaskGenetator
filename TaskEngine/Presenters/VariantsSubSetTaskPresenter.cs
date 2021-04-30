using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Views;
using TaskEngine.Writers.Tasks;

namespace TaskEngine.Presenters
{
    public class VariantsSubSetTaskPresenter: ITaskPresenter
    {
        private readonly VariantsSubSetTaskGenerator _generator;
        private readonly TestableSubSetSetAnswerTaskWriter _writer;

        public VariantsSubSetTaskPresenter(VariantsSubSetTaskGenerator generator, TestableSubSetSetAnswerTaskWriter writer, IView generatorView)
        {
            _generator = generator;
            _writer = writer;
            GeneratorView = generatorView;
            ExampleTask = _writer.WriteTask(_generator.Generate()).Task;
        }

        public string Id => TaskIds.TestableSubSetTask;
        public string ExampleTask { get; }

        public ITextTask Generate()
        {
            var task = _generator.Generate();
            return _writer.WriteTask(task);
        }

        public IView GeneratorView { get; }
    }
}