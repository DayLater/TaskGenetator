using System.Collections.Generic;
using TaskEngine.Tasks.Texts;

namespace WinGenerator.DocWriters
{
    public interface IDocWriter
    {
        void Write(string filename, IEnumerable<ITextTask> textTasks);
    }
}