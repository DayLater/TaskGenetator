using TaskEngine.Generators.Tasks;
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

            ExampleTask = _writer.WriteTask(_generator.Generate()).Task;
        }

        public string Id => TaskIds.NumberBelongsSetTask;
        public string ExampleTask { get; }
        public IView GeneratorView { get; }
    }
}