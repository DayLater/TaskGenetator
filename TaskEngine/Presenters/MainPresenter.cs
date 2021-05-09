using TaskEngine.Contexts;
using TaskEngine.Views;

namespace TaskEngine.Presenters
{
    public class MainPresenter: IPresenter
    {
        private readonly IMainView _view;
        private readonly UserContext _userContext;

        public MainPresenter(IMainView view, UserContext userContext)
        {
            _view = view;
            _userContext = userContext;
            
            _view.PreviousButtonEnable = false;
            _view.NextButtonEnable = true;

            _view.NextButtonClicked += OnNextButtonClicked;
            _view.PreviousButtonClicked += OnPreviousButtonClicked;
            _view.SelectedTabChanged += OnSelectedTabChanged;
        }

        private void OnNextButtonClicked()
        {
            _userContext.CurrentPageIndex++;
            OnSelectedTabChanged(_userContext.CurrentPageIndex);
        }

        private void OnPreviousButtonClicked()
        {
            _userContext.CurrentPageIndex--;
            OnSelectedTabChanged(_userContext.CurrentPageIndex);
        }

        private void OnSelectedTabChanged(int tabIndex)
        {
            _userContext.CurrentPageIndex = tabIndex;
            _view.SetView(_userContext.CurrentPageIndex);

            _view.PreviousButtonEnable = Contains(_userContext.CurrentPageIndex - 1);
            _view.NextButtonEnable = Contains(_userContext.CurrentPageIndex + 1);
        }

        private bool Contains(int pageIndex)
        {
            return pageIndex >= 0 && pageIndex < _view.TabsCount;
        }
    }
}