namespace TaskEngine.Views.TaskGenerators
{
    public interface INumberBelongsSetGeneratorView: IView, IVariantsView
    {
        IMathSetGeneratorView MathSetGeneratorView { get; }
    }
}