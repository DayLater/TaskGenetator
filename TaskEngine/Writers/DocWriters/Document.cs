using System;
using System.Collections.Generic;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace TaskEngine.Writers.DocWriters
{
    public class Document: IDisposable
    {
        public FontSettings TitleFont { get; } = new FontSettings();
        public FontSettings TextFont { get; } = new FontSettings();

        private readonly DocX _doc;

        public Document(DocX doc)
        {
            _doc = doc;
        }
        
        public void AddTitle(string text)
        {
            var p = AddLine(text, TitleFont);
            p.Alignment = Alignment.center;
            p.Bold();
        }

        public void AddText(string text) => AddLine(text, TextFont);

        public void AddSpace() => _doc.InsertParagraph();

        private Paragraph AddLine(string text, FontSettings fontSettings)
        {
            var p = _doc.InsertParagraph();
            p.Append(text);
            p.FontSize(fontSettings.Size);
            p.Font(fontSettings.Font);
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
                item.FontSize(TextFont.Size);
                item.Font(TextFont.Font);
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