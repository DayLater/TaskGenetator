using System;
using System.Windows.Forms;

namespace WinGenerator.CustomControls
{
    public class LabeledNumericControl: PercentTableLayoutPanel
    {
        public NumericUpDown Numeric { get; }
        private readonly Label _label;

        public LabeledNumericControl(string labelText, int startValue, int numericSizeInPercent = 50)
        {
            var labelSize = 100 - numericSizeInPercent;
            AddColumn(100);
            AddRow(labelSize);
            AddRow(numericSizeInPercent);

            _label = AddLabel(0, 0, labelText);
            Numeric = AddNumeric(0, 1, startValue);
        }

        public int Value
        {
            get => (int) Numeric.Value;
            set => Numeric.Value = value;
        } 
    }
}