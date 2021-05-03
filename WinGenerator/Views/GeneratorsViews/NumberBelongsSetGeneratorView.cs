using TaskEngine;
using TaskEngine.Views;
using TaskEngine.Views.TaskGenerators;

namespace WinGenerator.Views.GeneratorsViews
{
    public class NumberBelongsSetGeneratorView: VariantsGeneratorView, INumberBelongsSetGeneratorView
    {
        public IMathSetGeneratorView MathSetGeneratorView { get; }
        public override string Id => TaskIds.NumberBelongsSetTask;

        public NumberBelongsSetGeneratorView(): base(20)
        {
            var mathSetGeneratorView = new MathSetGeneratorSettingsView();
            MathSetGeneratorView = mathSetGeneratorView;
            AddControl(mathSetGeneratorView, 1, 0);
        }
        
        public override void Activate()
        {
            _variantsNumeric.Numeric.ValueChanged += OnVariantCountChanged;
            MathSetGeneratorView.Activate();
        }

        public override void Deactivate()
        {
            _variantsNumeric.Numeric.ValueChanged -= OnVariantCountChanged;
            MathSetGeneratorView.Deactivate();
        }
    }
}