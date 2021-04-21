using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TaskEngine.Contexts;
using TaskEngine.Controllers;
using TaskEngine.DocWriters;

namespace WinGenerator.Views
{
    public class TaskChooseView: IView
    {
        private readonly MainContext _mainContext;
        private readonly Control.ControlCollection _controlCollection;
        private readonly Size _size;
        private readonly DocWriter _docWriter;

        private PercentTableLayoutPanel _mainTable;
        private CheckedListBox _checkedListBox;
        private Button _generateButton;
        private Label _exampleText;

        public TaskChooseView(MainContext mainContext, Size size, Control.ControlCollection controlCollection, DocWriter docWriter)
        {
            _mainContext = mainContext;
            _size = size;
            _controlCollection = controlCollection;
            _docWriter = docWriter;
        }

        public string Name => "Выбор и настройка заданий";

        public void Activate()
        {
            _generateButton = new Button {Dock = DockStyle.Fill, Text = @"Generate"};
            _generateButton.Click += OnClick;

            _checkedListBox = new CheckedListBox {Dock = DockStyle.Fill};
            var allTaskControllers = _mainContext.TaskControllersContext.GetControllers().ToList();
            _checkedListBox.DataSource = allTaskControllers;
            _checkedListBox.DisplayMember = "Id";
            _checkedListBox.SelectedIndexChanged += OnSelectedItem;

            _mainTable = new PercentTableLayoutPanel();
            _mainTable.RowStyles.Clear();
            _mainTable.AddRow(50);
            _mainTable.AddRow(50);
            _mainTable.AddColumn(100);

            var topTable = _mainTable.AddTable(0, 0);
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
            
            _mainTable.AddControl(_generateButton,0, 1);
            _mainTable.AddEmptyControl(0, 2);

            _controlCollection.Add(_mainTable);
            OnSelectedItem(_checkedListBox, EventArgs.Empty);
        }

        public void Deactivate()
        {
            _generateButton.Click += OnClick;
            _checkedListBox.SelectedIndexChanged -= OnSelectedItem;
            _controlCollection.Remove(_mainTable);

            _generateButton = null;
            _checkedListBox = null;
            _mainTable = null;
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
        }
    }
}