using System;
using TaskEngine.Views;
using WinGenerator.CustomControls;

namespace WinGenerator.Views.GeneratorsViews
{
    public class SymbolMathSetGeneratorView: View, ISymbolMathSetGeneratorView
    {
        private readonly LabeledNumericControl _maxCountNumeric;
        private readonly LabeledNumericControl _minCountNumeric;
        
        public event Action<int> MaxCountChanged = i => { }; 
        public int MaxCount
        {
            get => _maxCountNumeric.Value;
            set => _maxCountNumeric.Value = value;
        }

        public event Action<int> MinCountChanged = i => { }; 
        public int MinCount
        {
            get => _minCountNumeric.Value;
            set => _minCountNumeric.Value = value;
        }

        public override string Id => "Настройка генератора множеств из букв";

        public SymbolMathSetGeneratorView()
        {
            AddRow(100);
            AddColumn(50);
            AddColumn(50);

            _maxCountNumeric = AddLabeledNumeric(0, 0, "Максимальное количество элеметнтов", 10);
            _minCountNumeric = AddLabeledNumeric(1, 0, "Минимальное количество элементов", 6);
        }

        public override void Activate()
        {
            _maxCountNumeric.Numeric.ValueChanged += OnMaxCountChanged;
            _minCountNumeric.Numeric.ValueChanged += OnMinCountChanged;
        }

        public override void Deactivate()
        {
            _maxCountNumeric.Numeric.ValueChanged -= OnMaxCountChanged;
            _minCountNumeric.Numeric.ValueChanged -= OnMinCountChanged;
        }

        private void OnMaxCountChanged(object sender, EventArgs e)
        {
            MaxCountChanged(_maxCountNumeric.Value);
        }

        private void OnMinCountChanged(object sender, EventArgs e)
        {
            MinCountChanged(_minCountNumeric.Value);
        }
    }
}