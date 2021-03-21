using System;

namespace TaskEngine
{
    public static class Types
    {
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
    }
}