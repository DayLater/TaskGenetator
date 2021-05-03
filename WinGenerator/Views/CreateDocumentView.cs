using System;
using System.Windows.Forms;
using TaskEngine.Views;

namespace WinGenerator.Views
{
    public class CreateDocumentView: View, ICreateDocumentView
    {
        private readonly Button _generateButton;
        private readonly TextBox _fileNameTextBox;
        private readonly NumericUpDown _fileCountNumeric;
     
        public event Action GenerateButtonClicked = () => { };
        public string GetFileName()
        {
            return _fileNameTextBox.Text;
        }

        public int GetFileCount()
        {
            return (int) _fileCountNumeric.Value;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public override string Id => "Создание текстового документа";

        public CreateDocumentView()
        {
            AddRow(33);
            AddRow(33);
            AddRow(34);
            AddColumn(100);
            _fileNameTextBox = AddTextBox(0, 0);
            _fileCountNumeric = AddNumeric(0, 1);
            _generateButton = AddButton(0, 2, "Создать");
        }

        public override void Activate()
        {
            _generateButton.Click += OnGenerateButtonClicked;
        }

        public override void Deactivate()
        {
            _generateButton.Click -= OnGenerateButtonClicked;
        }

        private void OnGenerateButtonClicked(object sender, EventArgs eventArgs)
        {
            GenerateButtonClicked();
        }
    }
}