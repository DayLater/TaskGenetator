using TaskEngine.Sets;

namespace TaskEngine.Writers
{
    public interface ISetWriter
    {
        public string Write<T>(ISet<T> set);
    }
}