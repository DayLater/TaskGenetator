using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TaskEngine.Views;
using WinGenerator.CustomControls;
using WinGenerator.Views.GeneratorsViews;

namespace WinGenerator.Views
{
    public class TaskChooseView: View, ITaskChooseView
    {
        private readonly CheckedListBox _checkedListBox;
        private readonly Label _exampleTextLabel;
        private readonly PercentTableLayoutPanel _generatorSettingsTable;
        private readonly GeneratorViews _generatorViews;
        
        public override string Id => "Выбор и настройка заданий";

        public event Action<string> SelectedItemChanged = s => { };
        public event Action<string, bool> ItemFlagChanged = (s, b) => { };
        public event Action Activated = () => { };
        
        public TaskChooseView(GeneratorViews generatorViews, List<string> taskIds)
        {
            _generatorViews = generatorViews;
            
            RowStyles.Clear();
            AddRow(60);
            AddRow(40);
            AddColumn(100);

            var topTable = AddTable(0, 0);
            topTable.AddColumn(40);
            topTable.AddColumn(60);
            topTable.AddRow(100);
            _checkedListBox = topTable.AddCheckedListBox(0, 0, taskIds);
            
            var exampleTable = topTable.AddTable(1, 0);
            exampleTable.AddRow(15);
            exampleTable.AddRow(85);
            exampleTable.AddColumn(100);
            
            var exampleTopText = exampleTable.AddLabel(0, 0, @"Пример задания");
            exampleTopText.Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Underline);

            _exampleTextLabel = exampleTable.AddLabel(0, 1);
            _exampleTextLabel.Font = new Font(FontFamily.GenericMonospace, 10);
            _exampleTextLabel.TextAlign = ContentAlignment.TopLeft;
            
            _generatorSettingsTable = AddTable(0, 1);
            _generatorSettingsTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            _generatorSettingsTable.AddRow(10);
            _generatorSettingsTable.AddRow(90);
            _generatorSettingsTable.AddColumn(100);
            var generatorSettingsTopText = _generatorSettingsTable.AddLabel(0, 0);
            generatorSettingsTopText.Font = new Font(FontFamily.GenericMonospace, 10, FontStyle.Underline);
            generatorSettingsTopText.Text = @"Настройка генерации задания";
        }
        
        public void SetExampleText(string example)
        {
            _exampleTextLabel.Text = example;
        }

        public void ReplaceGeneratorView(string viewId)
        {
            if (_generatorSettingsTable.Controls.Count > 1)
            {
                _generatorSettingsTable.Controls.RemoveAt(1);
            }

            var view = _generatorViews.Get(viewId);
            _generatorSettingsTable.AddView(view);
        }

        public void SetCheckToTasks(IEnumerable<string> taskIds)
        {
            foreach (var taskId in taskIds)
            {
                if (_checkedListBox.Items.Contains(taskId))
                {
                    var idIndex = _checkedListBox.FindStringExact(taskId);
                    _checkedListBox.SetItemChecked(idIndex, true);
                }
            }
        }

        public override void Activate()
        {
            OnSelectedItemChanged(_checkedListBox, EventArgs.Empty);
            _checkedListBox.SelectedIndexChanged += OnSelectedItemChanged;
            _checkedListBox.ItemCheck += OnItemCheck;
            Activated();
        }

        public override void Deactivate()
        {
            _checkedListBox.SelectedIndexChanged -= OnSelectedItemChanged;
            _checkedListBox.ItemCheck -= OnItemCheck;
        }
        
        private void OnSelectedItemChanged(object sender, EventArgs e)
        {
            var itemId = (string) _checkedListBox.SelectedItem;
            SelectedItemChanged(itemId);
        }

        private void OnItemCheck(object sender, ItemCheckEventArgs e)
        {
            var itemId = (string) _checkedListBox.Items[e.Index];
            var isChecked = _checkedListBox.GetItemChecked(e.Index);
            ItemFlagChanged(itemId, isChecked);
        }
    }
}