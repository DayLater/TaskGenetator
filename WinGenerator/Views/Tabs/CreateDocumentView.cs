using System;
using System.Windows.Forms;
using TaskEngine.Views;
using WinGenerator.CustomControls;

namespace WinGenerator.Views.Tabs
{
    public class CreateDocumentView: IdentifiedTabPage, ICreateDocumentView
    {
        private readonly PercentTableLayoutPanel _table = new PercentTableLayoutPanel();
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

        public CreateDocumentView(): base(ViewIds.CreateDocument)
        {
            _table.AddRow(33);
            _table.AddRow(33);
            _table.AddRow(34);
            _table.AddColumn(100);
            _fileNameTextBox = _table.AddTextBox(0, 0);
            _fileCountNumeric = _table.AddNumeric(0, 1);
            _generateButton = _table.AddButton(0, 2, "Создать");
            
            _generateButton.Click += OnGenerateButtonClicked;
            Controls.Add(_table);
        }
        
        private void OnGenerateButtonClicked(object sender, EventArgs eventArgs)
        {
            GenerateButtonClicked();
        }
    }
}