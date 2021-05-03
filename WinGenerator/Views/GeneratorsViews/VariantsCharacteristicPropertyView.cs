using System;
using System.Windows.Forms;
using TaskEngine;
using TaskEngine.Views.TaskGenerators;
using WinGenerator.CustomControls;

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
        
        private readonly LabeledNumericControl _minCoefficientNumeric;
        private readonly LabeledNumericControl _maxCoefficientNumeric;

        public VariantsCharacteristicPropertyView(): base(33)
        {
            AddRow(100);

            var configTable = AddTable(1, 0);
            configTable.AddColumn(50);
            configTable.AddColumn(50);
            _minCoefficientNumeric = configTable.AddLabeledNumeric(0, 0, "Минимальный коэффициент при n", -10);
            _maxCoefficientNumeric = configTable.AddLabeledNumeric(1, 0, "Максимальный коэффициент при n", 10);
        }
        
        public override string Id => TaskIds.CharacteristicPropertyTask;
        
        public override void Activate()
        {
            _variantsNumeric.Numeric.ValueChanged += OnVariantCountChanged;
            _minCoefficientNumeric.Numeric.ValueChanged += OnMinCoefficientValueChanged;
            _maxCoefficientNumeric.Numeric.ValueChanged += OnMaxCoefficientValueChanged;
        }

        public override void Deactivate()
        {
            _variantsNumeric.Numeric.ValueChanged -= OnVariantCountChanged;
            _minCoefficientNumeric.Numeric.ValueChanged -= OnMinCoefficientValueChanged;
            _maxCoefficientNumeric.Numeric.ValueChanged -= OnMaxCoefficientValueChanged;
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