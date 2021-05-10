namespace TaskEngine.Models.Tasks.Texts
{
    public class TextTask: ITextTask
    {
        public TextTask(string task, string answer)
        {
            Task = task;
            Answer = answer;
        }

        public string Task { get; }
        public string Answer { get; }
    }
}