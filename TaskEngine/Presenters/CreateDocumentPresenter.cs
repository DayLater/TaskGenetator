using System.Linq;
using TaskEngine.Contexts;
using TaskEngine.DocWriters;
using TaskEngine.Views;

namespace TaskEngine.Presenters
{
    public class CreateDocumentPresenter: IPresenter
    {
        private readonly ICreateDocumentView _view;
        private readonly TasksContext _tasksContext;
        private readonly IDocWriter _docWriter;
        private readonly TextTaskGeneratorsContext _taskGeneratorsContext;
        
        public CreateDocumentPresenter(ICreateDocumentView view, TasksContext tasksContext, IDocWriter docWriter, TextTaskGeneratorsContext taskGeneratorsContext)
        {
            _view = view;
            _tasksContext = tasksContext;
            _docWriter = docWriter;
            _taskGeneratorsContext = taskGeneratorsContext;

            _view.GenerateButtonClicked += OnGenerateButtonClicked;
        }

        private void OnGenerateButtonClicked()
        {
            var tasks = _tasksContext.Ids
                .Select(generatorId => _taskGeneratorsContext.Get(generatorId))
                .Select(generator => generator.Generate())
                .ToList();
            _docWriter.Write("testFile", tasks);
        }
    }
}