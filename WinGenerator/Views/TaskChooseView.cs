using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TaskEngine.Contexts;
using TaskEngine.Controllers;
using TaskEngine.DocWriters;
using TaskEngine.Views;

namespace WinGenerator.Views
{
    public class TaskChooseView: PercentTableLayoutPanel, IView
    {
        private readonly DocWriter _docWriter;
        
        private readonly CheckedListBox _checkedListBox;
        private readonly Button _generateButton;
        private readonly Label _exampleText;
        private readonly PercentTableLayoutPanel _generatorSettingsTable;

        public TaskChooseView(MainContext mainContext, DocWriter docWriter)
        {
            _docWriter = docWriter;
            
            _checkedListBox = new CheckedListBox {Dock = DockStyle.Fill};
            var allTaskControllers = mainContext.TaskControllersContext.GetControllers().ToList();
            _checkedListBox.DataSource = allTaskControllers;
            _checkedListBox.DisplayMember = "Id";
            
            RowStyles.Clear();
            AddRow(60);
            AddRow(35);
            AddRow(5);
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
            _generatorSettingsTable.AddRow(10);
            _generatorSettingsTable.AddRow(90);
            _generatorSettingsTable.AddColumn(100);
            var generatorSettingsTopText = _generatorSettingsTable.AddLabel(0, 0);
            generatorSettingsTopText.Font = new Font(FontFamily.GenericMonospace, 10, FontStyle.Underline);
            generatorSettingsTopText.Text = @"Настройка генерации задания";
            
            _generateButton = AddButton(0, 2, @"Generate");
        }

        public string Id => "Выбор и настройка заданий";

        public void Activate()
        {
            OnSelectedItem(_checkedListBox, EventArgs.Empty);
            _generateButton.Click += OnClick;
            _checkedListBox.SelectedIndexChanged += OnSelectedItem;
        }

        public void Deactivate()
        {
            _generateButton.Click -= OnClick;
            _checkedListBox.SelectedIndexChanged -= OnSelectedItem;
        }

        private void OnClick(object sender, EventArgs e)
        {
            var controllers =  _checkedListBox.CheckedItems.Cast<ITaskController>();
            var tasks = controllers.Select(c => c.Generate());
            _docWriter.Write("TestDoc", tasks);
        }

        private void OnSelectedItem(object sender, EventArgs e)
        {
            var controller = (ITaskController) _checkedListBox.SelectedItem;
            var task = controller.Generate();
            _exampleText.Text = task.Task;
            if (_generatorSettingsTable.Controls.Count > 0)
            {
                _generatorSettingsTable.Controls.RemoveAt(0);
            }
            
            _generatorSettingsTable.AddView(controller.GeneratorView);
        }
    }
}