using System;
using System.Drawing;
using System.Windows.Forms;
using TaskEngine.Contexts;
using TaskEngine.DocWriters;
using TaskEngine.Writers;
using WinGenerator.Views;

namespace WinGenerator
{
    public sealed class MainForm: Form
    {
        private readonly DocWriter _docWriter = new DocWriter();
        private readonly Contexts _contexts;

        public MainForm()
        {
            var size = new Size(1024, 768);
            MinimumSize = size;
            Size = size;
           
            _contexts = new Contexts(new SetWriter(new ExpressionWriter(), 10), new Random(), new ViewContext());
            
            Controls.Add((Control)_contexts.ViewContext.MainView);
        }
    }
}