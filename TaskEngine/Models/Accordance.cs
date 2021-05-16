using System.Collections.Generic;

namespace TaskEngine.Models
{
    public class Accordance<T1, T2>
    {
        public Accordance(IEnumerable<(T1, T2)> elements, string name)
        {
            Elements = elements;
            Name = name;
        }

        public string Name { get; }
        public IEnumerable<(T1, T2)> Elements { get; }
    }
}