using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers.Tasks;

namespace TaskEngine.Controllers
{
    public class SubSetTaskController: ITaskController
    {
        private readonly SubSetTaskGenerator _generator;
        private readonly SubSetTaskWriter _writer;

        public SubSetTaskController(SubSetTaskGenerator generator, SubSetTaskWriter writer)
        {
            _generator = generator;
            _writer = writer;
        }

        public string Id => TaskIds.SubSetTask;
        
        public ITextTask Generate()
        {
            var task = _generator.Generate();
            return _writer.WriteTask(task);
        }
    }
}