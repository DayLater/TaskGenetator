using System.Collections.Generic;

namespace TaskEngine.Models
{
    public class TasksModel
    {
        private readonly List<string> _ids = new List<string>();
        
        public void Add(string id)
        {
            if (!_ids.Contains(id))
                _ids.Add(id);
        }

        public void Remove(string id)
        {
            _ids.Remove(id);
        }

        public void Clear() => _ids.Clear();

        public bool Contains(string id) => _ids != null && _ids.Contains(id);

        public IEnumerable<string> Ids => _ids;
    }
}