using System;
using System.Linq;
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

        public static int GetNextExcept(this Random random, int min, int max, IMathSet<int> set)
        {
            while (true)
            {
                int value = random.Next(min, max);
                if (! set.GetElements().Contains(value))
                    return value;
            } 
        }
    }
}