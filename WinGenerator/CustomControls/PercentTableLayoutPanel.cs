﻿using System.Drawing;
using System.Windows.Forms;
using TaskEngine.Views;

namespace WinGenerator.CustomControls
{
    public class PercentTableLayoutPanel: TableLayoutPanel
    {
        public PercentTableLayoutPanel()
        {
            Dock = DockStyle.Fill;
        }
        
        public void AddRow(int height) => RowStyles.Add(new RowStyle(SizeType.Percent, height));
        public void AddColumn(int width) => ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));
        public void AddControl(Control control, int column, int row) => Controls.Add(control, column, row);

        public PercentTableLayoutPanel AddTable(int column, int row)
        {
            var table = new PercentTableLayoutPanel();
            AddControl(table, column, row);
            return table;
        }
        
        public Label AddLabel(int column, int row, string text = null)
        {
            var label = new Label() {Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = text};
            AddControl(label, column, row);
            return label;
        }

        public TextBox AddTextBox(int column, int row, string text = "default")
        {
            var textBox = new TextBox() {Dock = DockStyle.Fill, TextAlign = HorizontalAlignment.Left, Text = text};
            AddControl(textBox, column, row);
            return textBox;
        }
        
        public Button AddButton(int column, int row, string text = null)
        {
            var button = new Button() {Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = text};
            AddControl(button, column, row);
            return button;
        }
        
        public NumericUpDown AddNumeric(int column, int row, int startValue)
        {
            var numericUpDown = new NumericUpDown
            {
                TextAlign = HorizontalAlignment.Center, Minimum = -100, Maximum = 100, Value = startValue, UpDownAlign = LeftRightAlignment.Left,
                Dock = DockStyle.Top
            };
            AddControl(numericUpDown, column, row);
            return numericUpDown;
        }
        
        public LabeledNumericControl AddLabeledNumeric(int column, int row, string text, int startValue)
        {
            var labeledNumericControl = CreateLabeledNumericControl(text, startValue);
            AddControl(labeledNumericControl, column, row);
            return labeledNumericControl;
        }
        
        public LabeledNumericControl CreateLabeledNumericControl(string text, int startValue) => new LabeledNumericControl(text, startValue) {Dock = DockStyle.Fill};

        public CheckBox AddCheckBox(int column, int row, string text)
        {
            var checkBox = new CheckBox {Dock = DockStyle.Fill, Text = text};
            AddControl(checkBox, column, row);
            return checkBox;
        }

        public void AddView(IView view)
        {
            view.Activate();
            Controls.Add((Control) view);
        }

        public bool Remove(IView view)
        {
            view.Deactivate();
            if (view is Control control && Controls.Contains(control))
            {
                Controls.Remove(control);
                return true;
            }
            
            return false;
        }
    }
}