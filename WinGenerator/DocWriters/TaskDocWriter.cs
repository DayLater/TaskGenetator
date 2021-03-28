using TaskEngine.Tasks.Texts;
using Xceed.Words.NET;

namespace WinGenerator.DocWriters
{
    public class TaskDocWriter
    {
        public void Write(DocX docX, ITextTask textTask, int index)
        {
            var p1 = docX.InsertParagraph();
            p1.AppendLine($"№ {index}. {textTask.Task}");
        }
    }
}