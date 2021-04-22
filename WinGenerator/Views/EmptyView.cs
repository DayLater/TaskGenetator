using System;
using System.Windows.Forms;
using TaskEngine.Views;

namespace WinGenerator.Views
{
    public class EmptyView: Control, IView
    {
        public string Id => string.Empty;
            
        public void Activate()
        {
        }

        public void Deactivate()
        {
        }

        public object GetControl()
        {
            return null;
        }
    }
}