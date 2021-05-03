using TaskEngine;
using TaskEngine.Views;
using TaskEngine.Views.TaskGenerators;

namespace WinGenerator.Views.GeneratorsViews
{
    public class SymbolsBelongSetGeneratorView: SeveralAnswersVariantGeneratorView, ISymbolsBelongSetView
    {
        public override string Id => TaskIds.SymbolsBelongSetTask;
        public override void Activate()
        {
            SetGeneratorView.Activate();
            _variantsNumeric.Numeric.ValueChanged += OnVariantCountChanged;
            _answerCountNumeric.Numeric.ValueChanged += OnAnswerCountChanged;
        }

        public override void Deactivate()
        {
            SetGeneratorView.Deactivate();
            _variantsNumeric.Numeric.ValueChanged -= OnVariantCountChanged;
            _answerCountNumeric.Numeric.ValueChanged -= OnAnswerCountChanged;
        }

        public ISymbolMathSetGeneratorView SetGeneratorView { get; }

        public SymbolsBelongSetGeneratorView() : base(33)
        {
            var view = new SymbolMathSetGeneratorView();
            SetGeneratorView = view;
            AddControl(view, 1, 0);
        }
    }
}