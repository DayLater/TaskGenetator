using System.Collections.Generic;

namespace TaskEngine
{
    public static class TaskIds
    {
        public const string Empty = "Empty";
        public const string NumberBelongsSetTask = "Принадлежность элемента множеству (перечисление элементов)";
        public const string CharacteristicPropertyTask = "Характеристическое свойство (тестовое)";
        public const string VariantsSubSetTask = "Подмножество (тестовое)";
        public const string SubSetTask = "Подмножество";
        public const string BorderSetOperationTask = "Операции над множествами. Граничные";

        public static IEnumerable<string> Ids => new[]
        {
            NumberBelongsSetTask, CharacteristicPropertyTask, VariantsSubSetTask, SubSetTask, BorderSetOperationTask
        };
    }
}