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
            
            _view.SetView(userContext.CurrentPageIndex);
            _view.PreviousButtonEnable = false;
            _view.NextButtonEnable = true;

            _view.NextButtonClicked += OnNextButtonClicked;
            _view.PreviousButtonClicked += OnPreviousButtonClicked;
        }

        private void OnNextButtonClicked()
        {
            _userContext.CurrentPageIndex++;
            _view.SetView(_userContext.CurrentPageIndex);

            if (!_view.PreviousButtonEnable)
                _view.PreviousButtonEnable = true;

            if (!_view.Contains(_userContext.CurrentPageIndex + 1))
                _view.NextButtonEnable = false;
        }

        private void OnPreviousButtonClicked()
        {
            _userContext.CurrentPageIndex--;
            _view.SetView(_userContext.CurrentPageIndex);

            if (!_view.Contains(_userContext.CurrentPageIndex - 1))
                _view.PreviousButtonEnable = false;

            if (!_view.NextButtonEnable)
                _view.NextButtonEnable = true;
        }
    }
}