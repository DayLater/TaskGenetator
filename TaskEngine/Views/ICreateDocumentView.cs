using System;

namespace TaskEngine.Views
{
    public interface ICreateDocumentView: IView
    {
        event Action GenerateButtonClicked;
        string GetFileName();
        int GetFileCount();
        void ShowMessage(string message);
    }
}