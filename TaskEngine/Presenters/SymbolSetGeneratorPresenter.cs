using TaskEngine.Generators.SetGenerators;
using TaskEngine.Views;

namespace TaskEngine.Presenters
{
    public class SymbolSetGeneratorPresenter: IPresenter
    {
        private readonly SymbolMathSetGenerator _setGenerator;
        private readonly ISymbolMathSetGeneratorView _view;

        public SymbolSetGeneratorPresenter(SymbolMathSetGenerator setGenerator, ISymbolMathSetGeneratorView view)
        {
            _setGenerator = setGenerator;
            _view = view;

            _view.MaxCountChanged += count => _setGenerator.MaxCount = count;
            _view.MinCountChanged += count => _setGenerator.MinCount = count;

            _view.MaxCount = _setGenerator.MaxCount;
            _view.MinCount = setGenerator.MinCount;
        }
    }
}