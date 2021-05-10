using System;

namespace TaskEngine.Views
{
    public interface ICreateDocumentView: IView
    {
        event Action GenerateButtonClicked;
        event Action FileDialogButtonClicked;

        string FileName { get; set; }
        int FileCount { get; set; }
        string Path { get; set; }
        void ShowMessage(string message);
        bool TryGetFolderPath(out string path);
        
        string TitleFont { get; }
        string TextFont { get; }
        int TitleFontSize { get; set; }
        int TextFontSize { get; set; }
        bool IsCreateDirectory { get; }
    }
}