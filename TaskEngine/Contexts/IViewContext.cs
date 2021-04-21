using TaskEngine.Views;

namespace TaskEngine.Contexts
{
    public interface IViewContext
    {
        IVariantsCharacteristicPropertyGeneratorView VariantsCharacteristicPropertyGeneratorView { get; }
        IView Default { get; }
    }
}