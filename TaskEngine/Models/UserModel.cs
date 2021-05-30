using System;

namespace TaskEngine.Models
{
    public class UserModel
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
        
        public TasksModel TasksModel { get; } = new TasksModel();
    }
}