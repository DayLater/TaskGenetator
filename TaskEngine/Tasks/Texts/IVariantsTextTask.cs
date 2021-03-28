using System.Collections.Generic;

namespace TaskEngine.Tasks.Texts
{
    public interface IVariantsTextTask: ITextTask
    {
        IEnumerable<string> Variants { get; }
    }
}