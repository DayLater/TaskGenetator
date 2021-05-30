using System.Windows.Forms;
using TaskEngine.Views;

namespace WindowsGenerator.Views.Tabs
{
    public abstract class IdentifiedTabPage: TabPage, IView
    {
        protected IdentifiedTabPage(string id)
        {
            Id = id;
            Name = id;
            Text = id;
        }

        public string Id { get; }
    }
}