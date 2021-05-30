using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsGenerator.CustomControls;
using MaterialSkin;
using MaterialSkin.Controls;
using TaskEngine.Views;
using TaskEngine.Writers.DocWriters;

namespace WindowsGenerator.Views.Tabs
{
    public class CreateDocumentView: IdentifiedTabPage, ICreateDocumentView
    {
        private readonly PercentTableLayoutPanel _mainTable = new PercentTableLayoutPanel();
        private readonly PercentTableLayoutPanel _contentTable;
        
        private RichTextBox _fileNameTextBox;
        private RichTextBox _titleTextBox;
        private MaterialTextBox _filePathTextBox;
        private LabeledNumericControl _fileCountNumeric;
        private MaterialButton _openFileDialogButton;
        private MaterialSwitch _isCreateDirectorySwitch;

        private LabeledNumericControl _titleFontSizeNumeric;
        private ComboBox _titleFontBox;
        private LabeledNumericControl _textFontSizeNumeric;
        private ComboBox _textFontBox;
     
        public event Action GenerateButtonClicked = () => { };
        
        public string FileName
        {
            get => _fileNameTextBox.Text;
            set => _fileNameTextBox.Text = value;
        }

        public string TitleText
        {
            get => _titleTextBox.Text;
            set => _titleTextBox.Text = value;
        }

        public int FileCount
        {
            get => _fileCountNumeric.Value;
            set => _fileCountNumeric.Value = value;
        }

        public string Path
        {
            get => _filePathTextBox.Text;
            set => _filePathTextBox.Text = value;
        }

        public void ShowMessage(string message)
        {
            MaterialMessageBox.Show(message);
        }

        private void AddHeader()
        {
            var headerCard = _mainTable.AddCard(0, 0);
            var configLabel = new MaterialLabel
            {
                FontType = MaterialSkinManager.fontType.H5,
                Text = "Настройка документа",
                TextAlign = ContentAlignment.TopLeft,
                HighEmphasis = true, Dock = DockStyle.Fill
            };
            headerCard.Controls.Add(configLabel);
        }

        private void AddFileConfigs()
        {
            var card = _contentTable.AddCard(0, 0);
            var table = new PercentTableLayoutPanel();
            card.Controls.Add(table);
            table.AddColumn(100);
            table.AddRow(12);
            table.AddRow(12);
            table.AddRow(12);
            table.AddRow(12);
            table.AddRow(12);
            table.AddRow(15);
            table.AddRow(25);


            var label = table.AddLabel(0, 0, MaterialSkinManager.fontType.H6, "Настройка файлов");
            label.TextAlign = ContentAlignment.TopLeft;
            label.HighEmphasis = true;
            
            _fileNameTextBox = table.AddTextBox(0, 1, "Имя файла");
            _titleTextBox = table.AddTextBox(0, 2, "Текст заголовка");
            _titleTextBox.Text = "Контрольная работа";
            _filePathTextBox = table.AddTextBox(0, 3, "Сохранить в папку");
            _filePathTextBox.Enabled = false;
            _filePathTextBox.UseAccent = true;
            
            _openFileDialogButton = table.AddButton(0, 4, "Указать путь");
            _isCreateDirectorySwitch = table.AddSwitch(0, 5, "Создать папку");
            _isCreateDirectorySwitch.TextAlign = ContentAlignment.MiddleRight;

            _fileCountNumeric = table.AddLabeledNumeric(0, 6, "Количество вариантов");
            
            _openFileDialogButton.Click += (sender, args) => FileDialogButtonClicked();
        }
        
        public bool TryGetFolderPath(out string path)
        {
            using var fbd = new FolderBrowserDialog {RootFolder = Environment.SpecialFolder.MyComputer};
            var result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                path = fbd.SelectedPath;
                return true;
            }

            path = null;
            return false;
        }

        public string TitleFont => (string) _titleFontBox.SelectedItem;
        public string TextFont => (string) _textFontBox.SelectedItem;

        public int TitleFontSize
        {
            get => _titleFontSizeNumeric.Value;
            set => _titleFontSizeNumeric.Value = value;
        }
        
        public int TextFontSize
        {
            get => _textFontSizeNumeric.Value;
            set => _textFontSizeNumeric.Value = value;
        }

        public bool IsCreateDirectory => _isCreateDirectorySwitch.Checked;

        private void AddFontSettings()
        {
            var fontCard = _contentTable.AddCard(1, 0);
            var table = new PercentTableLayoutPanel();
            fontCard.Controls.Add(table);
            table.AddColumn(100);
            table.AddRow(10);
            table.AddRow(90);

            var label = table.AddLabel(0, 0, MaterialSkinManager.fontType.H6, "Настройки текста");
            label.HighEmphasis = true;
            label.TextAlign = ContentAlignment.TopLeft;
            
            var fontTable = table.AddTable(0, 1);
            fontTable.AddColumn(100);
            fontTable.AddRow(20);
            fontTable.AddRow(20);
            fontTable.AddRow(20);
            fontTable.AddRow(20);
            fontTable.AddRow(20);

            _titleFontSizeNumeric = fontTable.AddLabeledNumeric(0, 0, "Размер шрифта заголовка");
            _titleFontSizeNumeric.Numeric.Minimum = 5;
            _titleFontBox = fontTable.AddComboBox(0, 1, "Шрифт заголовка", Fonts.GetFonts().ToArray());
            
            _textFontSizeNumeric = fontTable.AddLabeledNumeric(0, 2, "Размер шрифта текста");
            _textFontSizeNumeric.Numeric.Minimum = 4;
            _textFontBox = fontTable.AddComboBox(0, 3, "Шрифт текста", Fonts.GetFonts().ToArray());
            
            var generateButton = fontTable.AddButton(0, 4, "Создать");
            
            generateButton.Click += (sender, args) =>  GenerateButtonClicked();
        }

        public event Action FileDialogButtonClicked = () => { };
        
        public CreateDocumentView(): base(ViewIds.CreateDocument)
        {
            Controls.Add(_mainTable);

            _mainTable.AddRow(15);
            _mainTable.AddRow(85);
            _mainTable.AddColumn(100);
            
            AddHeader();

            _contentTable = _mainTable.AddTable(0, 1);
            _contentTable.AddRow(100);
            _contentTable.AddColumn(50);
            _contentTable.AddColumn(50);
            
            AddFileConfigs();
            AddFontSettings();
        }
    }
}