using System;
using System.Windows.Forms;
using TaskEngine;
using TaskEngine.Views;

namespace WinGenerator.Views.GeneratorsViews
{
    public class VariantsCharacteristicPropertyGeneratorView: PercentTableLayoutPanel, IVariantsCharacteristicPropertyGeneratorView
    {
        public event Action<int> VariantsCountChanged = i => { };
        public event Action<int> MinCoefficientValueChanged = i => { };
        public event Action<int> MaxCoefficientValueChanged = i => { };

        public int MinCoefficientValue
        {
            set => _minCoefficientNumeric.Value = value;
        }

        public int MaxCoefficientValue
        {
            set => _maxCoefficientNumeric.Value = value;
        }
        
        public int VariantsCount
        {
            set => _variantCountNumeric.Value = value;
        }

        private readonly NumericUpDown _variantCountNumeric;
        private readonly NumericUpDown _minCoefficientNumeric;
        private readonly NumericUpDown _maxCoefficientNumeric;

        public VariantsCharacteristicPropertyGeneratorView()
        {
            AddRow(50);
            AddRow(50);
            AddColumn(33);
            AddColumn(33);
            AddColumn(33);

            var variantsCountLabel = AddLabel(0, 0, "Количество вариантов");
            _variantCountNumeric = AddNumeric(0, 1, 4);

            var minCoefficientLabel = AddLabel(1, 0, "Минимальный коэффициент при n");
            _minCoefficientNumeric = AddNumeric(1, 1, -10);
            
            var maxCoefficientLabel = AddLabel(2, 0, "Максимальный коэффициент при n");
            _maxCoefficientNumeric = AddNumeric(2, 1, 10);
        }
        
        public string Id => TaskIds.CharacteristicPropertyTask;
        
        public void Activate()
        {
            _variantCountNumeric.ValueChanged += OnVariantCountChanged;
            _minCoefficientNumeric.ValueChanged += OnMinCoefficientValueChanged;
            _maxCoefficientNumeric.ValueChanged += OnMaxCoefficientValueChanged;
        }

        public void Deactivate()
        {
            _variantCountNumeric.ValueChanged -= OnVariantCountChanged;
            _minCoefficientNumeric.ValueChanged -= OnMinCoefficientValueChanged;
            _maxCoefficientNumeric.ValueChanged -= OnMaxCoefficientValueChanged;
        }

        private void OnVariantCountChanged(object sender, EventArgs e)
        {
            var numeric = (NumericUpDown) sender;
            VariantsCountChanged((int) numeric.Value);
        }

        private void OnMinCoefficientValueChanged(object sender, EventArgs e)
        {
            var numeric = (NumericUpDown) sender;
            MinCoefficientValueChanged((int) numeric.Value);
        }
        
        private void OnMaxCoefficientValueChanged(object sender, EventArgs e)
        {
            var numeric = (NumericUpDown) sender;
            MaxCoefficientValueChanged((int) numeric.Value);
        }
    }
}