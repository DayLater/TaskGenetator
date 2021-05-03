using System;
using System.Drawing;
using System.Windows.Forms;
using TaskEngine.Contexts;
using TaskEngine.Writers;
using WinGenerator.Views;

namespace WinGenerator
{
    public sealed class MainForm: Form
    {
        public MainForm()
        {
            var size = new Size(1024, 768);
            MinimumSize = size;
            Size = size;
            
            var setWriter = new SetWriter(new ExpressionWriter(), 10);
            var random = new Random();
            var contexts = new Contexts(setWriter, random);
            
            Controls.Add((Control) contexts.ViewContext.MainView);
            contexts.ViewContext.MainView.Activate();
        }
    }
}