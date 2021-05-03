namespace TaskEngine.Views.TaskGenerators
{
    public interface ISymbolBelongToSetView: IVariantsView
    {
        ISymbolMathSetGeneratorView SetGeneratorView { get; }
    }
}