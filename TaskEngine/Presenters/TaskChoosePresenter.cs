using TaskEngine.Contexts;
using TaskEngine.Views;

namespace TaskEngine.Presenters
{
    public class TaskChoosePresenter: IPresenter
    {
        private readonly TasksContext _tasksContext;
        private readonly ExamplesContext _examplesContext;
        private readonly ITaskChooseView _view;

        public TaskChoosePresenter(TasksContext tasksContext, ITaskChooseView view, ExamplesContext examplesContext)
        {
            _tasksContext = tasksContext;
            _view = view;
            _examplesContext = examplesContext;

            _view.SelectedItemChanged += OnSelectedItemChanged;
            _view.ItemFlagChanged += ViewOnItemFlagChanged;
        }

        private void ViewOnItemFlagChanged(string id, bool isChecked)
        {
            if (isChecked)
            {
                if (!_tasksContext.Contains(id))
                    _tasksContext.Add(id);
            }
            else
            {
                _tasksContext.Remove(id);
            }
        }

        private void OnSelectedItemChanged(string id)
        {
            var example = _examplesContext.GetExample(id);
            _view.SetExampleText(example);
            _view.ReplaceGeneratorView(id);
        }
    }
}