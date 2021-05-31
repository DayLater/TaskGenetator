using System.Collections.Generic;
using TaskEngine.Contexts;
using TaskEngine.Models;
using TaskEngine.Views;

namespace TaskEngine.Presenters
{
    public class TaskChoosePresenter: IPresenter
    {
        private readonly TasksModel _tasksModel;
        private readonly ExamplesModel _examplesModel;
        private readonly ITaskChooseView _view;

        private string _selectedGeneratorId;
        private readonly IList<string> _taskIds;

        public TaskChoosePresenter(TasksModel tasksModel, ITaskChooseView view, ExamplesModel examplesModel, IList<string> taskIds)
        {
            _tasksModel = tasksModel;
            _view = view;
            _examplesModel = examplesModel;
            _taskIds = taskIds;
            _view.SetItems(taskIds);

            _view.SelectedItemChanged += OnSelectedItemChanged;
            _view.ItemFlagChanged += ViewOnItemFlagChanged;
            _view.OpenGeneratorSettingsButtonClicked += OnOpenGeneratorSettingsButtonClicked;
            _view.SelectAllClicked += OnSelectAllClicked;
            _view.DeselectAllClicked += OnDeselectAllClicked;
        }

        private void OnOpenGeneratorSettingsButtonClicked()
        {
            _view.OpenGeneratorSettings(_selectedGeneratorId);
        }

        private void OnSelectAllClicked()
        {
            foreach (var id in _taskIds)
            {
                if (!_tasksModel.Contains(id))
                    _tasksModel.Add(id);
            }
            
            _view.SelectAll();
        }
        
        private void OnDeselectAllClicked()
        {
            _tasksModel.Clear();
            _view.DeselectAll();
        }

        private void ViewOnItemFlagChanged(string id, bool isChecked)
        {
            if (isChecked && !_tasksModel.Contains(id))
            {
                _tasksModel.Add(id);
            }
            else
            {
                _tasksModel.Remove(id);
            }
        }

        private void OnSelectedItemChanged(string id)
        {
            var example = _examplesModel.GetExample(id);
            _view.SetExampleText(id, example);
            _selectedGeneratorId = id;
        }
    }
}