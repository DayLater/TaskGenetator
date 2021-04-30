using System.Collections.Generic;
using TaskEngine.Presenters;
using TaskEngine.Presenters.Elements;

namespace TaskEngine.Contexts
{
    public class TaskPresentersContext
    {
        private readonly List<ITaskPresenter> _presenters = new List<ITaskPresenter>();
        
        public TaskPresentersContext(TaskGeneratorContext generatorContext, TaskWritersContext writersContext, IViewContext viewContext)
        {
            _presenters.Add(new NumberBelongsSetTaskPresenter(generatorContext.NumberBelongsSetTaskGenerator, writersContext.NumberBelongsSetTaskWriter, viewContext.Default));

            _presenters.Add(new VariantsCharacteristicPropertyTaskPresenter(generatorContext.CharacteristicPropertyTaskGenerator, writersContext.CharacteristicPropertySetAnswerTaskWriter, viewContext.VariantsCharacteristicPropertyGeneratorView));
            _presenters.Add(new VariantsSubSetTaskPresenter(generatorContext.VariantsSubSetTaskGenerator, writersContext.TestableSubSetSetAnswerTaskWriter, viewContext.Default));
            _presenters.Add(new SubSetTaskPresenter(generatorContext.SubSetTaskGenerator, writersContext.SubSetTaskWriter, viewContext.Default));
        }

        public IEnumerable<ITaskPresenter> Presenters => _presenters;
    }
}