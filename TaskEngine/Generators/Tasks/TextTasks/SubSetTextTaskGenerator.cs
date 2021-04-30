using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.TextTasks
{
    public class SubSetTextTaskGenerator: ITextTaskGenerator
    {
        private readonly ISetWriter _setWriter;
        private readonly SubSetTaskGenerator _taskGenerator;

        public SubSetTextTaskGenerator(ISetWriter setWriter, SubSetTaskGenerator taskGenerator)
        {
            _setWriter = setWriter;
            _taskGenerator = taskGenerator;
        }
        
        private string WriteAnswer(SubSetSetAnswerTask setAnswerTask)
        {
            return _setWriter.Write(setAnswerTask.TaskSet, false);
        }

        public ITextTask Generate()
        {
            var setAnswerTask = _taskGenerator.Generate();
            var writeSet = _setWriter.Write(setAnswerTask.TaskSet);
            var writeType = SubSetTypeHelper.GetNumbersType(setAnswerTask.TypeTask);
            var textTask = $"Дано множество {writeSet}." +
                           $"\nВыделите его подмножество, элементами которого являются {writeType} числа";

            var answer = WriteAnswer(setAnswerTask);
            return new TextTask(textTask, answer);
        }
    }
}