using TaskEngine.Sets;

namespace TaskEngine.Helpers
{
    public static class BorderHelper
    {
        public static BorderType GetAnotherBorder(BorderType borderType)
        {
            return borderType == BorderType.Close ? BorderType.Open : BorderType.Close;
        }
    }
}