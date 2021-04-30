using System;

namespace TaskEngine.Views
{
    public interface ITaskChooseView: IView
    {
        event Action<string> SelectedItemChanged;
        event Action<string, bool> ItemFlagChanged; 
        void SetExampleText(string example);
        void ReplaceGeneratorView(string viewId);
    }
}