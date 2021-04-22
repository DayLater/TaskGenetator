using System;
using System.Windows.Forms;
using TaskEngine;
using TaskEngine.Views;

namespace WinGenerator.Views.GeneratorsViews
{
    public class TestableCharacteristicPropertyGeneratorView: PercentTableLayoutPanel, IVariantsCharacteristicPropertyGeneratorView
    {
        private readonly NumericUpDown _variantCountNumeric;

        public TestableCharacteristicPropertyGeneratorView(int startValue)
        {
            AddRow(50);
            AddRow(50);
            AddColumn(33);
            AddColumn(33);
            AddColumn(33);

            var variantsCountLabel = AddLabel(0, 0, "Количество вариантов");
            _variantCountNumeric = AddNumeric(0, 1, startValue);
        }

        public event Action<int> VariantsCountChanged = i => { };

        public string Id => TaskIds.CharacteristicPropertyTask;
        
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
    }
}