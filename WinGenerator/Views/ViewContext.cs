using System;
using System.Collections.Generic;
using TaskEngine;
using TaskEngine.Contexts;
using TaskEngine.Views;
using TaskEngine.Views.TaskGenerators;
using WinGenerator.Views.GeneratorsViews;

namespace WinGenerator.Views
{
    public class ViewContext: IViewContext
    {
        public IMainView MainView { get; }
        public ITaskChooseView TaskChooseView { get; }
        public ICreateDocumentView CreateDocumentView { get; }
        
        public IVariantsCharacteristicPropertyGeneratorView VariantsCharacteristicPropertyGeneratorView { get; }

        public IView Empty { get; }

        private readonly Dictionary<Type, IView> _views = new Dictionary<Type, IView>();
        private readonly GeneratorViews _generatorViews = new GeneratorViews();
        
        public ViewContext()
        {
            INumberBelongsSetGeneratorView numberBelongsSetGeneratorView = new NumberBelongsSetGeneratorView();
            AddTaskView(numberBelongsSetGeneratorView);

            INumbersBelongSetGeneratorView numbersBelongSetGeneratorView = new NumbersBelongSetGeneratorView();
            AddTaskView(numbersBelongSetGeneratorView);
            
            VariantsCharacteristicPropertyGeneratorView = new VariantsCharacteristicPropertyView();
            AddTaskView(VariantsCharacteristicPropertyGeneratorView);
            
            Empty = new EmptyView();
            AddTaskView(Empty, TaskIds.SubSetTask);
            AddTaskView(Empty, TaskIds.BorderSetOperationTask);
            AddTaskView(Empty, TaskIds.VariantsSubSetTask);

            var taskChooseView = new TaskChooseView(_generatorViews);
            TaskChooseView = taskChooseView;

            var createViewDocument = new CreateDocumentView();
            CreateDocumentView = createViewDocument;
            MainView = new MainView(new List<View> {new EmptyView(), taskChooseView, createViewDocument});
        }

        private void AddTaskView<TView>(TView view, string customId = null)
            where TView : IView
        {
            if (!_views.ContainsKey(typeof(TView)))
                _views.Add(typeof(TView), view);
            _generatorViews.Add(customId ?? view.Id, view);
        }
        
        public TView GetView<TView>() where TView : IView
        {
            return (TView)_views[typeof(TView)];
        }
    }
}