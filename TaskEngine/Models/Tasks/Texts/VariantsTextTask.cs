using System.Collections.Generic;

namespace TaskEngine.Models.Tasks.Texts
{
    public class VariantsTextTask: TextTask, IVariantsTextTask
    {
        public VariantsTextTask(string task, string answer, IEnumerable<string> variants) : base(task, answer)
        {
            Variants = variants;
        }
        
        public IEnumerable<string> Variants { get; }
    }
}