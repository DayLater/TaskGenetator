using TaskEngine.Writers;
using TaskEngine.Writers.Tasks;
using TaskEngine.Writers.Tasks.Elements;

namespace TaskEngine.Contexts
{
    public class TaskWritersContext
    {
        public NumberBelongsSetTaskWriter NumberBelongsSetTaskWriter { get; }
        public CharacteristicPropertySetAnswerTaskWriter CharacteristicPropertySetAnswerTaskWriter { get; }
        public TestableSubSetSetAnswerTaskWriter TestableSubSetSetAnswerTaskWriter { get; }
        public SubSetTaskWriter SubSetTaskWriter { get; }
        public BorderSetOperationTaskWriter BorderSetOperationTaskWriter { get; }

        public TaskWritersContext(ISetWriter setWriter)
        {
            NumberBelongsSetTaskWriter = new NumberBelongsSetTaskWriter(setWriter);
            CharacteristicPropertySetAnswerTaskWriter = new CharacteristicPropertySetAnswerTaskWriter(setWriter);
            TestableSubSetSetAnswerTaskWriter = new TestableSubSetSetAnswerTaskWriter(setWriter);
            SubSetTaskWriter = new SubSetTaskWriter(setWriter);
            BorderSetOperationTaskWriter = new BorderSetOperationTaskWriter(setWriter);
        }
    }
}