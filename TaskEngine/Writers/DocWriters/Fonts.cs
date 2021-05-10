using System.Collections.Generic;

namespace TaskEngine.Writers.DocWriters
{
    public static class Fonts
    {
        public const string TimesNewRoman = "Times New Roman";
        
        public static IEnumerable<string> GetFonts()
        {
            yield return TimesNewRoman;
        } 
    }
}