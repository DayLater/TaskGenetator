using TaskEngine.Generators.Tasks.TextTasks;
using TaskEngine.Views;

namespace TaskEngine.Presenters.Tasks
{
    public class VariantsSubSetTaskPresenter: IPresenter
    {
        private readonly VariantsSubSetSetAnswerTextTaskGenerator _textTextTaskGenerator;

        public VariantsSubSetTaskPresenter(VariantsSubSetSetAnswerTextTaskGenerator textTextTaskGenerator, IView generatorView)
        {
            _textTextTaskGenerator = textTextTaskGenerator;
            GeneratorView = generatorView;
            ExampleTask = _textTextTaskGenerator.Generate().Task;
        }

        public string Id => TaskIds.VariantsSubSetTask;
        public string ExampleTask { get; }
        public IView GeneratorView { get; }
    }
}