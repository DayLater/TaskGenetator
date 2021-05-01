using System;
using System.Windows.Forms;
using TaskEngine.Views;

namespace WinGenerator.Views
{
    public class CreateDocumentView: View, ICreateDocumentView
    {
        private readonly Button _generateButton;
     
        public event Action GenerateButtonClicked = () => { };

        public override string Id => "Создание текстового документа";

        public CreateDocumentView()
        {
            AddRow(100);
            AddColumn(100);
            _generateButton = AddButton(0, 0, "Создать");
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