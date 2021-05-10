﻿using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using TaskEngine.Views;
using WinGenerator.CustomControls;

namespace WinGenerator.Views.Tabs
{
    public class CreateDocumentView: IdentifiedTabPage, ICreateDocumentView
    {
        private readonly PercentTableLayoutPanel _mainTable = new PercentTableLayoutPanel();
        private readonly PercentTableLayoutPanel _contentTable;
        
        private RichTextBox _fileNameTextBox;
        private MaterialTextBox _filePathTextBox;
        private LabeledNumericControl _fileCountNumeric;
        private MaterialButton _openFileDialogButton;
     
        public event Action GenerateButtonClicked = () => { };
        
        public string FileName
        {
            get => _fileNameTextBox.Text;
            set => _fileNameTextBox.Text = value;
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
            table.AddRow(10);
            table.AddRow(12);
            table.AddRow(10);
            table.AddRow(10);
            table.AddRow(20);
            table.AddRow(25);
            table.AddColumn(100);

            var label = table.AddLabel(0, 0, MaterialSkinManager.fontType.H6, "Настройка файлов");
            label.TextAlign = ContentAlignment.TopLeft;
            label.HighEmphasis = true;
            
            _fileNameTextBox = table.AddTextBox(0, 1, "Имя файла");
            _filePathTextBox = table.AddTextBox(0, 2, "Сохранить в папку");
            _filePathTextBox.Enabled = false;
            _filePathTextBox.UseAccent = true;
            
            _openFileDialogButton = table.AddButton(0, 3, "Указать путь");
            _fileCountNumeric = table.AddLabeledNumeric(0, 4, "Количество вариантов");
            table.AddControl(new Panel(), 0, 5);

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
            
            var rightTable = _contentTable.AddTable(1, 0);
            rightTable.AddColumn(100);
            rightTable.AddRow(50);
            rightTable.AddRow(50);

            var generateButton = rightTable.AddButton(0, 1, "Создать");
            
            generateButton.Click += (sender, args) =>  GenerateButtonClicked();
        }
    }
}