using System.Collections.Generic;
using System.Linq;
using WindowsGenerator.Views.Tabs;
using MaterialSkin;
using TaskEngine.Contexts;
using TaskEngine.Views;

namespace WindowsGenerator.Views
{
    public class ViewContext: IViewContext
    {
        public IMainView MainView { get; }
        public ITaskChooseView TaskChooseView { get; }
        public ICreateDocumentView CreateDocumentView { get; }
        public IHomePageView HomePageView { get; }

        private readonly GeneratorViews _generatorViews = new GeneratorViews();
        private readonly List<IdentifiedTabPage> _tabs = new List<IdentifiedTabPage>();

        public IEnumerable<IdentifiedTabPage> TabPages => _tabs;
        
        public ViewContext(TaskGeneratorContext generatorContext, IMainView mainView, MaterialSkinManager skinManager)
        {
            MainView = mainView;
            var generatingViewFactory = new GeneratingViewFactory();

            foreach (var generator in generatorContext.TaskGenerators)
            {
                var rowCount = 1;
                if (generator.Values.Count() > 8)
                    rowCount = 2;
                
                AddTaskView(generatingViewFactory.Create(generator, rowCount));
            }
            
            var taskChooseView = new TaskChooseView(_generatorViews, skinManager);
            TaskChooseView = taskChooseView;

            var createViewDocument = new CreateDocumentView();
            CreateDocumentView = createViewDocument;

            var homePage = new HomeTabPage();
            HomePageView = homePage;
            
            _tabs.Add(homePage);
            _tabs.Add(taskChooseView);
            _tabs.Add(createViewDocument);
        }

        private void AddTaskView<TView>(TView view)
            where TView : IView
        {
            _generatorViews.Add(view.Id, view);
        }
    }
}