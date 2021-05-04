using TaskEngine.Tasks.Texts;
using Xceed.Words.NET;

namespace TaskEngine.Writers.DocWriters
{
    public class VariantTaskDocWriter
    {
        public void Write(DocX doc, IVariantsTextTask variantsTextTask, int index)
        {
            var task = doc.InsertParagraph();
            task.AppendLine($"№ {index}. {variantsTextTask.Task}");
            
            var list = doc.AddList();
            foreach (var variant in variantsTextTask.Variants)
            {
                doc.AddListItem(list, variant);
            }
            doc.InsertList(list);
        }
    }
}