using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public interface IVariantsTaskGenerator<out TTask>: ITaskGenerator<TTask>
        where TTask: ITask
    {
        int VariantCount { get; set; }
    }
}