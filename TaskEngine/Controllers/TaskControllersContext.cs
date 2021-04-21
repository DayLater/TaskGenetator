using System.Collections.Generic;
using TaskEngine.Contexts;

namespace TaskEngine.Controllers
{
    public class TaskControllersContext
    {
        public TestableCharacteristicPropertyTaskController TestableCharacteristicPropertyTaskController { get; }
        public TestableSubSetTaskController TestableSubSetTaskController { get; }
        public SubSetTaskController SubSetTaskController { get; }
        
        public TaskControllersContext(TaskGeneratorContext generatorContext, TaskWritersContext writersContext)
        {
            TestableCharacteristicPropertyTaskController = new TestableCharacteristicPropertyTaskController(generatorContext.CharacteristicPropertyTaskGenerator, writersContext.CharacteristicPropertyTaskWriter);
            TestableSubSetTaskController = new TestableSubSetTaskController(generatorContext.TestableSubSetTaskGenerator, writersContext.TestableSubSetTaskWriter);
            SubSetTaskController = new SubSetTaskController(generatorContext.SubSetTaskGenerator, writersContext.SubSetTaskWriter);
        }
        

        public IEnumerable<ITaskController> GetControllers()
        {
            yield return TestableCharacteristicPropertyTaskController;
            yield return TestableSubSetTaskController;
            yield return SubSetTaskController;
        }
    }
}