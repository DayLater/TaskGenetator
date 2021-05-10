using System.Collections.Generic;

namespace TaskEngine.Models.Tasks.Texts
{
    public interface IVariantsTextTask: ITextTask
    {
        IEnumerable<string> Variants { get; }
    }
}