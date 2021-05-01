using TaskEngine.Views;
using TaskEngine.Views.TaskGenerators;

namespace TaskEngine.Contexts
{
    public interface IViewContext
    {
        IMainView MainView { get; }
        ITaskChooseView TaskChooseView { get; }
        ICreateDocumentView CreateDocumentView { get; }

        
        IVariantsCharacteristicPropertyGeneratorView VariantsCharacteristicPropertyGeneratorView { get; }
        IView Empty { get; }

        IView GetView(string id);
        

    }
}