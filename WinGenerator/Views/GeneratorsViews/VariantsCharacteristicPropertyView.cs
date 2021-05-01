using System;
using System.Windows.Forms;
using TaskEngine;
using TaskEngine.Views.TaskGenerators;

namespace WinGenerator.Views.GeneratorsViews
{
    public class VariantsCharacteristicPropertyView: VariantsGeneratorView, IVariantsCharacteristicPropertyGeneratorView
    {
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
        
        private readonly NumericUpDown _minCoefficientNumeric;
        private readonly NumericUpDown _maxCoefficientNumeric;

        public VariantsCharacteristicPropertyView(): base(50, 33)
        {
            AddRow(50);
            AddColumn(33);
            AddColumn(33);
            
            var minCoefficientLabel = AddLabel(1, 0, "Минимальный коэффициент при n");
            _minCoefficientNumeric = AddNumeric(1, 1, -10);
            
            var maxCoefficientLabel = AddLabel(2, 0, "Максимальный коэффициент при n");
            _maxCoefficientNumeric = AddNumeric(2, 1, 10);
        }
        
        public override string Id => TaskIds.CharacteristicPropertyTask;
        
        public override void Activate()
        {
            _variantsNumeric.Numeric.ValueChanged += OnVariantCountChanged;
            _minCoefficientNumeric.ValueChanged += OnMinCoefficientValueChanged;
            _maxCoefficientNumeric.ValueChanged += OnMaxCoefficientValueChanged;
        }

        public override void Deactivate()
        {
            _variantsNumeric.Numeric.ValueChanged -= OnVariantCountChanged;
            _minCoefficientNumeric.ValueChanged -= OnMinCoefficientValueChanged;
            _maxCoefficientNumeric.ValueChanged -= OnMaxCoefficientValueChanged;
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