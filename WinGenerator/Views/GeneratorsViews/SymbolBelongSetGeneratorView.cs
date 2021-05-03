using TaskEngine;
using TaskEngine.Views;
using TaskEngine.Views.TaskGenerators;

namespace WinGenerator.Views.GeneratorsViews
{
    public class SymbolBelongSetGeneratorView: VariantsGeneratorView, ISymbolBelongsSetView
    {
        public override string Id => TaskIds.SymbolBelongsSetTask;
        public ISymbolMathSetGeneratorView SetGeneratorView { get; }

        public SymbolBelongSetGeneratorView() : base(33)
        {
            var view = new SymbolMathSetGeneratorView();
            SetGeneratorView = view;
            AddControl(view, 1, 0);
        }
        
        public override void Activate()
        {
            _variantsNumeric.Numeric.ValueChanged += OnVariantCountChanged;
            SetGeneratorView.Activate();
        }

        public override void Deactivate()
        {
            _variantsNumeric.Numeric.ValueChanged -= OnVariantCountChanged;
            SetGeneratorView.Deactivate();
        }
    }
}