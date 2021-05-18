using System.Collections.Generic;
using TaskEngine.Contexts;
using TaskEngine.Views;

namespace TaskEngine.Presenters
{
    public class TaskChoosePresenter: IPresenter
    {
        private readonly TasksContext _tasksContext;
        private readonly ExamplesContext _examplesContext;
        private readonly ITaskChooseView _view;

        private string _selectedGeneratorId;
        private readonly IList<string> _taskIds;

        public TaskChoosePresenter(TasksContext tasksContext, ITaskChooseView view, ExamplesContext examplesContext, IList<string> taskIds)
        {
            _tasksContext = tasksContext;
            _view = view;
            _examplesContext = examplesContext;
            _taskIds = taskIds;
            _view.SetItems(taskIds);

            _view.SelectedItemChanged += OnSelectedItemChanged;
            _view.ItemFlagChanged += ViewOnItemFlagChanged;
            _view.OpenConfigureButtonClicked += OnOpenConfigureButtonClicked;
            _view.SelectAllClicked += OnSelectAllClicked;
            _view.DeselectAllClicked += OnDeselectAllClicked;
        }

        private void OnOpenConfigureButtonClicked()
        {
            _view.OpenGeneratorSettings(_selectedGeneratorId);
        }

        private void OnSelectAllClicked()
        {
            foreach (var id in _taskIds)
            {
                if (!_tasksContext.Contains(id))
                    _tasksContext.Add(id);
            }
            
            _view.SelectAll();
        }
        
        private void OnDeselectAllClicked()
        {
            _tasksContext.Clear();
            _view.DeselectAll();
        }

        private void ViewOnItemFlagChanged(string id, bool isChecked)
        {
            if (isChecked && !_tasksContext.Contains(id))
            {
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
            _view.SetExampleText(id, example);
            _selectedGeneratorId = id;
        }
    }
}