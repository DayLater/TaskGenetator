﻿using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Sets;

namespace TaskEngine
{
    public static class Symbols
    {
        private static readonly Random _random = new Random();
        
        public const string Belongs = "∈";
        public const string MoreOrEquals = "≥";
        public const string More = ">";
        public const string LessOrEquals = "≤";
        public const string Less = "<";
        
        public static string GetTypeSymbol(Type type)
        {
            if (type == typeof(int))
                return "Z";
            if (type == typeof(uint))
                return "N";
            if (type == typeof(double))
                return "Q";

            throw new ArgumentException("Unknown type");
        }
        
        public static IReadOnlyList<string> Names { get; } = new List<string>()
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "O", "P", "Q", "R", "S", "T",
            "U", "V", "W", "X", "Y", "Z"
        };

        public static string GetRandomName(params string[] except)
        {
            if (except.Length > 0)
            {
                string name;
                do
                {
                    var i = _random.Next(0, Names.Count);
                    name = Names[i];
                } while (except.Contains(name));

                return name;
            }
            
            var index = _random.Next(0, Names.Count);
            return Names[index];
        }
        
        public static IReadOnlyList<string> Elements { get; } = new List<string>()
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "o", "p", "q", "r", "s", "t",
            "u", "v", "w", "x", "y", "z"
        };
    }
}