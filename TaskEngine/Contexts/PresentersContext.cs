using System.Collections.Generic;
using TaskEngine.Presenters;
using TaskEngine.Presenters.Tasks;
using TaskEngine.Presenters.Tasks.Elements;

namespace TaskEngine.Contexts
{
    public class PresentersContext
    {
        private readonly List<IPresenter> _taskPresenters = new List<IPresenter>();
        public MainPresenter MainPresenter { get; }
        public TaskChoosePresenter TaskChoosePresenter { get; }


        public PresentersContext(TaskGeneratorContext generatorContext, TextTaskGeneratorsContext generatorsContext, IViewContext viewContext, UserContext userContext, ExamplesContext examplesContext)
        {
            MainPresenter = new MainPresenter(viewContext.MainView, userContext);
            TaskChoosePresenter = new TaskChoosePresenter(userContext.TasksContext, viewContext.TaskChooseView, examplesContext);
            
            AddTaskPresenter(new NumberBelongsSetTaskPresenter(generatorsContext.NumberBelongsSetTextTextTaskGenerator, viewContext.Empty));
            AddTaskPresenter(new VariantsCharacteristicPropertyTaskPresenter(generatorContext.CharacteristicPropertyTaskGenerator, generatorsContext.CharacteristicPropertySetAnswerTextTaskGenerator, viewContext.VariantsCharacteristicPropertyGeneratorView));
            AddTaskPresenter(new VariantsSubSetTaskPresenter(generatorsContext.VariantsSubSetSetAnswerTextTaskGenerator, viewContext.Empty));
            AddTaskPresenter(new SubSetTaskPresenter(generatorsContext.SubSetTextTaskGenerator, viewContext.Empty));
        }

        private void AddTaskPresenter(IPresenter presenter) => _taskPresenters.Add(presenter);

        public IEnumerable<IPresenter> TaskPresenters => _taskPresenters;
    }
}