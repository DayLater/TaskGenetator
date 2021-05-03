namespace TaskEngine.Views.TaskGenerators
{
    public interface ISymbolBelongsSetView: IVariantsView
    {
        ISymbolMathSetGeneratorView SetGeneratorView { get; }
    }
}