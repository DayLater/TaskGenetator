using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Views.TaskGenerators;

namespace TaskEngine.Presenters.Tasks.Elements
{
    public class SymbolBelongSetTaskPresenter: IPresenter
    {
        private readonly ISymbolBelongsSetView _view;
        private readonly SymbolBelongsSetTaskGenerator _taskGenerator;

        public SymbolBelongSetTaskPresenter(ISymbolBelongsSetView view, SymbolBelongsSetTaskGenerator taskGenerator)
        {
            _view = view;
            _taskGenerator = taskGenerator;

            var symbolSetGeneratorPresenter = new SymbolSetGeneratorPresenter(taskGenerator.SetGenerator, view.SetGeneratorView);
            _view.VariantsCountChanged += count => taskGenerator.VariantsCount = count;
        }
    }
}