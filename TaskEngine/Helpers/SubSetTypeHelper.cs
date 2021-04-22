using System;
using TaskEngine.Sets;

namespace TaskEngine.Helpers
{
    public static class SubSetTypeHelper
    {
        public static Func<int, bool> GetTypeFunc(SubSetType type)
        {
            return type switch
            {
                SubSetType.Positive => i => i > 0,
                SubSetType.NonPositive => i => i <= 0,
                SubSetType.Negative => i => i < 0,
                SubSetType.NonNegative => i => i >= 0,
                SubSetType.Even => i => i % 2 == 0,
                SubSetType.Odd => i => i % 2 == 1,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
        
        public static SubSetType GetRandomSubSetType()
        {
            var random = new Random();
            return (SubSetType) random.Next(0, (int) SubSetType.MaxCount);
        }
        
        public static string GetNumbersType(SubSetType type)
        {
            return type switch
            {
                SubSetType.Positive => "положительные",
                SubSetType.NonPositive => "неположительные",
                SubSetType.Negative => "отрицательные",
                SubSetType.NonNegative => "неотрицательные",
                SubSetType.Even => "четные",
                SubSetType.Odd => "нечетные",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}