using TaskEngine.Tasks;

namespace TaskEngine.Writers.Tasks
{
    public class BorderSetOperationTaskWriter: ITaskWriter<BorderSetOperationTask>
    {
        private readonly ISetWriter _setWriter;

        public BorderSetOperationTaskWriter(ISetWriter setWriter)
        {
            _setWriter = setWriter;
        }

        public string WriteTask(BorderSetOperationTask task)
        {
            var firstName = task.First.Name;
            var secondName = task.Second.Name;
            var firstSet = _setWriter.Write(task.First);
            var secondSet = _setWriter.Write(task.Second);
            var operation = SetOperationHelper.GetString(task.Operation);

            var result = $"Найдите {operation} множеств {firstName} и {secondName}, если: " +
                         $"\n{firstSet}, {secondSet}";

            int index = 1;
            foreach (var variant in task.Variants)
            {
                result += $"\n{index}) {_setWriter.Write(variant, false)}";
                index++;
            }

            return result;
        }

        public string WriteAnswer(BorderSetOperationTask task)
        {
            throw new System.NotImplementedException();
        }
    }
}