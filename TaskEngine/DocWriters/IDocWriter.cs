using System.Collections.Generic;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.DocWriters
{
    public interface IDocWriter
    {
        void Write(string filename, IEnumerable<ITextTask> textTasks);
    }
}