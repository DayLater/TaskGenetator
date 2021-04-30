using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Views;
using TaskEngine.Writers.Tasks.Elements;

namespace TaskEngine.Presenters.Elements
{
    public class NumberBelongsSetTaskPresenter: ITaskPresenter
    {
        private readonly NumberBelongsSetTaskGenerator _generator;
        private readonly NumberBelongsSetTaskWriter _writer;

        public NumberBelongsSetTaskPresenter(NumberBelongsSetTaskGenerator generator, NumberBelongsSetTaskWriter writer, IView generatorView)
        {
            GeneratorView = generatorView;
            _generator = generator;
            _writer = writer;
        }

        public string Id => TaskIds.NumberBelongsSetTask;
        
        public ITextTask Generate()
        {
            var task = _generator.Generate();
            return _writer.WriteTask(task);
        }

        public IView GeneratorView { get; }
    }
}