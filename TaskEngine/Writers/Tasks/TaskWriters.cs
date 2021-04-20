using System;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.Tasks
{
    public class TaskWriters
    {
        public CharacteristicPropertyTaskWriter CharacteristicPropertyTaskWriter { get; }
        public TestableSubSetTaskWriter TestableSubSetTaskWriter { get; }
        public SubSetTaskWriter SubSetTaskWriter { get; }
        public BorderSetOperationTaskWriter BorderSetOperationTaskWriter { get; }

        public TaskWriters(ISetWriter setWriter)
        {
            CharacteristicPropertyTaskWriter = new CharacteristicPropertyTaskWriter(setWriter);
            TestableSubSetTaskWriter = new TestableSubSetTaskWriter(setWriter);
            SubSetTaskWriter = new SubSetTaskWriter(setWriter);
            BorderSetOperationTaskWriter = new BorderSetOperationTaskWriter(setWriter);
        }

        public ITextTask Write<T>(ITask<T> task)
        {
            return task switch
            {
                CharacteristicPropertyTask characteristicPropertyTask => CharacteristicPropertyTaskWriter.WriteTask(
                    characteristicPropertyTask),
                TestableSubSetTask testableSubSetTask => TestableSubSetTaskWriter.WriteTask(testableSubSetTask),
                SubSetTask subSetTask => SubSetTaskWriter.WriteTask(subSetTask),
                BorderSetOperationTask borderSetOperationTask => BorderSetOperationTaskWriter.WriteTask(
                    borderSetOperationTask),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}