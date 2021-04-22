using System.Collections.Generic;
using TaskEngine.Controllers;

namespace TaskEngine.Contexts
{
    public class TaskControllersContext
    {
        public VariantsCharacteristicPropertyTaskController VariantsCharacteristicPropertyTaskController { get; }
        public VariantsSubSetTaskController VariantsSubSetTaskController { get; }
        public SubSetTaskController SubSetTaskController { get; }
        
        public TaskControllersContext(TaskGeneratorContext generatorContext, TaskWritersContext writersContext, IViewContext viewContext)
        {
            VariantsCharacteristicPropertyTaskController = new VariantsCharacteristicPropertyTaskController(generatorContext.CharacteristicPropertyTaskGenerator, writersContext.CharacteristicPropertyTaskWriter, viewContext.VariantsCharacteristicPropertyGeneratorView);
            VariantsSubSetTaskController = new VariantsSubSetTaskController(generatorContext.VariantsSubSetTaskGenerator, writersContext.TestableSubSetTaskWriter, viewContext.Default);
            SubSetTaskController = new SubSetTaskController(generatorContext.SubSetTaskGenerator, writersContext.SubSetTaskWriter, viewContext.Default);
        }
        

        public IEnumerable<ITaskController> GetControllers()
        {
            yield return VariantsCharacteristicPropertyTaskController;
            yield return VariantsSubSetTaskController;
            yield return SubSetTaskController;
        }
    }
}