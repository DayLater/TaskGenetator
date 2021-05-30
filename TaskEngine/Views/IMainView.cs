using System;

namespace TaskEngine.Views
{
    public interface IMainView: IView
    {
        event Action NextButtonClicked;
        public bool NextButtonEnable { get; set; }

        event Action PreviousButtonClicked;
        public bool PreviousButtonEnable { get; set; }

        public int TabsCount { get; }
        event Action<int> SelectedTabChanged; 
        public void SetTab(int tabIndex);
    }
}