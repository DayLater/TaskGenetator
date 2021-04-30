using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TaskEngine.Views;
using WinGenerator.CustomControls;

namespace WinGenerator.Views
{
    public class MainView: PercentTableLayoutPanel, IMainView
    {
        private readonly PercentTableLayoutPanel _highTablePanel;
        private readonly Button _nextButton;
        private readonly Button _previousButton;
        private readonly Label _pageNameLabel;
        
        private readonly List<View> _viewContainer;
        private View _currentView;
        
        public MainView(List<View> viewContainer)
        {
            _viewContainer = viewContainer;
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            AddRow(5);
            AddRow(85);
            AddRow(10);
            AddColumn(100);

            _pageNameLabel = AddLabel(0, 0, @"Главное меню");
            _pageNameLabel.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);

            _highTablePanel = AddTable(0, 1);
            _highTablePanel.AddRow(90);
            _highTablePanel.AddColumn(100);

            var bottomTablePanel = AddTable(0, 2);
            bottomTablePanel.AddColumn(25);
            bottomTablePanel.AddColumn(25);
            bottomTablePanel.AddColumn(25);
            bottomTablePanel.AddColumn(25);
            
            _nextButton = bottomTablePanel.AddButton(3, 0, "Вперед");
            _nextButton.Click += OnNextButtonClicked;

            _previousButton = bottomTablePanel.AddButton(0, 0, "Назад");
            _previousButton.Click += OnPreviousButtonClicked;
        }

        public event Action NextButtonClicked = () => { };
        public bool NextButtonEnable
        {
            get => _nextButton.Enabled;
            set => _nextButton.Enabled = value;
        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            NextButtonClicked();
        }

        public event Action PreviousButtonClicked = () => { };
        
        public bool PreviousButtonEnable
        {
            get => _previousButton.Enabled;
            set => _previousButton.Enabled = value;
        }

        private void OnPreviousButtonClicked(object sender, EventArgs e)
        {
            PreviousButtonClicked();
        }
        
        public bool Contains(int viewId)
        {
            return viewId >= 0 && viewId < _viewContainer.Count;
        }

        public void SetView(int viewId)
        {
            if (_currentView != null)
            {
                _currentView.Deactivate();
                _highTablePanel.Controls.Remove(_currentView);
            }

            _currentView = _viewContainer[viewId];
            _highTablePanel.Controls.Add(_currentView);
            _currentView.Activate();

            _pageNameLabel.Text = _currentView.Id;
        }


    }
}