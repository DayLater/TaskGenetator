using Xceed.Words.NET;

namespace TaskEngine.Writers.DocWriters
{
    public class DocumentFactory
    {
        public Document Create(string filename)
        {
            var docX = DocX.Create(filename);
            return new Document(docX);
        }
    }
}