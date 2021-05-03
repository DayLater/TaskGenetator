using TaskEngine.Tasks.Texts;

namespace TaskEngine.Generators.TextTasks
{
    public interface ITextTaskGenerator
    {
        ITextTask Generate();
    }
}