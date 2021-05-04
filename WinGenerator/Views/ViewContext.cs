using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Contexts;
using TaskEngine.Views;
using WinGenerator.Views.GeneratorsViews;

namespace WinGenerator.Views
{
    public class ViewContext: IViewContext
    {
        public IMainView MainView { get; }
        public ITaskChooseView TaskChooseView { get; }
        public ICreateDocumentView CreateDocumentView { get; }
        

        private readonly Dictionary<Type, IView> _views = new Dictionary<Type, IView>();
        private readonly GeneratorViews _generatorViews = new GeneratorViews();
        
        public ViewContext(TextTaskGeneratorsContext textTaskGenerators)
        {
            var generatingViewFactory = new GeneratingViewFactory();

            foreach (var generator in textTaskGenerators.Generators)
            {
                var rowCount = 1;
                if (generator.Generator.Values.Count() > 4)
                    rowCount = 2;
                
                AddTaskView(generatingViewFactory.Create(generator.Generator, generator.Id, rowCount));
            }

            var taskIds = textTaskGenerators.Generators.Select(g => g.Id).ToList();
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