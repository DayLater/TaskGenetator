using TaskEngine;
using TaskEngine.Tasks;
using TaskEngine.Views;
using TaskEngine.Views.TaskGenerators;

namespace WinGenerator.Views.GeneratorsViews
{
    public class NumberBelongsSetGeneratorView: VariantsGeneratorView, INumberBelongsSetGeneratorView
    {
        public IIntMathSetGeneratorView IntMathSetGeneratorView { get; }
        public override string Id => TaskIds.NumberBelongsSetTask;

        public NumberBelongsSetGeneratorView(): base(20)
        {
            var mathSetGeneratorView = new IntMathSetGeneratorSettingsView();
            IntMathSetGeneratorView = mathSetGeneratorView;
            AddControl(mathSetGeneratorView, 1, 0);
        }
        
        public override void Activate()
        {
            _variantsNumeric.Numeric.ValueChanged += OnVariantCountChanged;
            IntMathSetGeneratorView.Activate();
        }

        public override void Deactivate()
        {
            _variantsNumeric.Numeric.ValueChanged -= OnVariantCountChanged;
            IntMathSetGeneratorView.Deactivate();
        }
    }
}