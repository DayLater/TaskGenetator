using TaskEngine.Writers;
using TaskEngine.Writers.Tasks;

namespace TaskEngine.Contexts
{
    public class TaskWritersContext
    {
        public CharacteristicPropertyTaskWriter CharacteristicPropertyTaskWriter { get; }
        public TestableSubSetTaskWriter TestableSubSetTaskWriter { get; }
        public SubSetTaskWriter SubSetTaskWriter { get; }
        public BorderSetOperationTaskWriter BorderSetOperationTaskWriter { get; }

        public TaskWritersContext(ISetWriter setWriter)
        {
            CharacteristicPropertyTaskWriter = new CharacteristicPropertyTaskWriter(setWriter);
            TestableSubSetTaskWriter = new TestableSubSetTaskWriter(setWriter);
            SubSetTaskWriter = new SubSetTaskWriter(setWriter);
            BorderSetOperationTaskWriter = new BorderSetOperationTaskWriter(setWriter);
        }
    }
}