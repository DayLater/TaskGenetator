using System.Linq;
using TaskEngine.Contexts;
using TaskEngine.Factories;
using TaskEngine.Views;
using TaskEngine.Writers;
using TaskEngine.Writers.DocWriters;
using TaskEngine.Writers.TaskWriters;

namespace TaskEngine.Presenters
{
    public class CreateDocumentPresenter: IPresenter
    {
        private readonly ICreateDocumentView _view;
        private readonly IDocWriter _docWriter;

        private readonly TasksContext _tasksContext;
        private readonly TaskGeneratorFactory _taskGeneratorFactory;
        private readonly TaskWriter _taskWriter;
        
        public CreateDocumentPresenter(ICreateDocumentView view, TasksContext tasksContext, IDocWriter docWriter, TaskGeneratorFactory taskGeneratorFactory, TaskWriter taskWriter)
        {
            _view = view;
            _tasksContext = tasksContext;
            _docWriter = docWriter;
            _taskGeneratorFactory = taskGeneratorFactory;
            _taskWriter = taskWriter;

            _view.GenerateButtonClicked += OnGenerateButtonClicked;
        }

        private void OnGenerateButtonClicked()
        {
            var taskIds = _tasksContext.Ids.ToList();
            if (taskIds.Count == 0)
            {
                _view.ShowMessage("Не выбрано ни одного задания. Создание отменено");
            }
            else
            {
                var count = _view.GetFileCount();
                var name = _view.GetFileName();
                var generators = taskIds.Select(id => _taskGeneratorFactory.Get(id)).ToList();

                for (int i = 0; i < count; i++)
                {
                    var tasks = generators.Select(g => g.Generate()).Select(_taskWriter.WriteTextTask).ToList();
                    _docWriter.Write($"{name}_{i + 1}", tasks, i + 1);
                }
            }
        }
    }
}