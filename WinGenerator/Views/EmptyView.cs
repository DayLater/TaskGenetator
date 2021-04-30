using System;
using System.Windows.Forms;
using TaskEngine.Views;

namespace WinGenerator.Views
{
    public class EmptyView: View, IView
    {
        public override string Id => string.Empty;
            
        public override void Activate()
        {
        }

        public override void Deactivate()
        {
        }
    }
}