﻿using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace WindowsGenerator.CustomControls
{
    public class PercentTableLayoutPanel: TableLayoutPanel
    {
        public PercentTableLayoutPanel()
        {
            Dock = DockStyle.Fill;
        }
        
        public void AddRow(int height) => RowStyles.Add(new RowStyle(SizeType.Percent, height));
        public void AddColumn(int width) => ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));
        
        public void AddControl(Control control, int column, int row)
        {
            Controls.Add(control, column, row);
        }

        public MaterialCard AddCard(int column, int row)
        {
            var card = new MaterialCard() {Dock = DockStyle.Fill};
            AddControl(card, column, row);
            return card;
        }

        public MaterialCheckedListBox AddCheckedListBox(int column, int row)
        {
            var list = new MaterialCheckedListBox {Dock = DockStyle.Fill};

            AddControl(list, column, row);
            return list;
        }

        public MaterialSwitch AddSwitch(int column, int row, string text, bool defaultValue = true)
        {
            var materialSwitch = new MaterialSwitch() {Text = text, Checked = defaultValue, AutoSize = true};
            AddControl(materialSwitch, column, row);
            return materialSwitch;
        }

        public PercentTableLayoutPanel AddTable(int column, int row)
        {
            var table = new PercentTableLayoutPanel();
            AddControl(table, column, row);
            return table;
        }
        
        public MaterialLabel AddLabel(int column, int row, MaterialSkinManager.fontType fontType, string text = null, bool highEmphasis = false)
        {
            var label = new MaterialLabel {Dock = DockStyle.Fill, TextAlign = ContentAlignment.TopLeft, FontType = fontType, Text = text, AutoSize = false, HighEmphasis = highEmphasis};
            AddControl(label, column, row);
            return label;
        }

        public MaterialTextBox AddTextBox(int column, int row, string hint)
        {
            var textBox = new MaterialTextBox {Dock = DockStyle.Fill, Hint = hint, UseTallSize = true};
            AddControl(textBox, column, row);
            return textBox;
        }
        
        public MaterialButton AddButton(int column, int row, string text = null)
        {
            var button = new MaterialButton
            {
                Dock = DockStyle.Fill, 
                TextAlign = ContentAlignment.MiddleCenter, 
                Text = text
            };
            AddControl(button, column, row);
            return button;
        }
        
        public NumericUpDown AddNumeric(int column, int row)
        {
            var numericUpDown = new NumericUpDown
            {
                TextAlign = HorizontalAlignment.Center, Minimum = -100, Maximum = 100, UpDownAlign = LeftRightAlignment.Left,
                Dock = DockStyle.Top
            };
            AddControl(numericUpDown, column, row);
            return numericUpDown;
        }
        
        public LabeledNumericControl AddLabeledNumeric(int column, int row, string text)
        {
            var labeledNumericControl = CreateLabeledNumericControl(text);
            AddControl(labeledNumericControl, column, row);
            return labeledNumericControl;
        }

        public MaterialComboBox AddComboBox(int column, int row, string hint, string[] items)
        {
            var comboBox = new MaterialComboBox {Dock = DockStyle.Fill, Hint = hint, DropDownStyle = ComboBoxStyle.DropDownList};
            comboBox.Items.AddRange(items);
            comboBox.SelectedIndex = 0;
            AddControl(comboBox, column, row);
            return comboBox;
        }
        
        public LabeledNumericControl CreateLabeledNumericControl(string text) => new LabeledNumericControl(text) {Dock = DockStyle.Fill};
        public CheckBox CreateCheckBox(string text) => new MaterialCheckbox {Dock = DockStyle.Fill, Text = text};
    }
}