using System;

namespace TaskEngine.Contexts
{
    public class UserContext
    {
        private int _currentPageIndex;

        public int CurrentPageIndex
        {
            get => _currentPageIndex;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                _currentPageIndex = value;
            }
        }
        
        public TasksContext TasksContext { get; } = new TasksContext();
    }
}