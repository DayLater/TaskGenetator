using TaskEngine.Tasks.Texts;

namespace TaskEngine.Generators.Tasks.TextTasks
{
    public interface ITextTaskGenerator
    {
        ITextTask Generate();
    }
}