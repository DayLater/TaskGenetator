using System;
using System.Collections.Generic;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers
{
    public class TaskWriter
    {
        private readonly ISetWriter _setWriter;
        private readonly VariantTaskWriter _variantTaskWriter;

        public TaskWriter(ISetWriter setWriter, Random random)
        {
            _variantTaskWriter = new VariantTaskWriter(setWriter, random);
            _setWriter = setWriter;
        }

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

        public string WriteAll(ITask task, string condition)
        {
            return WriteAll(WriteTextTask(task, condition));
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

        public ITextTask WriteTextTask(ITask task, string condition)
        {
            return task switch
            {
                IVariantsTask<int> intVariantTask =>_variantTaskWriter.Write(intVariantTask, condition),
                IVariantsTask<string> strVariantsTask => _variantTaskWriter.Write(strVariantsTask, condition),
                IVariantsTask<IMathSet<int>> intSetVariantsTask =>_variantTaskWriter.Write(intSetVariantsTask, condition),
                IVariantsTask<IMathSet<string>> strSetVariantsTask => _variantTaskWriter.Write(strSetVariantsTask, condition),
                IAnswerTask<int> answerTask => new TextTask(condition, answerTask.Answers[0].ToString()),
                IAnswerTask<string> answerTask => new TextTask(condition, answerTask.Answers[0]),
                IAnswerTask<ExpressionSet> answerTask => new TextTask(condition, _setWriter.Write(answerTask.Answers[0])),
                IAnswerTask<IMathSet<int>> answerTask => new TextTask(condition, _setWriter.Write(answerTask.Answers[0])),
                IAnswerTask<IMathSet<string>> answerTask => new TextTask(condition, _setWriter.Write(answerTask.Answers[0])),
                _ => throw new ArgumentOutOfRangeException("")
            };
        }
    }
}