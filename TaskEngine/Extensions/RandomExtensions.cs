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
        private static readonly List<string> _usedSymbols = new List<string>();

        public static string GetRandomName(this Random random)
        {
            var name = random.GetRandomItem(Symbols.Names, _usedNames.ToArray());
            _usedNames.Add(name);
            return name;
        }

        public static void ClearNames(this Random random) => _usedNames.Clear();
        public static void ClearSymbols(this Random random) => _usedSymbols.Clear();

        private static string GetRandomItem(this Random random, IReadOnlyList<string> source, params string[] except)
        {
            var i = random.Next(0,  source.Count);
            var symbol =  source[i];
            while (except.Contains(symbol))
                    symbol += "'";

            return symbol;
        }

        public static string GetRandomElementSymbol(this Random random)
        {
            var s = random.GetRandomItem(Symbols.Elements, _usedSymbols.ToArray());
            _usedSymbols.Add(s);
            return s;
        }
    }
}