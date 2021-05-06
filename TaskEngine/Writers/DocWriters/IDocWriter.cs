using System.Collections.Generic;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.DocWriters
{
    public interface IDocWriter
    {
        void Write(string filename, IEnumerable<ITextTask> textTasks, int variantNumber);
    }
}