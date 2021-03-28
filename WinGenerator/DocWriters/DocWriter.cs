using System.Collections.Generic;
using TaskEngine.Tasks.Texts;
using Xceed.Words.NET;

namespace WinGenerator.DocWriters
{
    public class DocWriter: IDocWriter
    {
        private readonly VariantTaskDocWriter _variantTaskDocWriter = new VariantTaskDocWriter();
        private readonly TaskDocWriter _taskDocWriter = new TaskDocWriter();
        
        public void Write(string filename, IEnumerable<ITextTask> textTasks)
        {
            using (var doc = DocX.Create(filename))
            {
                var taskIndex = 1;
                foreach (var textTask in textTasks)
                {
                    switch (textTask)
                    {
                        case IVariantsTextTask variantsTextTask: _variantTaskDocWriter.Write(doc, variantsTextTask, taskIndex);
                            break;
                        case ITextTask _ : _taskDocWriter.Write(doc, textTask, taskIndex);
                            break;
                    }

                    doc.InsertParagraph();
                    taskIndex++;
                }
                doc.Save();
            }
        }
    }
}