using System;
using System.Windows.Forms;
using TaskEngine.Views;

namespace WinGenerator.Views
{
    public class EmptyView: View
    {
        public override string Id => string.Empty;
    }
}