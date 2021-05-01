using TaskEngine.Generators.SetGenerators;
using TaskEngine.Views;

namespace TaskEngine.Presenters
{
    public class MathSetGeneratorPresenter: IPresenter
    {
        private readonly IMathSetGeneratorView _view;
        private readonly IntMathSetGenerator _intMathSetGenerator;

        public MathSetGeneratorPresenter(IMathSetGeneratorView view, IntMathSetGenerator intMathSetGenerator)
        {
            _view = view;
            _intMathSetGenerator = intMathSetGenerator;

            _view.ElementsMaxCount = _intMathSetGenerator.MaxCount;
            _view.ElementsMinCount = _intMathSetGenerator.MinCount;

            _view.ElementMinValue = _intMathSetGenerator.MinValue;
            _view.ElementMaxValue = _intMathSetGenerator.MaxValue;

            _view.PositiveElementsMinCount = _intMathSetGenerator.MinPositiveCount;
            _view.NegativeElementsMinCount = _intMathSetGenerator.MinNegativeCount;
            _view.IsZeroNecessary = _intMathSetGenerator.IsZeroNecessary;
            
            _view.ElementsMaxCountChanged += OnElementsMaxCountChanged;
            _view.ElementsMinCountChanged += OnElementsMinCountChanged;

            _view.ElementMinValueChanged += OnElementMinValueChanged;
            _view.ElementMaxValueChanged += OnElementMaxValueChanged;

            _view.PositiveElementsMinCountChanged += OnPositiveMinCountChanged;
            _view.NegativeElementsMinCountChanged += OnNegativeMinCountChanged;

            _view.ZeroNecessaryChanged += OnZeroNecessaryChanged;
        }

        private void OnElementsMinCountChanged(int value) => _intMathSetGenerator.MinCount = value;
        private void OnElementsMaxCountChanged(int value) => _intMathSetGenerator.MaxCount = value;

        private void OnElementMinValueChanged(int value) => _intMathSetGenerator.MinValue = value;
        private void OnElementMaxValueChanged(int value) => _intMathSetGenerator.MaxValue = value;

        private void OnPositiveMinCountChanged(int value) => _intMathSetGenerator.MinPositiveCount = value;
        private void OnNegativeMinCountChanged(int value) => _intMathSetGenerator.MinNegativeCount = value;

        private void OnZeroNecessaryChanged(bool value) => _intMathSetGenerator.IsZeroNecessary = value;
    }
}