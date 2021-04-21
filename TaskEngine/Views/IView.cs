namespace TaskEngine.Views
{
    public interface IView
    {
        string Name { get; }
        void Activate();
        void Deactivate();
        object GetControl();
    }
}