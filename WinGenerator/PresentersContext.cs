using System.Collections.Generic;
using TaskEngine.Contexts;
using TaskEngine.DocWriters;
using TaskEngine.Generators.Tasks;
using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Presenters;
using TaskEngine.Presenters.Tasks;
using TaskEngine.Presenters.Tasks.Elements;
using TaskEngine.Views.TaskGenerators;

namespace WinGenerator
{
    public class PresentersContext
    {
        private readonly List<IPresenter> _taskPresenters = new List<IPresenter>();
        public MainPresenter MainPresenter { get; }
        public TaskChoosePresenter TaskChoosePresenter { get; }
        public CreateDocumentPresenter CreateDocumentPresenter { get; }
        
        public PresentersContext(TaskGeneratorContext generatorContext, TextTaskGeneratorsContext textTaskGeneratorsContext, IViewContext viewContext, UserContext userContext, ExamplesContext examplesContext)
        {
            MainPresenter = new MainPresenter(viewContext.MainView, userContext);
            TaskChoosePresenter = new TaskChoosePresenter(userContext.TasksContext, viewContext.TaskChooseView, examplesContext);
            CreateDocumentPresenter = new CreateDocumentPresenter(viewContext.CreateDocumentView, userContext.TasksContext, new DocWriter(), textTaskGeneratorsContext);
            
            AddTaskPresenter(new NumberBelongsSetTaskPresenter(viewContext.GetView<INumberBelongsSetGeneratorView>(), generatorContext.Get<NumberBelongsSetTaskGenerator>()));
            AddTaskPresenter(new NumbersBelongSetTaskPresenter(viewContext.GetView<INumbersBelongSetGeneratorView>(), generatorContext.Get<NumbersBelongSetTaskGenerator>()));
            
            AddTaskPresenter(new VariantsCharacteristicPropertyTaskPresenter(generatorContext.Get<CharacteristicPropertyTaskGenerator>(), viewContext.VariantsCharacteristicPropertyGeneratorView));
            AddTaskPresenter(new VariantsSubSetTaskPresenter());
            AddTaskPresenter(new SubSetTaskPresenter());
        }

        private void AddTaskPresenter(IPresenter presenter) => _taskPresenters.Add(presenter);
    }
}