using System;
using System.Collections.Generic;

namespace TaskEngine.Views
{
    public interface ITaskChooseView: IView
    {
        event Action<string> SelectedItemChanged;
        event Action<string, bool> ItemFlagChanged;
        event Action Activated;
        
        void SetExampleText(string example);
        void ReplaceGeneratorView(string viewId);
        void SetCheckToTasks(IEnumerable<string> taskIds);
    }
}