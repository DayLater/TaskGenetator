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

        private readonly Dictionary<string, IView> _views = new Dictionary<string, IView>();
        private readonly GeneratorViews _generatorViews = new GeneratorViews();
        
        public ViewContext()
        {
            VariantsCharacteristicPropertyGeneratorView = new VariantsCharacteristicPropertyView();
            AddTaskView(TaskIds.CharacteristicPropertyTask, VariantsCharacteristicPropertyGeneratorView);
            
            Empty = new EmptyView();
            AddTaskView(TaskIds.Empty, Empty);
            AddTaskView(TaskIds.SubSetTask, Empty);
            AddTaskView(TaskIds.BorderSetOperationTask, Empty);
            AddTaskView(TaskIds.NumberBelongsSetTask, Empty);
            AddTaskView(TaskIds.VariantsSubSetTask, Empty);
            
            var taskChooseView = new TaskChooseView(_generatorViews);
            TaskChooseView = taskChooseView;

            var createViewDocument = new CreateDocumentView();
            CreateDocumentView = createViewDocument;
            MainView = new MainView(new List<View> {new EmptyView(), taskChooseView, createViewDocument});
        }

        private void AddTaskView(string id, IView view)
        {
            _views.Add(id, view);
            _generatorViews.Add(id, view);
        }

        public IView GetView(string id) => _views[id];
    }
}