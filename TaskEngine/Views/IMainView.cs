using System;

namespace TaskEngine.Views
{
    public interface IMainView
    {
        event Action NextButtonClicked;
        public bool NextButtonEnable { get; set; }

        event Action PreviousButtonClicked;
        public bool PreviousButtonEnable { get; set; }
        public bool Contains(int viewId);
        public void SetView(int viewId);
    }
}