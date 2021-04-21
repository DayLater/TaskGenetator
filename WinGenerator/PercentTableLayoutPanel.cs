﻿using System.Drawing;
using System.Windows.Forms;

namespace WinGenerator
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
        public void AddEmptyControl(int column, int row) => AddControl(new Panel(), column, row);

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
        
        public Button AddButton(int column, int row, string text = null)
        {
            var button = new Button() {Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = text};
            AddControl(button, column, row);
            return button;
        }
        
        public NumericUpDown AddNumeric(int column, int row, int startValue)
        {
            var numericUpDown = new NumericUpDown() {Dock = DockStyle.Fill, Value = startValue};
            AddControl(numericUpDown, column, row);
            return numericUpDown;
        }
    }
}