using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsGenerator.CustomControls;
using TaskEngine.Generators.Tasks;
using TaskEngine.Models.Values;
using TaskEngine.Views;

namespace WindowsGenerator.Views
{
    public class GeneratingViewFactory
    {
        public IView Create(ITaskGenerator generator, int columnCount = 1)
        {
            var values = generator.ToList();
            if (values.Count == 0)
                return new EmptyView();
            
            var rowCount = Math.Max((int) Math.Ceiling((float) values.Count / columnCount), 8);
            var columnScale = 100 / columnCount;
            var rowScale = 100 / rowCount;

            var controls = new List<Control>();
            foreach (var value in values.Where(v => v is IntValue))
            {
                if (TryGetControl(value, out var control))
                    controls.Add(control);
            }
            
            foreach (var value in values.Where(v => v is BoolValue))
            {
                if (TryGetControl(value, out var control))
                    controls.Add(control);
            }
            
            var view = new GeneratingView(generator.Id);
            int counter = 0;
            for (int column = 0; column < columnCount; column++)
            {
                view.AddColumn(columnScale);
                for (int row = 0; row < rowCount; row++)
                {
                    view.AddRow(rowScale);
                    view.AddControl(counter >= values.Count ? new Panel() : controls[counter], column, row);
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