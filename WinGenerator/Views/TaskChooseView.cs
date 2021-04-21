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

        private TableLayoutPanel _tableLayoutPanel;
        private CheckedListBox _checkedListBox;
        private Button _generateButton;

        public TaskChooseView(MainContext mainContext, Size size, Control.ControlCollection controlCollection, DocWriter docWriter)
        {
            _mainContext = mainContext;
            _size = size;
            _controlCollection = controlCollection;
            _docWriter = docWriter;
        }

        public void Activate()
        {
            _generateButton = new Button {Dock = DockStyle.Fill, Text = @"Generate"};
            _generateButton.Click += OnClick;

            _checkedListBox = new CheckedListBox {Dock = DockStyle.Left, Width = _size.Width / 2};
            var allTaskControllers = _mainContext.TaskControllersContext.GetControllers().ToList();
            _checkedListBox.DataSource = allTaskControllers;
            _checkedListBox.DisplayMember = "Id";
            _checkedListBox.SelectedIndexChanged += OnSelectedIndexChanged;
            
            _tableLayoutPanel = new TableLayoutPanel() {Dock = DockStyle.Fill};
            _tableLayoutPanel.RowStyles.Clear();
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            
            _tableLayoutPanel.Controls.Add(_checkedListBox, 0, 0);
            _tableLayoutPanel.Controls.Add(_generateButton,0, 1);
            _tableLayoutPanel.Controls.Add(new Panel(), 0, 2);
            
            _controlCollection.Add(_tableLayoutPanel);
        }

        public void Deactivate()
        {
            _checkedListBox.SelectedIndexChanged -= OnSelectedIndexChanged;
            _generateButton.Click += OnClick;
            _controlCollection.Remove(_tableLayoutPanel);

            _generateButton = null;
            _checkedListBox = null;
            _tableLayoutPanel = null;
        }
        
        private void OnClick(object sender, EventArgs e)
        {
            var controllers =  _checkedListBox.CheckedItems.Cast<ITaskController>();
            var tasks = controllers.Select(c => c.Generate());
            _docWriter.Write("TestDoc", tasks);
        }
        
        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var list = (CheckedListBox) sender;
        }
    }
}