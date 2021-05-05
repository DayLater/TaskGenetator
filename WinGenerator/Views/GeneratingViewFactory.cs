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
        public View Create(IValued generator, string id, int rowCount = 1)
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

                    if (GetControl(value, out var control))
                        view.AddControl(control, column, row);
                    counter++;
                }
            }

            return view;
        }

        private bool GetControl(IValue value, out Control control)
        {
            var table = new PercentTableLayoutPanel();
            switch (value)
            {
                case IntValue intValue:
                    var numericControl = table.CreateLabeledNumericControl(intValue.Id);
                    numericControl.ValueChanged += v => intValue.Value = v;
                    numericControl.Value = intValue.Value;
                    control = numericControl;
                    return true;
                case BoolValue boolValue:
                    var checkBox = table.CreateCheckBox(boolValue.Id);
                    checkBox.Checked = boolValue.Value;
                    checkBox.CheckedChanged += (sender, args) => boolValue.Value = checkBox.Checked;
                    control = checkBox;
                    return true;
            }

            control = null;
            return false;
        }
    }
}