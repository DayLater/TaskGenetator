using System;

namespace TaskEngine.Helpers
{
    public static class SetOperationHelper
    {
        public static SetOperation GetRandomSetOperation()
        {
            var random = new Random();
            var operation = (SetOperation) random.Next(0, (int) SetOperation.MaxCount);
            return operation;
        }

        public static string GetString(SetOperation operation)
        {
            return operation switch
            {
                SetOperation.Union => "объединение",
                SetOperation.Except => "разность",
                SetOperation.Intersect => "пересечение",
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
            };
        }
    }
}