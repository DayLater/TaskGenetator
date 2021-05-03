namespace TaskEngine.Generators.Tasks
{
    public interface IVariantsTaskGenerator : ITaskGenerator
    {
        int VariantsCount { get; set; }
    }
}