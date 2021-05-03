using TaskEngine.Tasks.Texts;

namespace TaskEngine.Generators.TextTasks
{
    public interface ITextTaskGenerator
    {
        string Id { get; }
        ITextTask Generate();
    }
}