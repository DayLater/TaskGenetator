using System;
using TaskEngine.Views;

namespace WinGenerator.Views
{
    public class EmptyView: IView
    {
        public string Name => string.Empty;
            
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