using System;
using System.Collections.Generic;

namespace TaskEngine.Views
{
    public interface ITaskChooseView: IView
    {
        event Action<string> SelectedItemChanged;
        event Action<string, bool> ItemFlagChanged;
        event Action OpenConfigureButtonClicked;
        event Action SelectAllClicked;
        event Action DeselectAllClicked;

        void SelectAll();
        void DeselectAll();
        void SetItems(IEnumerable<string> items);

        void SetExampleText(string name, string example);
        void OpenGeneratorSettings(string generatorId);
    }
}