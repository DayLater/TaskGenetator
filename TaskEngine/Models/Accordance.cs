using System.Collections.Generic;

namespace TaskEngine.Models
{
    public class Accordance<T>
    {
        public Accordance(IEnumerable<(T, T)> elements, string name)
        {
            Elements = elements;
            Name = name;
        }

        public string Name { get; }
        public IEnumerable<(T, T)> Elements { get; }
    }
}