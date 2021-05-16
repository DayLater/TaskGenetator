using System.Collections.Generic;
using System.Linq;
using TaskEngine.Models.Tasks.Texts;

namespace TaskEngine.Writers.DocWriters
{
    public class DocWriter: IDocWriter
    {
        private readonly DocumentFactory _factory = new DocumentFactory();

        public FontSettings TitleFont { get; } = new FontSettings();
        public FontSettings TextFont { get; } = new FontSettings();
        
        public string TitleText { get; set; }

        public DocWriter()
        {
            TitleFont.Size = 16;
        }
        
        public void Write(string filename, IEnumerable<ITextTask> textTasks, int variantNumber)
        {
            using var doc = _factory.Create(filename);
            doc.TextFont.Font = TextFont.Font;
            doc.TextFont.Size = TextFont.Size;

            doc.TitleFont.Font = TitleFont.Font;
            doc.TitleFont.Size = TitleFont.Size;
            
            doc.AddTitle(TitleText);
            doc.AddTitle($"Вариант №{variantNumber}");
            doc.AddSpace();

            var taskIndex = 1;
            var tasks = textTasks.ToList();
            foreach (var textTask in tasks)
            {
                switch (textTask)
                {
                    case IVariantsTextTask variantsTextTask: WriteVariantsTask(variantsTextTask, taskIndex, doc);
                        break;
                    case { }: WriteTask(textTask, taskIndex, doc);
                        break;
                }
                
                doc.AddSpace();
                taskIndex++;
            }
            
            doc.InsertPageBreak();
            WriteAnswers(tasks, doc);
            
            doc.Save(filename);
        }

        private void WriteVariantsTask(IVariantsTextTask textTask, int index, Document document)
        {
            WriteTask(textTask, index, document);
            document.AddList(textTask.Variants);
        }
        
        private void WriteTask(ITextTask textTask, int index, Document document)
        {
            document.AddText($"№ {index}. {textTask.Task}");
        }

        private void WriteAnswers(IEnumerable<ITextTask> textTasks, Document doc)
        {
            doc.AddTitle("Ответы");
            doc.AddSpace();

            int taskIndex = 1;
            foreach (var textTask in textTasks)
            {
                doc.AddText($"{taskIndex}) {textTask.Answer}");
                taskIndex++;
            }
        }
    }
}