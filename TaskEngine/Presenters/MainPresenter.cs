using TaskEngine.Contexts;
using TaskEngine.Models;
using TaskEngine.Views;

namespace TaskEngine.Presenters
{
    public class MainPresenter: IPresenter
    {
        private readonly IMainView _view;
        private readonly UserModel _userModel;

        public MainPresenter(IMainView view, UserModel userModel)
        {
            _view = view;
            _userModel = userModel;
            
            _view.PreviousButtonEnable = false;
            _view.NextButtonEnable = true;

            _view.NextButtonClicked += OnNextButtonClicked;
            _view.PreviousButtonClicked += OnPreviousButtonClicked;
            _view.SelectedTabChanged += OnSelectedTabChanged;
        }

        private void OnNextButtonClicked()
        {
            _userModel.CurrentPageIndex++;
            OnSelectedTabChanged(_userModel.CurrentPageIndex);
        }

        private void OnPreviousButtonClicked()
        {
            _userModel.CurrentPageIndex--;
            OnSelectedTabChanged(_userModel.CurrentPageIndex);
        }

        private void OnSelectedTabChanged(int tabIndex)
        {
            _userModel.CurrentPageIndex = tabIndex;
            _view.SetView(_userModel.CurrentPageIndex);

            _view.PreviousButtonEnable = Contains(_userModel.CurrentPageIndex - 1);
            _view.NextButtonEnable = Contains(_userModel.CurrentPageIndex + 1);
        }

        private bool Contains(int pageIndex)
        {
            return pageIndex >= 0 && pageIndex < _view.TabsCount;
        }
    }
}