﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TaskEngine.Contexts;
using TaskEngine.Extensions;
using TaskEngine.Models;
using TaskEngine.Models.Tasks.Texts;
using TaskEngine.Views;
using TaskEngine.Writers.DocWriters;
using TaskEngine.Writers.TaskWriters;

namespace TaskEngine.Presenters
{
    public class CreateDocumentPresenter: IPresenter
    {
        private readonly ICreateDocumentView _view;
        private readonly IDocWriter _docWriter;

        private readonly TasksModel _tasksModel;
        private readonly TaskGeneratorContext _taskGeneratorContext;
        private readonly TaskWriter _taskWriter;
        private readonly Random _random;
        private string _path;
        
        public CreateDocumentPresenter(ICreateDocumentView view, TasksModel tasksModel, IDocWriter docWriter, TaskGeneratorContext taskGeneratorContext, TaskWriter taskWriter, Random random)
        {
            _view = view;
            _tasksModel = tasksModel;
            _docWriter = docWriter;
            _taskGeneratorContext = taskGeneratorContext;
            _taskWriter = taskWriter;
            _random = random;

            _view.GenerateButtonClicked += OnGenerateButtonClicked;
            _view.FileDialogButtonClicked += OnFolderBrowserButtonClicked;
            _view.FileCount = 10;
            _view.FileName = "Самостоятельная работа";
            _view.TitleText = "Самостоятельная работа";
            
            _view.TextFontSize = 12;
            _view.TitleFontSize = 16;
            
            var path = Environment.CurrentDirectory;
            SetPath(path);
        }

        private void OnFolderBrowserButtonClicked()
        {
            if (_view.TryGetFolderPath(out var path))
                SetPath(path);
            else
                _view.ShowMessage("Не удалось получить путь");
        }

        private void SetPath(string path)
        {
            _path = path;
            _view.Path = path;
        }
        
        private void OnGenerateButtonClicked()
        {
            var taskIds = _tasksModel.Ids.ToList();
            if (taskIds.Count == 0)
            {
                _view.ShowMessage("Не выбрано ни одного задания");
            }
            else
            {
                _docWriter.TitleFont.Font = _view.TitleFont;
                _docWriter.TitleFont.Size = _view.TitleFontSize;
                _docWriter.TextFont.Font = _view.TextFont;
                _docWriter.TextFont.Size = _view.TextFontSize;
                _docWriter.TitleText = _view.TitleText;
                
                var count = _view.FileCount;
                var name = _view.FileName;

                var path = _path;
                if (_view.IsCreateDirectory)
                {
                    path = $"{_path}\\{name}";
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                }

                var generators = taskIds.Select(id => _taskGeneratorContext.Get(id)).ToList();

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
                    
                    _docWriter.Write($"{path}\\{name}_{i + 1}.docx", textTasks, i + 1);
                }

                Process.Start(path);
            }
        }
    }
}