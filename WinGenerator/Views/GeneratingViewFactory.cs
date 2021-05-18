using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TaskEngine.Generators.Tasks;
using TaskEngine.Models.Values;
using WinGenerator.CustomControls;

namespace WinGenerator.Views
{
    public class GeneratingViewFactory
    {
        public View Create(ITaskGenerator generator, int columnCount = 1)
        {
            var values = generator.Values.ToList();
            var rowCount = Math.Max((int) Math.Ceiling((float)values.Count / columnCount), 8);
            
            var view = new GeneratingView(generator.Id);
            var columnScale = 100 / columnCount;
            var rowScale = 100 / rowCount;

            int counter = 0;
            for (int column = 0; column < columnCount; column++)
            {
                view.AddColumn(columnScale);
                for (int row = 0; row < rowCount; row++)
                {
                    view.AddRow(rowScale);
                    if (counter >= values.Count)
                    {
                        view.AddControl(new Panel(), column, row);
                        continue;
                    }
                    var value = values[counter];
                    
                    if (TryGetControl(value, out var control))
                        view.AddControl(control, column, row);
                    else
                        row--;
                    
                    counter++;
                }
            }

            return view;
        }

        private bool TryGetControl(IValue value, out Control control)
        {
            var table = new PercentTableLayoutPanel();
            switch (value)
            {
                case IntValue intValue:
                    var numericControl = table.CreateLabeledNumericControl(intValue.Id);
                    numericControl.ValueChanged += v => intValue.Value = v;
                    numericControl.Value = intValue.Value;
                    numericControl.Numeric.Minimum = intValue.MinValue;
                    numericControl.Numeric.Maximum = intValue.MaxValue;
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