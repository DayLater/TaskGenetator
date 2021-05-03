using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Views.TaskGenerators;

namespace TaskEngine.Presenters.Tasks.Elements
{
    public class SymbolsBelongSetPresenter: IPresenter
    {
        private readonly ISymbolsBelongSetView _view;
        private readonly SymbolsBelongSetTaskGenerator _taskGenerator;

        public SymbolsBelongSetPresenter(ISymbolsBelongSetView view, SymbolsBelongSetTaskGenerator taskGenerator)
        {
            _view = view;
            _taskGenerator = taskGenerator;
            
            var setGeneratorPresenter = new SymbolSetGeneratorPresenter(taskGenerator.SetGenerator, view.SetGeneratorView);
            _view.VariantsCountChanged += count => _taskGenerator.VariantsCount = count;
            _view.AnswerCountChanged += count => _taskGenerator.AnswersCount = count;

            _view.AnswerCount = taskGenerator.AnswersCount;
            _view.VariantsCount = taskGenerator.VariantsCount;
        }
    }
}