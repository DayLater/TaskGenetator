using System;
using System.Linq;
using System.Windows.Forms;
using TaskEngine.Generators.Tasks;
using TaskEngine.Values;
using WinGenerator.CustomControls;

namespace WinGenerator.Views
{
    public class GeneratingViewFactory
    {
        public View Create(Generator generator, string id, int rowCount = 1)
        {
            var values = generator.Values.ToList();
            var columnCount = (int) Math.Ceiling((float)values.Count / rowCount);
            
            var view = new GeneratingView(id);
            var rowScale = 100 / rowCount;
            var columnScale = 100 / columnCount;

            int counter = 0;
            for (int row = 0; row < rowCount; row++)
            {
                view.AddRow(rowScale);
                for (int column = 0; column < columnCount; column++)
                {
                    if (counter >= values.Count)
                        break;
                    view.AddColumn(columnScale);
                    var value = values[counter];
                    var control = GetControl(value);
                    view.AddControl(control, column, row);
                    counter++;
                }
            }

            return view;
        }

        private Control GetControl(IValue value)
        {
            var table = new PercentTableLayoutPanel();
            switch (value)
            {
                case IntValue intValue:
                    var numericControl = table.CreateLabeledNumericControl(intValue.Id);
                    numericControl.ValueChanged += v => intValue.Value = v;
                    numericControl.Value = intValue.Value;
                    return numericControl;
                case BoolValue boolValue:
                    var checkBox = table.CreateCheckBox(boolValue.Id);
                    checkBox.Checked = boolValue.Value;
                    checkBox.CheckedChanged += (sender, args) => boolValue.Value = checkBox.Checked;
                    return checkBox;
            }
            
            throw new ArgumentException();
        }
    }
}