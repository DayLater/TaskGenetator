using System;
using System.Collections.Generic;
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
        
        public static BorderType GetRandomBorderType(this Random random)
        {
            var value = random.GetBool();
            return value ? BorderType.Open : BorderType.Close;
        }

        public static int GetNext(this Random random, int min, int max, int delta)
        {
            return random.Next(min - delta, max + delta);
        }

        private static readonly List<string> _usedNames = new List<string>();
        
        public static string GetRandomName(this Random random)
        {
            var name = random.GetRandomItem(Symbols.Names, _usedNames.ToArray());
            _usedNames.Add(name);
            return name;
        }

        public static void ClearNames(this Random random) => _usedNames.Clear();

        private static T GetRandomItem<T>(this Random random, IReadOnlyList<T> source, params T[] except)
        {
            if (except.Length > 0)
            {
                T symbol;
                do
                {
                    var i = random.Next(0,  source.Count);
                    symbol =  source[i];
                } while (except.Contains(symbol));

                return symbol;
            }
            
            var index = random.Next(0,  source.Count);
            return source[index];
        }

        public static string GetRandomElementSymbol(this Random random, params string[] except)
        {
            return random.GetRandomItem(Symbols.Elements, except);
        }
    }
}