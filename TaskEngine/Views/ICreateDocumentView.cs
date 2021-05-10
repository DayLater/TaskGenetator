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
        
        public string TitleFont { get; }
        public string TextFont { get; }
        public int TitleFontSize { get; set; }
        public int TextFontSize { get; set; }
    }
}