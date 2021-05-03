using System;
using System.Windows.Forms;
using TaskEngine.Values;

namespace WinGenerator.CustomControls
{
    public class LabeledNumericControl: PercentTableLayoutPanel, IIdentified
    {
        public NumericUpDown Numeric { get; }
        private readonly Label _label;
        public event Action<int> ValueChanged = i => { };  

        public LabeledNumericControl(string labelText, int numericSizeInPercent = 40)
        {
            Id = labelText;
            var labelSize = 100 - numericSizeInPercent;
            AddColumn(100);
            AddRow(labelSize);
            AddRow(numericSizeInPercent);

            _label = AddLabel(0, 0, labelText);
            Numeric = AddNumeric(0, 1);
            Numeric.ValueChanged += (sender, args) => ValueChanged(Value);
        }

        public int Value
        {
            get => (int) Numeric.Value;
            set => Numeric.Value = value;
        }

        public string Id { get; }
    }
}