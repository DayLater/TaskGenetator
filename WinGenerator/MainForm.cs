using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using TaskEngine.Views;
using TaskEngine.Writers;
using WinGenerator.CustomControls;
using WinGenerator.Views;

namespace WinGenerator
{
    public sealed class MainForm: MaterialForm, IMainView
    {
        private readonly PercentTableLayoutPanel _table;
        private readonly MaterialTabControl _tabControl;
        private readonly MaterialButton _backButton;
        private readonly MaterialButton _nextButton;

        public MainForm()
        {
            DoubleBuffered = true;
            DrawerShowIconsWhenHidden = true;

            var size = new Size(1024, 768);
            MinimumSize = size;
            Size = size;

            _tabControl = new MaterialTabControl
            {
                Margin = new Padding(0),
                MouseState = MouseState.HOVER,
                Multiline = true,
                SelectedIndex = 0,
                TabIndex = 23,
                AutoSize = true,
                Dock = DockStyle.Fill
            };

            var tabSelector = new MaterialTabSelector
            {
                BaseTabControl = _tabControl,
                Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel),
                Margin = new Padding(0),
                MouseState = MouseState.HOVER,
                TabIndex = 24,
                Dock = DockStyle.Fill
            };

            _table = new PercentTableLayoutPanel
                {Dock = DockStyle.None, Size = GetClientSize(), Location = new Point(0, 60)};
            _table.AddColumn(100);
            _table.AddRow(5);
            _table.AddRow(85);
            _table.AddRow(10);

            _table.AddControl(tabSelector, 0, 0);
            _table.AddControl(_tabControl, 0, 1);

            var buttonTable = _table.AddTable(0, 2);
            buttonTable.AddColumn(25);
            buttonTable.AddColumn(25);
            buttonTable.AddColumn(25);
            buttonTable.AddColumn(25);
            _backButton = buttonTable.AddButton(0, 0, "Назад");
            _nextButton = buttonTable.AddButton(3, 0, "Вперед");
            _backButton.Click += OnBackButtonClicked;
            _nextButton.Click += OnNextButtonClicked;

            Controls.Add(_table);

            Text = "Генератор заданий";

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100,
                Accent.Pink200, TextShade.WHITE);

            var themesController = new ThemesController(materialSkinManager, this);

            SizeChanged += OnWindowSizeChanged;

            var contexts = new Contexts(new SetWriter(new ExpressionWriter(), 10), new Random(), this,
                themesController, materialSkinManager);
            foreach (var page in contexts.ViewContext.TabPages)
                _tabControl.Controls.Add(page);

            _tabControl.SelectedIndexChanged += OnSelectedTabChanged;
            themesController.UpdatedColors += () => tabSelector.Invalidate();
        }

        private Size GetClientSize() =>  new Size(Size.Width, Size.Height - 60);
        private void OnWindowSizeChanged(object sender, EventArgs e) => _table.Size = GetClientSize();
        private void OnBackButtonClicked(object sender, EventArgs eventArgs) => PreviousButtonClicked();
        private void OnNextButtonClicked(object sender, EventArgs eventArgs) => NextButtonClicked();

        private void OnSelectedTabChanged(object sender, EventArgs eventArgs)
        {
            var tabIndex = _tabControl.SelectedIndex;
            SelectedTabChanged(tabIndex);
        }

        public string Id => "Главное меню";

        public event Action<int> SelectedTabChanged = i => { }; 
        public event Action NextButtonClicked = () => { };
        public bool NextButtonEnable
        {
            get => _nextButton.Enabled;
            set => _nextButton.Enabled = value;
        }

        public event Action PreviousButtonClicked = () => { };
        public bool PreviousButtonEnable
        {
            get => _backButton.Enabled;
            set => _backButton.Enabled = value;
        }
        
        public int TabsCount => _tabControl.TabCount;
        public void SetView(int viewId) => _tabControl.SelectedIndex = viewId;
    }
}