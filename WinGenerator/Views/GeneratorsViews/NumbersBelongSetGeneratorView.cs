using System;
using TaskEngine;
using TaskEngine.Views;
using TaskEngine.Views.TaskGenerators;

namespace WinGenerator.Views.GeneratorsViews
{
    public class NumbersBelongSetGeneratorView: SeveralAnswersVariantGeneratorView, INumbersBelongSetGeneratorView
    {
        public IMathSetGeneratorView  MathSetGeneratorView { get; }
        public override string Id => TaskIds.NumbersBelongSetTask;

        public NumbersBelongSetGeneratorView(): base(20)
        {
            var mathSetView = new MathSetGeneratorSettingsView();
            MathSetGeneratorView = mathSetView;
            AddControl(mathSetView, 1, 0);
        }

        public override void Activate()
        {
            _answerCountNumeric.Numeric.ValueChanged += OnAnswerCountChanged;
            _variantsNumeric.Numeric.ValueChanged += OnVariantCountChanged;
            MathSetGeneratorView.Activate();
        }

        public override void Deactivate()
        {
            _answerCountNumeric.Numeric.ValueChanged -= OnAnswerCountChanged;
            _variantsNumeric.Numeric.ValueChanged -= OnVariantCountChanged;
            MathSetGeneratorView.Deactivate();
        }
    }
}