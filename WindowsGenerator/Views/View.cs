using WindowsGenerator.CustomControls;
using TaskEngine.Views;

namespace WindowsGenerator.Views
{
    public abstract class View: PercentTableLayoutPanel, IView
    {
        public abstract string Id { get; }
    }
}