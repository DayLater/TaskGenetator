using System;
using System.Collections.Generic;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace TaskEngine.Writers.DocWriters
{
    public class Document: IDisposable
    {
        public int TextFontSize { get; set; } = 12;
        public int TitleFontSize { get; set; } = 16;
        public string Font { get; set; } = "Times New Roman";
        
        private readonly DocX _doc;

        public Document(DocX doc)
        {
            _doc = doc;
        }
        
        public void AddTitle(string text)
        {
            var p = AddLine(text, TitleFontSize, Font);
            p.Alignment = Alignment.center;
            p.Bold();
        }

        public void AddText(string text) => AddLine(text, TextFontSize, Font);

        public void AddSpace() => _doc.InsertParagraph();

        private Paragraph AddLine(string text, int size, string font)
        {
            var p = _doc.InsertParagraph();
            p.Append(text);
            p.FontSize(size);
            p.Font(font);
            return p;
        }

        public void AddList(IEnumerable<string> items)
        {
            var list = _doc.AddList();
            foreach (var item in items)
                _doc.AddListItem(list, item);

            var insertList = _doc.InsertList(list);
            foreach (var item in insertList.Items)
            {
                item.FontSize(TextFontSize);
                item.Font(Font);
            }
        }

        public void InsertPageBreak() => _doc.InsertSectionPageBreak();
        public void Save(string fileName) => _doc.SaveAs(fileName);

        public void Dispose()
        {
            _doc?.Dispose();
        }
    }
}