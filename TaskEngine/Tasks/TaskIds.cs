using System.Collections.Generic;

namespace TaskEngine.Tasks
{
    public static class TaskIds
    {
        public const string NumberBelongsSetTask = "Принадлежность элемента множеству (числа)";
        public const string NumbersBelongSetTask = "Принадлежность элементов множеству (числа)";
        public const string NumberBelongsBorderedSetTask = "Принадлежность элемента ограниченному множеству";
        public const string NumbersBelongBorderedSetTask = "Принадлежность элементов ограниченному множеству";
        public const string SymbolBelongsSetTask = "Принадлежность элемента множеству (буквы)";
        public const string SymbolsBelongSetTask = "Принадлежность элементов множеству (буквы)";

        public const string SetContainsElement = "Множество, содержащее элемент (числа)";
        public const string SetContainsElements = "Множество, содержащее элементы (числа)";
        

        public const string CharacteristicPropertyTask = "Характеристическое свойство (тестовое)";
        public const string VariantsSubSetTask = "Подмножество (тестовое)";
        public const string SubSetTask = "Подмножество";
        public const string BorderSetOperationTask = "Операции над множествами. Граничные";

        public static IEnumerable<string> Ids => new[]
        {
            NumberBelongsSetTask, CharacteristicPropertyTask, VariantsSubSetTask, SubSetTask, BorderSetOperationTask, NumbersBelongSetTask
        };
    }
}