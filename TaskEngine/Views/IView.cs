namespace TaskEngine.Views
{
    public interface IView
    {
        string Id { get; }
        void Activate();
        void Deactivate();
    }
}