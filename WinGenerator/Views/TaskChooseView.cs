using System;
using System.Drawing;
using System.Windows.Forms;
using TaskEngine.Contexts;
using TaskEngine.Presenters;
using TaskEngine.Views;
using WinGenerator.CustomControls;

namespace WinGenerator.Views
{
    public class TaskChooseView: PercentTableLayoutPanel, IView
    {
        private readonly CheckedListBox _checkedListBox;
        private readonly Label _exampleText;
        private readonly PercentTableLayoutPanel _generatorSettingsTable;

        public TaskChooseView(MainContext mainContext)
        {
            _checkedListBox = new CheckedListBox
            {
                Dock = DockStyle.Fill,
                DataSource = mainContext.TaskPresentersContext.Presenters,
                DisplayMember = "Id"
            };

            RowStyles.Clear();
            AddRow(60);
            AddRow(40);
            AddColumn(100);

            var topTable = AddTable(0, 0);
            topTable.AddColumn(40);
            topTable.AddColumn(60);
            topTable.AddRow(100);
            topTable.AddControl(_checkedListBox, 0, 0);
            
            var exampleTable = topTable.AddTable(1, 0);
            exampleTable.AddRow(15);
            exampleTable.AddRow(85);
            exampleTable.AddColumn(100);
            
            var exampleTopText = exampleTable.AddLabel(0, 0, @"Пример задания");
            exampleTopText.Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Underline);

            _exampleText = exampleTable.AddLabel(0, 1);
            _exampleText.Font = new Font(FontFamily.GenericMonospace, 10);
            
            _generatorSettingsTable = AddTable(0, 1);
            _generatorSettingsTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            _generatorSettingsTable.AddRow(10);
            _generatorSettingsTable.AddRow(90);
            _generatorSettingsTable.AddColumn(100);
            var generatorSettingsTopText = _generatorSettingsTable.AddLabel(0, 0);
            generatorSettingsTopText.Font = new Font(FontFamily.GenericMonospace, 10, FontStyle.Underline);
            generatorSettingsTopText.Text = @"Настройка генерации задания";
        }

        public string Id => "Выбор и настройка заданий";

        public void Activate()
        {
            OnSelectedItem(_checkedListBox, EventArgs.Empty);
            _checkedListBox.SelectedIndexChanged += OnSelectedItem;
        }

        public void Deactivate()
        {
            _checkedListBox.SelectedIndexChanged -= OnSelectedItem;
        }
        
        private void OnSelectedItem(object sender, EventArgs e)
        {
            var presenter = (ITaskPresenter) _checkedListBox.SelectedItem;
            _exampleText.Text = presenter.ExampleTask;
            if (_generatorSettingsTable.Controls.Count > 1)
            {
                _generatorSettingsTable.Controls.RemoveAt(1);
            }
            
            _generatorSettingsTable.AddView(presenter.GeneratorView);
        }
    }
}