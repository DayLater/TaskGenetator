namespace TaskEngine.Views.TaskGenerators
{
    public interface INumberBelongsSetGeneratorView: IView, IVariantsView
    {
        IIntMathSetGeneratorView IntMathSetGeneratorView { get; }
    }
}