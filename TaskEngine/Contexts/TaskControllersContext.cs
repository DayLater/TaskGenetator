using System.Collections.Generic;
using TaskEngine.Presenters;

namespace TaskEngine.Contexts
{
    public class TaskControllersContext
    {
        public VariantsCharacteristicPropertyTaskPresenter VariantsCharacteristicPropertyTaskPresenter { get; }
        public VariantsSubSetTaskPresenter VariantsSubSetTaskPresenter { get; }
        public SubSetTaskPresenter SubSetTaskPresenter { get; }
        
        public TaskControllersContext(TaskGeneratorContext generatorContext, TaskWritersContext writersContext, IViewContext viewContext)
        {
            VariantsCharacteristicPropertyTaskPresenter = new VariantsCharacteristicPropertyTaskPresenter(generatorContext.CharacteristicPropertyTaskGenerator, writersContext.CharacteristicPropertyTaskWriter, viewContext.VariantsCharacteristicPropertyGeneratorView);
            VariantsSubSetTaskPresenter = new VariantsSubSetTaskPresenter(generatorContext.VariantsSubSetTaskGenerator, writersContext.TestableSubSetTaskWriter, viewContext.Default);
            SubSetTaskPresenter = new SubSetTaskPresenter(generatorContext.SubSetTaskGenerator, writersContext.SubSetTaskWriter, viewContext.Default);
        }
        

        public IEnumerable<ITaskPresenter> GetControllers()
        {
            yield return VariantsCharacteristicPropertyTaskPresenter;
            yield return VariantsSubSetTaskPresenter;
            yield return SubSetTaskPresenter;
        }
    }
}