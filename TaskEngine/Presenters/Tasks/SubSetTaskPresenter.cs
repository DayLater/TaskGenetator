using TaskEngine.Generators.Tasks.TextTasks;
using TaskEngine.Views;

namespace TaskEngine.Presenters.Tasks
{
    public class SubSetTaskPresenter: IPresenter
    {
        private readonly SubSetTextTaskGenerator _textTextTaskGenerator;

        public SubSetTaskPresenter(SubSetTextTaskGenerator textTextTaskGenerator, IView generatorView)
        {
            _textTextTaskGenerator = textTextTaskGenerator;
            GeneratorView = generatorView;
            
            ExampleTask = _textTextTaskGenerator.Generate().Task;
        }
        
        public string ExampleTask { get; }
        public IView GeneratorView { get; }
    }
}