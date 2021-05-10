using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Contexts;
using TaskEngine.Extensions;
using TaskEngine.Factories;
using TaskEngine.Tasks.Texts;
using TaskEngine.Views;
using TaskEngine.Writers.DocWriters;
using TaskEngine.Writers.TaskWriters;

namespace TaskEngine.Presenters
{
    public class CreateDocumentPresenter: IPresenter
    {
        private readonly ICreateDocumentView _view;
        private readonly IDocWriter _docWriter;

        private readonly TasksContext _tasksContext;
        private readonly TaskGeneratorFactory _taskGeneratorFactory;
        private readonly TaskWriter _taskWriter;
        private readonly Random _random;
        
        public CreateDocumentPresenter(ICreateDocumentView view, TasksContext tasksContext, IDocWriter docWriter, TaskGeneratorFactory taskGeneratorFactory, TaskWriter taskWriter, Random random)
        {
            _view = view;
            _tasksContext = tasksContext;
            _docWriter = docWriter;
            _taskGeneratorFactory = taskGeneratorFactory;
            _taskWriter = taskWriter;
            _random = random;

            _view.GenerateButtonClicked += OnGenerateButtonClicked;
            _view.FileDialogButtonClicked += OnFolderBrowserButtonClicked;
            _view.FileCount = 10;

            var path = Environment.CurrentDirectory;
            SetPath(path);
        }

        private void OnFolderBrowserButtonClicked()
        {
            if (_view.TryGetFolderPath(out var path))
                SetPath(path);
        }

        private void SetPath(string path)
        {
            _docWriter.Path = path;
            _view.Path = path;
        }
        
        private void OnGenerateButtonClicked()
        {
            var taskIds = _tasksContext.Ids.ToList();
            if (taskIds.Count == 0)
            {
                _view.ShowMessage("Не выбрано ни одного задания. Создание отменено");
            }
            else
            {
                var count = _view.FileCount;
                var name = _view.FileName;
                var generators = taskIds.Select(id => _taskGeneratorFactory.Get(id)).ToList();

                for (int i = 0; i < count; i++)
                {
                    var textTasks = new List<ITextTask>();
                    foreach (var generator in generators)
                    {
                        var task = generator.Generate();
                        var textTask = _taskWriter.WriteTextTask(task);
                        textTasks.Add(textTask);
                        _random.ClearSymbols();
                        _random.ClearNames();
                    }
                    
                    _docWriter.Write($"{name}_{i + 1}", textTasks, i + 1);
                }
            }
        }
    }
}