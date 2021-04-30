using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Views;
using TaskEngine.Writers.Tasks;

namespace TaskEngine.Presenters
{
    public class SubSetTaskPresenter: ITaskPresenter
    {
        private readonly SubSetTaskGenerator _generator;
        private readonly SubSetTaskWriter _writer;

        public SubSetTaskPresenter(SubSetTaskGenerator generator, SubSetTaskWriter writer, IView generatorView)
        {
            _generator = generator;
            _writer = writer;
            GeneratorView = generatorView;
            
            ExampleTask = _writer.WriteTask(_generator.Generate()).Task;
        }

        public string Id => TaskIds.SubSetTask;
        public string ExampleTask { get; }

        public ITextTask Generate()
        {
            var task = _generator.Generate();
            return _writer.WriteTask(task);
        }

        public IView GeneratorView { get; }
    }
}