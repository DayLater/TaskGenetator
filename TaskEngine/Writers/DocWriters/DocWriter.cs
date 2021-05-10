﻿using System.Collections.Generic;
using System.Linq;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.DocWriters
{
    public class DocWriter: IDocWriter
    {
        public string Path { get; set; }
        private readonly DocumentFactory _factory = new DocumentFactory();

        public void Write(string filename, IEnumerable<ITextTask> textTasks, int variantNumber)
        {
            using var doc = _factory.Create(filename);
            doc.AddTitle("Контрольная работа");
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
            
            doc.Save($"{Path}\\{filename}.docx");
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