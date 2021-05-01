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
            var taskIds = _tasksContext.Ids.ToList();
            if (taskIds.Count == 0)
            {
                _view.ShowMessage("Не выбрано ни одного задания. Создание отменено");
            }
            else
            {
                var count = _view.GetFileCount();
                var name = _view.GetFileName();
                var generators = taskIds.Select(generatorId => _taskGeneratorsContext.Get(generatorId)).ToList();

                for (int i = 0; i < count; i++)
                {
                    var tasks = generators.Select(g => g.Generate());
                    _docWriter.Write($"{name}_{i + 1}", tasks);
                }
            }
        }
    }
}