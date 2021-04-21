using System;
using System.Drawing;
using System.Windows.Forms;
using TaskEngine.Contexts;
using TaskEngine.DocWriters;
using TaskEngine.Writers;
using WinGenerator.Views;

namespace WinGenerator
{
    public class MainForm: Form
    {
        private readonly DocWriter _docWriter = new DocWriter();
        private readonly MainContext _mainContext;
        
        
        public MainForm()
        {
            Size = new Size(800, 600);
           
            _mainContext = new MainContext(new SetWriter(new ExpressionWriter(), 10), new Random());
            var taskChooseView = new TaskChooseView(_mainContext, Size, Controls, _docWriter);

            var isActive = false;
            var button = new Button()
            {
                Size = new Size(30, 100),
                Location = new Point(0, Size.Height - 100)
            };
            
            Controls.Add(button);
            button.Click += (sender, args) =>
            {
                if (!isActive)
                {
                    isActive = true;
                    taskChooseView.Activate();
                }
                else
                {
                    isActive = false;
                    taskChooseView.Deactivate();
                }
            };
        }
    }
}