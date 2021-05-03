namespace TaskEngine.Views.TaskGenerators
{
    public interface ISymbolsBelongSetView: ISeveralAnswersVariantsGeneratorView
    {
        ISymbolMathSetGeneratorView SetGeneratorView { get; }
    }
}