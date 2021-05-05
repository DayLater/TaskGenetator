using System.Collections.Generic;
using System.Linq;
using TaskEngine.Contexts;
using TaskEngine.Factories;
using TaskEngine.Views;

namespace WinGenerator.Views
{
    public class ViewContext: IViewContext
    {
        public IMainView MainView { get; }
        public ITaskChooseView TaskChooseView { get; }
        public ICreateDocumentView CreateDocumentView { get; }

        private readonly GeneratorViews _generatorViews = new GeneratorViews();
        
        public ViewContext(TaskGeneratorFactory generatorFactory)
        {
            var generatingViewFactory = new GeneratingViewFactory();

            foreach (var generator in generatorFactory.TaskGenerators)
            {
                var rowCount = 1;
                if (generator.Values.Count() > 4)
                    rowCount = 2;
                
                AddTaskView(generatingViewFactory.Create(generator, rowCount));
            }

            var taskIds = generatorFactory.TaskGenerators.Select(g => g.Id).ToList();
            var taskChooseView = new TaskChooseView(_generatorViews, taskIds);
            TaskChooseView = taskChooseView;

            var createViewDocument = new CreateDocumentView();
            CreateDocumentView = createViewDocument;
            MainView = new MainView(new List<View> {new EmptyView(), taskChooseView, createViewDocument});
        }

        private void AddTaskView<TView>(TView view)
            where TView : IView
        {
            _generatorViews.Add(view.Id, view);
        }
    }
}