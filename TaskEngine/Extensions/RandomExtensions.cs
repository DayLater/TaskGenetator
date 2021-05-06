using System;
using TaskEngine.Sets;

namespace TaskEngine.Extensions
{
    public static class RandomExtensions
    {
        public static bool GetBool(this Random random)
        {
            var value = random.Next(0, 2);
            return value == 0;
        }
        
        public static BorderType GetRandomBorderType(this Random random)
        {
            var value = random.GetBool();
            return value ? BorderType.Open : BorderType.Close;
        }

        public static int GetNext(this Random random, int min, int max, int delta)
        {
            return random.Next(min - delta, max + delta);
        }
    }
}