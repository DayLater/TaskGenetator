using System;
using System.Drawing;
using System.Windows.Forms;
using TaskEngine.Contexts;
using TaskEngine.DocWriters;
using TaskEngine.Writers;
using WinGenerator.CustomControls;
using WinGenerator.Views;

namespace WinGenerator
{
    public class MainForm: Form
    {
        private readonly DocWriter _docWriter = new DocWriter();
        private readonly MainContext _mainContext;

        public MainForm()
        {
            var size = new Size(1024, 768);
            MinimumSize = size;
            Size = size;
           
            _mainContext = new MainContext(new SetWriter(new ExpressionWriter(), 10), new Random(), new ViewContext());
            var isActive = false;
            var nextButton = new Button()
            {
                Dock = DockStyle.Fill,
                Text = @"Next"
            };
            var label = new Label() 
            {
                Dock = DockStyle.Fill, 
                TextAlign = ContentAlignment.MiddleCenter, 
                Text = @"Старт", 
                Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
            };
            
            var highTablePanel = new PercentTableLayoutPanel();
            highTablePanel.AddRow(90);
            highTablePanel.AddColumn(100);
            
            var taskChooseView = new TaskChooseView(_mainContext);
            
            var bottomTablePanel = new PercentTableLayoutPanel();
            bottomTablePanel.AddColumn(25);
            bottomTablePanel.AddColumn(25);
            bottomTablePanel.AddColumn(25);
            bottomTablePanel.AddColumn(25);
            bottomTablePanel.AddControl(nextButton, 3, 0); 
            
            var mainPanel = new PercentTableLayoutPanel() {CellBorderStyle = TableLayoutPanelCellBorderStyle.Single};
            mainPanel.AddRow(5);
            mainPanel.AddRow(85);
            mainPanel.AddRow(10);
            mainPanel.AddColumn(100);
            mainPanel.AddControl(label, 0,0);
            mainPanel.AddControl(highTablePanel, 0, 1);
            mainPanel.AddControl(bottomTablePanel, 0, 2);

            var treeView = new CustomTreeView() {Dock = DockStyle.Fill, CheckBoxes = true};
            var firstNode = treeView.AddNode("Test");
            firstNode.AddNode("under");
            firstNode.AddNode("second");

            Controls.Add(mainPanel);
            
            nextButton.Click += (sender, args) =>
            {
                if (!isActive)
                {
                    isActive = true;
                    highTablePanel.AddControl(taskChooseView, 0, 0);
                    taskChooseView.Activate();
                    label.Text = taskChooseView.Id;
                }
                else
                {
                    isActive = false;
                    highTablePanel.Controls.RemoveAt(0);
                    highTablePanel.Controls.Add(treeView);
                    taskChooseView.Deactivate();
                }
            };
        }
    }
}