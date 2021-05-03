using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Views.TaskGenerators;

namespace TaskEngine.Presenters.Tasks.Elements
{
    public class SymbolBelongToSetTaskPresenter: IPresenter
    {
        private readonly ISymbolBelongToSetView _view;
        private readonly SymbolBelongToSetTaskGenerator _taskGenerator;

        public SymbolBelongToSetTaskPresenter(ISymbolBelongToSetView view, SymbolBelongToSetTaskGenerator taskGenerator)
        {
            _view = view;
            _taskGenerator = taskGenerator;

            var symbolSetGeneratorPresenter = new SymbolSetGeneratorPresenter(taskGenerator.SetGenerator, view.SetGeneratorView);
            _view.VariantsCountChanged += count => taskGenerator.VariantsCount = count;
        }
    }
}