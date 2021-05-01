using System;

namespace TaskEngine.Views
{
    public interface ICreateDocumentView: IView
    {
        event Action GenerateButtonClicked;
    }
}