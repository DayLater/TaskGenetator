using System.Collections.Generic;
using TaskEngine.Controllers;

namespace TaskEngine.Contexts
{
    public class TaskControllersContext
    {
        public TestableCharacteristicPropertyTaskController TestableCharacteristicPropertyTaskController { get; }
        public TestableSubSetTaskController TestableSubSetTaskController { get; }
        public SubSetTaskController SubSetTaskController { get; }
        
        public TaskControllersContext(TaskGeneratorContext generatorContext, TaskWritersContext writersContext, IViewContext viewContext)
        {
            TestableCharacteristicPropertyTaskController = new TestableCharacteristicPropertyTaskController(generatorContext.CharacteristicPropertyTaskGenerator, writersContext.CharacteristicPropertyTaskWriter, viewContext.VariantsCharacteristicPropertyGeneratorView);
            TestableSubSetTaskController = new TestableSubSetTaskController(generatorContext.TestableSubSetTaskGenerator, writersContext.TestableSubSetTaskWriter, viewContext.Default);
            SubSetTaskController = new SubSetTaskController(generatorContext.SubSetTaskGenerator, writersContext.SubSetTaskWriter, viewContext.Default);
        }
        

        public IEnumerable<ITaskController> GetControllers()
        {
            yield return TestableCharacteristicPropertyTaskController;
            yield return TestableSubSetTaskController;
            yield return SubSetTaskController;
        }
    }
}