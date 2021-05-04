using System.Collections;
using System.Collections.Generic;
using TaskEngine.Extensions;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers
{
    public class TaskWriter
    {
        public string WriteAll(ITextTask textTask)
        {
            var result = textTask.Task;
            if (textTask is IVariantsTextTask variantsTextTask)
            {
                var variants = WriteVariants(variantsTextTask);
                foreach (var variant in variants)
                    result += $"\n{variant}";
            }
            result += $"\n{WriteAnswer(textTask)}";
            return result;
        }

        public IEnumerable<string> WriteVariants(IVariantsTextTask variantsTextTask)
        {
            int taskNumber = 1;
            foreach (var variant in variantsTextTask.Variants)
            {
                yield return $"{taskNumber}) {variant}";
                taskNumber++;
            }
        }

        public string WriteAnswer(ITextTask textTask)
        {
            return $"Ответ: {textTask.Answer}";
        }
    }
}