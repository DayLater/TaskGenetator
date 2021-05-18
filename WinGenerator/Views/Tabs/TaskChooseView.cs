using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using TaskEngine.Views;
using WinGenerator.CustomControls;

namespace WinGenerator.Views.Tabs
{
    public class TaskChooseView: IdentifiedTabPage, ITaskChooseView
    {
        private readonly MaterialCheckedListBox _checkedListBox;
        private readonly Label _exampleTextLabel;
        private readonly Label _exampleTitleTextLabel;
        private readonly GeneratorViews _generatorViews;

        private readonly PercentTableLayoutPanel _table = new PercentTableLayoutPanel();
        private readonly MaterialSkinManager _skinManager;
        private readonly MaterialButton _generatorSettingsButton;

        public event Action<string> SelectedItemChanged = s => { };
        public event Action<string, bool> ItemFlagChanged = (s, b) => { };
        public event Action OpenConfigureButtonClicked = () => { };
        public event Action SelectAllClicked = () => { };
        public event Action DeselectAllClicked = () => { };

        private const string _exampleText = "Пример задания";

        public TaskChooseView(GeneratorViews generatorViews, MaterialSkinManager skinManager) : base(ViewIds.TaskChoose)
        {
            _generatorViews = generatorViews;
            _skinManager = skinManager;

            _table.RowStyles.Clear();
            _table.AddRow(50);
            _table.AddRow(50);
            _table.AddColumn(100);

            var topTable = _table.AddTable(0, 0);
            topTable.AddColumn(60);
            topTable.AddColumn(40);
            topTable.AddRow(100);
            _checkedListBox = topTable.AddCheckedListBox(0, 0);
            
            var exampleTaskCard = _table.AddCard(0, 1); 
            var exampleTable = new PercentTableLayoutPanel();
            exampleTaskCard.Controls.Add(exampleTable);
            exampleTable.AddRow(15);
            exampleTable.AddRow(85);
            exampleTable.AddColumn(100);
            _exampleTitleTextLabel = exampleTable.AddLabel(0, 0, MaterialSkinManager.fontType.H6, _exampleText, true);
            _exampleTextLabel = exampleTable.AddLabel(0, 1, MaterialSkinManager.fontType.Body1);

            var generatorSettingTableCard = topTable.AddCard(1, 0);
            var generatorSettingsTable = new PercentTableLayoutPanel();
            generatorSettingsTable.AddRow(10);
            generatorSettingsTable.AddRow(30);
            generatorSettingsTable.AddRow(30);
            generatorSettingsTable.AddRow(30);
            generatorSettingsTable.AddColumn(100);
            generatorSettingTableCard.Controls.Add(generatorSettingsTable);

            generatorSettingsTable.AddLabel(0, 0, MaterialSkinManager.fontType.H6,  @"Управление", true);

            var selectAllButton = generatorSettingsTable.AddButton(0, 1, "Выбрать все");
            selectAllButton.Click += (sender, args) => SelectAllClicked();

            var deselectAllButton = generatorSettingsTable.AddButton(0, 2, "Снять все");
            deselectAllButton.Click += (sender, args) => DeselectAllClicked(); 
            
            _generatorSettingsButton = generatorSettingsTable.AddButton(0, 3, "Настройки генератора");
            _generatorSettingsButton.Click += (sender, args) => OpenConfigureButtonClicked();
            _generatorSettingsButton.Enabled = false;

            Controls.Add(_table);

            _checkedListBox.Items.SelectedIndexChanged += OnSelectedItemChanged;
        }

        public void SetItems(IEnumerable<string> items)
        {
            foreach (var item in items.Reverse())
                _checkedListBox.Items.Add(item);
        }

        public void SelectAll()
        {
            foreach (var checkBox in _checkedListBox.Items)
            {
                checkBox.Checked = true;
            }
        }

        public void DeselectAll()
        {
            foreach (var checkBox in _checkedListBox.Items)
            {
                checkBox.Checked = false;
            }
        }
        
        public void SetExampleText(string name, string example)
        {
            _exampleTitleTextLabel.Text = $@"{_exampleText} - «{name}»";
            _exampleTextLabel.Text = example;
        }
        
        public void OpenGeneratorSettings(string generatorId)
        {
            var view = _generatorViews.Get(generatorId);
            var form = new GeneratorConfigForm(_skinManager, view);
            form.ShowDialog();
        }

        private void OnSelectedItemChanged(int index)
        {
            _generatorSettingsButton.Enabled = true;
            var itemId = _checkedListBox.Items[index].Text;
            ItemFlagChanged(itemId, _checkedListBox.Items[index].Checked);
            SelectedItemChanged(itemId);
        }
    }
}