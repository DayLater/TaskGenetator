using System;
using TaskEngine.Models;

namespace TaskEngine.Writers
{
    public class ReflectionWriter
    {
        public string CreateReflectionString(Reflection reflection, string funcName = "f")
        {
            var result = $"{funcName}(x) = {reflection.Coefficient}x";
            if (reflection.IsFreeCoefficient)
            {
                var operation = reflection.FreeCoefficient < 0 ? "-" : "+";
                return result + $" {operation} {Math.Abs(reflection.FreeCoefficient)}";
            }

            return result;
        }
    }
}