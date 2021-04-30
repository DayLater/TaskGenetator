using TaskEngine.Generators.Tasks.TextTasks.Elements;
using TaskEngine.Views;

namespace TaskEngine.Presenters.Tasks.Elements
{
    public class NumberBelongsSetTaskPresenter: IPresenter
    {
        private readonly NumberBelongsSetTextTextTaskGenerator _textTextTaskGenerator;

        public NumberBelongsSetTaskPresenter(NumberBelongsSetTextTextTaskGenerator textTextTaskGenerator, IView generatorView)
        {
            GeneratorView = generatorView;
            _textTextTaskGenerator = textTextTaskGenerator;

            ExampleTask = _textTextTaskGenerator.Generate().Task;
        }

        public string Id => TaskIds.NumberBelongsSetTask;
        public string ExampleTask { get; }
        public IView GeneratorView { get; }
    }
}