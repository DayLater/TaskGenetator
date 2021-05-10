using System.Collections.Generic;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.DocWriters
{
    public interface IDocWriter
    {
        string Path { get; set; }
        void Write(string filename, IEnumerable<ITextTask> textTasks, int variantNumber);
    }
}