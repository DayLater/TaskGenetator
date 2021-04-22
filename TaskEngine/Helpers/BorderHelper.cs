using System;
using TaskEngine.Extensions;
using TaskEngine.Sets;

namespace TaskEngine.Helpers
{
    public static class BorderHelper
    {
        public static BorderType GetRandomBorderType()
        {
            var random = new Random();
            var value = random.GetBool();
            return value ? BorderType.Open : BorderType.Close;
        }
        
        public static BorderType GetAnotherBorder(BorderType borderType)
        {
            return borderType == BorderType.Close ? BorderType.Open : BorderType.Close;
        }
    }
}