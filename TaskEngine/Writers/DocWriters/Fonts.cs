using System.Collections.Generic;

namespace TaskEngine.Writers.DocWriters
{
    public static class Fonts
    {
        public const string TimesNewRoman = "Times New Roman";
        public const string Arial = "Arial";
        public const string Calibri = "Calibri";
        public const string Tahoma = "Tahoma";
        public const string Verdana = "Verdana";
        
        public static IEnumerable<string> GetFonts()
        {
            yield return TimesNewRoman;
            yield return Arial;
            yield return Calibri;
            yield return Tahoma;
            yield return Verdana;
        } 
    }
}