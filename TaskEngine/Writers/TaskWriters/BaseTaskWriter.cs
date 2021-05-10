using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Models.Tasks;
using TaskEngine.Models.Tasks.Texts;

namespace TaskEngine.Writers.TaskWriters
{
    public abstract class BaseTaskWriter<T>: ITaskWriter
    {
        private readonly Random _random;

        protected BaseTaskWriter(Random random)
        {
            _random = random;
        }

        public ITextTask Write(ITask task)
        {
            if (TryWriteVariantsTask(task, out var result))
                return result;

            var answerTask = GetAnswers(task);
            return new TextTask(task.Condition, GetAnswer(answerTask));
        }

        private bool TryWriteVariantsTask(ITask task, out TextTask result)
        {
            result = null;
            if (task is IVariantsTask<T> variantsTask)
            {
                variantsTask.Variants.Shuffle(_random);
                string answer = variantsTask.Answers.Select(a => variantsTask.Variants.IndexOf(a) + 1)
                    .GetStringRepresentation();
                var variants = GetVariants(variantsTask.Variants);
                result = new VariantsTextTask(variantsTask.Condition, answer, variants);
            }

            return result != null;
        }

        protected abstract string GetAnswer(IList<T> answers); 
        protected abstract IEnumerable<string> GetVariants(IEnumerable<T> variants);

        private IList<T> GetAnswers(ITask task)
        {
            return ((IAnswerTask<T>) task).Answers;
        }
    }
}