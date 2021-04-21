using System;
using System.Windows.Forms;
using TaskEngine;
using TaskEngine.Views;

namespace WinGenerator.Views.GeneratorsViews
{
    public class TestableCharacteristicPropertyGeneratorView: IVariantsCharacteristicPropertyGeneratorView
    {
        private readonly PercentTableLayoutPanel _mainTable;
        private readonly NumericUpDown _variantCountNumeric;

        public TestableCharacteristicPropertyGeneratorView(int startValue)
        {
            _mainTable = new PercentTableLayoutPanel();
            _mainTable.AddRow(50);
            _mainTable.AddRow(50);
            _mainTable.AddColumn(33);
            _mainTable.AddColumn(33);
            _mainTable.AddColumn(33);

            var variantsCountLabel = _mainTable.AddLabel(0, 0, "Количество вариантов");
            _variantCountNumeric = _mainTable.AddNumeric(0, 1, startValue);
        }

        public event Action<int> VariantsCountChanged = i => { };

        public string Name => TaskIds.CharacteristicPropertyTask;
        
        public void Activate()
        {
            _variantCountNumeric.ValueChanged += OnVariantCountChanged;
        }

        private void OnVariantCountChanged(object sender, EventArgs e)
        {
            var numeric = (NumericUpDown) sender;
            VariantsCountChanged((int) numeric.Value);
        }

        public void Deactivate()
        {
            _variantCountNumeric.ValueChanged -= OnVariantCountChanged;
        }

        public object GetControl()
        {
            return _mainTable;
        }
    }
}